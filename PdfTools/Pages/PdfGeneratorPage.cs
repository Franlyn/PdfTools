using iTextSharp.text;
using iTextSharp.text.pdf;
using PdfTools.Models;
using PdfTools.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Resources;

namespace PdfTools.Pages
{
    public partial class PdfGeneratorPage : Form
    {
        private readonly int PictureBoxWidth = 160;
        private readonly int PictureBoxHeight = 220;
        private readonly int VerticalMargin = 20;
        private readonly int HorizontalMargin = 20;
        private readonly int NumImagesOnARow = 5;

        private List<PictureBox> pictureBoxes = new List<PictureBox>();
        private System.Drawing.Image dragToPictureBoxImage;
        //private ImageFitType selectedImageFitType;
        //private LayoutType selectedLayoutType;

        public PdfGeneratorPage()
        {
            InitializeCustomComponent();
            InitializeOpenImageDialog();
        }

        private void InitializeCustomComponent()
        {
            InitializeComponent();

            this.ChooseImageFitStyleListBox.ValueMember = "Key";
            this.ChooseImageFitStyleListBox.DisplayMember = "Value";
            this.ChooseImageFitStyleListBox.DataSource = EnumHelper.GetEnumValueDescriptionPairs<ImageFitType>();

            this.ChooseLayoutListBox.ValueMember = "Key";
            this.ChooseLayoutListBox.DisplayMember = "Value";
            this.ChooseLayoutListBox.DataSource = EnumHelper.GetEnumValueDescriptionPairs<LayoutType>();

            this.ChoosePaperSizeListBox.ValueMember = "Key";
            this.ChoosePaperSizeListBox.DisplayMember = "Value";
            this.ChoosePaperSizeListBox.DataSource = EnumHelper.GetEnumValueDescriptionPairs<PaperSizeType>();
        }

        private void InitializeOpenImageDialog()
        {
            // Set the file dialog to filter for graphics files.
            this.openImageDialog.Filter =
                "Images (*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF|" +
                "All files (*.*)|*.*";

            //  Allow the user to select multiple images.
            this.openImageDialog.Multiselect = true;

            this.openImageDialog.Title = "My Image Browser";
        }

        private void SelectImages_Click(object sender, EventArgs e)
        {
            DialogResult dr = this.openImageDialog.ShowDialog();
            if (dr == DialogResult.OK)
            {
                int countImages = 0;
                ClearPreviousPictureBox();

                // Read the files
                foreach (string fileName in openImageDialog.FileNames)
                {
                    try
                    {
                        ShowImage(fileName, countImages);
                        countImages++;
                    }
                    catch (Exception ex)
                    {
                        // Could not load the image - probably related to Windows file system permissions.
                        MessageBox.Show("Cannot display the image: " + fileName.Substring(fileName.LastIndexOf('\\'))
                            + ". You may not have permission to read the file, or " +
                            "it may be corrupt.\n\nReported error: " + ex.Message);
                    }
                }
            }
        }

        private void MergeImages_Click(object sender, EventArgs e)
        {
            if (pictureBoxes == null || !pictureBoxes.Any())
            {
                Prompt.PromptAlertDialog("Alert", "You must select at least one image.");
                return;
            }

            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string uniqueSuffix = DateTimeOffset.Now.ToUnixTimeSeconds().ToString();
            FileStream fileStream = File.Create(desktopPath + @"\Merged_" + uniqueSuffix + ".pdf");
            Document document = new Document(GetPaperSize(), 0, 0, 0, 0);

            using (var pdfWriter = PdfWriter.GetInstance(document, fileStream))
            {
                document.Open();

                foreach (PictureBox pb in pictureBoxes)
                {
                    string imagePath = (string)pb.Image.Tag;
                    using (FileStream imageStream = File.OpenRead(imagePath))
                    {
                        if (ChooseLayoutListBox.SelectedIndex == (int)LayoutType.onePerPage ||
                            ChooseImageFitStyleListBox.SelectedIndex == (int)ImageFitType.fill)
                        {
                            document.NewPage();
                        }
                        
                        iTextSharp.text.Image image = GetProperSizedImage(imageStream, document.PageSize);

                        document.Add(image);
                    }
                }
                document.Close();
                fileStream.Close();
            }

            // Prompt success message
            DialogResult promptValue = Prompt.PromptConfirmationDialog(
                "Images are merged",
                "Congradulations! a PDF file is generated and downloaded to your desktop.");
            if (promptValue == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void ShowImage(string filePath, int imageIndex)
        {
            int x = HorizontalMargin;
            int y = VerticalMargin;
            if (imageIndex % NumImagesOnARow != 0)
            {
                x += (imageIndex % NumImagesOnARow) * (HorizontalMargin + PictureBoxWidth);
            }
            if (imageIndex / NumImagesOnARow != 0)
            {
                y += (imageIndex / NumImagesOnARow) * (VerticalMargin + PictureBoxHeight);
            }

            PictureBox pb = new PictureBox
            {
                Size = new Size(PictureBoxWidth, PictureBoxHeight),
                Location = new Point(x, y),
                SizeMode = PictureBoxSizeMode.StretchImage,
                AllowDrop = true
            };
            pb.MouseDown += new MouseEventHandler(PictureBox_MouseDown);
            pb.DragEnter += new DragEventHandler(PictureBox_DragEnter);
            pb.DragDrop += new DragEventHandler(PictureBox_DragDrop);

            pb.Load(filePath);

            this.Controls.Add(pb);
            pictureBoxes.Add(pb);

            pictureBoxes[imageIndex].Image.Tag = filePath;
        }

        private void ClearPreviousPictureBox()
        {
            foreach (PictureBox pb in pictureBoxes)
            {
                this.Controls.Remove(pb);
            }
            pictureBoxes.Clear();
        }

        private void ChooseImageFitStyleListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ChooseImageFitStyleListBox.SelectedIndex == (int)ImageFitType.fill)
            {
                this.ChooseLayoutListBox.Enabled = false;
            }
            else
            {
                this.ChooseLayoutListBox.Enabled = true;
            }
        }

        private iTextSharp.text.Image GetProperSizedImage(FileStream imageStream, iTextSharp.text.Rectangle pageSize)
        {
            iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(imageStream);

            if (ChooseImageFitStyleListBox.SelectedIndex == (int)ImageFitType.fill)
            {
                image.SetAbsolutePosition(0, 0);
                image.ScaleAbsolute(pageSize.Width, pageSize.Height);
            }
            else if (ChooseImageFitStyleListBox.SelectedIndex == (int)ImageFitType.contain)
            {
                image.Alignment = Element.ALIGN_LEFT;
                if (image.Width > pageSize.Width || image.Height > pageSize.Height)
                {
                    image.ScaleToFit(pageSize.Width, pageSize.Height);
                }
            }
            return image;
        }

        private iTextSharp.text.Rectangle GetPaperSize()
        {
            iTextSharp.text.Rectangle rectangle = new iTextSharp.text.Rectangle(0, 0);
            switch (ChoosePaperSizeListBox.SelectedIndex)
            {
                case (int)PaperSizeType.usLetter:
                    rectangle = new iTextSharp.text.Rectangle(563, 750);
                    break;
                case (int)PaperSizeType.a4:
                    rectangle = new iTextSharp.text.Rectangle(595, 842);
                    break;
            }

            return rectangle;
        }

        private void PictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            PictureBox dragFromPictureBox = (PictureBox)sender;
            System.Drawing.Image img = dragFromPictureBox.Image;

            if (img == null) return;
            if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move)
            {
                dragFromPictureBox.Image = dragToPictureBoxImage;
            }
        }

        private void PictureBox_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
            {
                e.Effect = DragDropEffects.Move;
            }
        }

        private void PictureBox_DragDrop(object sender, DragEventArgs e)
        {
            PictureBox dragToPictureBox = (PictureBox)sender;
            dragToPictureBoxImage = dragToPictureBox.Image;

            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            dragToPictureBox.Image = bmp;
        }
    }
}
