using PdfTools.Models;
using System;

namespace PdfTools.Pages
{
    partial class PdfGeneratorPage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SelectImagesButton = new System.Windows.Forms.Button();
            this.openImageDialog = new System.Windows.Forms.OpenFileDialog();
            this.MergeImagesButton = new System.Windows.Forms.Button();
            this.ChooseImageFitStyleListBox = new System.Windows.Forms.ListBox();
            this.ChooseImageFitStyleLabel = new System.Windows.Forms.Label();
            this.ChooseLayoutLabel = new System.Windows.Forms.Label();
            this.ChooseLayoutListBox = new System.Windows.Forms.ListBox();
            this.ChoosePaperSizeLabel = new System.Windows.Forms.Label();
            this.ChoosePaperSizeListBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // SelectImagesButton
            // 
            this.SelectImagesButton.Location = new System.Drawing.Point(1769, 21);
            this.SelectImagesButton.Name = "SelectImagesButton";
            this.SelectImagesButton.Size = new System.Drawing.Size(230, 98);
            this.SelectImagesButton.TabIndex = 0;
            this.SelectImagesButton.Text = "Select Images";
            this.SelectImagesButton.UseVisualStyleBackColor = true;
            this.SelectImagesButton.Click += new System.EventHandler(this.SelectImages_Click);
            // 
            // openImageDialog
            // 
            this.openImageDialog.FileName = "openImageDialog";
            // 
            // MergeImagesButton
            // 
            this.MergeImagesButton.Location = new System.Drawing.Point(1769, 189);
            this.MergeImagesButton.Name = "MergeImagesButton";
            this.MergeImagesButton.Size = new System.Drawing.Size(230, 97);
            this.MergeImagesButton.TabIndex = 1;
            this.MergeImagesButton.Text = "Merge Images";
            this.MergeImagesButton.UseVisualStyleBackColor = true;
            this.MergeImagesButton.Click += new System.EventHandler(this.MergeImages_Click);
            // 
            // ChooseImageFitStyleListBox
            // 
            this.ChooseImageFitStyleListBox.AccessibleName = "";
            this.ChooseImageFitStyleListBox.AllowDrop = true;
            this.ChooseImageFitStyleListBox.FormattingEnabled = true;
            this.ChooseImageFitStyleListBox.ItemHeight = 24;
            this.ChooseImageFitStyleListBox.Location = new System.Drawing.Point(1769, 371);
            this.ChooseImageFitStyleListBox.Name = "ChooseImageFitStyleListBox";
            this.ChooseImageFitStyleListBox.Size = new System.Drawing.Size(230, 76);
            this.ChooseImageFitStyleListBox.TabIndex = 2;
            this.ChooseImageFitStyleListBox.SelectedIndexChanged += new System.EventHandler(this.ChooseImageFitStyleListBox_SelectedIndexChanged);
            // 
            // ChooseImageFitStyleLabel
            // 
            this.ChooseImageFitStyleLabel.AutoSize = true;
            this.ChooseImageFitStyleLabel.Location = new System.Drawing.Point(1764, 343);
            this.ChooseImageFitStyleLabel.Name = "ChooseImageFitStyleLabel";
            this.ChooseImageFitStyleLabel.Size = new System.Drawing.Size(129, 25);
            this.ChooseImageFitStyleLabel.TabIndex = 3;
            this.ChooseImageFitStyleLabel.Text = "Choose a Fit:";
            // 
            // ChooseLayoutLabel
            // 
            this.ChooseLayoutLabel.AutoSize = true;
            this.ChooseLayoutLabel.Location = new System.Drawing.Point(1764, 491);
            this.ChooseLayoutLabel.Name = "ChooseLayoutLabel";
            this.ChooseLayoutLabel.Size = new System.Drawing.Size(176, 25);
            this.ChooseLayoutLabel.TabIndex = 5;
            this.ChooseLayoutLabel.Text = "Choose the layout:";
            // 
            // ChooseLayoutListBox
            // 
            this.ChooseLayoutListBox.AccessibleName = "";
            this.ChooseLayoutListBox.AllowDrop = true;
            this.ChooseLayoutListBox.FormattingEnabled = true;
            this.ChooseLayoutListBox.ItemHeight = 24;
            this.ChooseLayoutListBox.Location = new System.Drawing.Point(1769, 519);
            this.ChooseLayoutListBox.Name = "ChooseLayoutListBox";
            this.ChooseLayoutListBox.Size = new System.Drawing.Size(230, 76);
            this.ChooseLayoutListBox.TabIndex = 4;
            // 
            // ChoosePaperSizeLabel
            // 
            this.ChoosePaperSizeLabel.AutoSize = true;
            this.ChoosePaperSizeLabel.Location = new System.Drawing.Point(1764, 644);
            this.ChoosePaperSizeLabel.Name = "ChoosePaperSizeLabel";
            this.ChoosePaperSizeLabel.Size = new System.Drawing.Size(214, 25);
            this.ChoosePaperSizeLabel.TabIndex = 7;
            this.ChoosePaperSizeLabel.Text = "Choose the paper size:";
            // 
            // ChoosePaperSizeListBox
            // 
            this.ChoosePaperSizeListBox.AccessibleName = "";
            this.ChoosePaperSizeListBox.AllowDrop = true;
            this.ChoosePaperSizeListBox.FormattingEnabled = true;
            this.ChoosePaperSizeListBox.ItemHeight = 24;
            this.ChoosePaperSizeListBox.Location = new System.Drawing.Point(1769, 672);
            this.ChoosePaperSizeListBox.Name = "ChoosePaperSizeListBox";
            this.ChoosePaperSizeListBox.Size = new System.Drawing.Size(230, 76);
            this.ChoosePaperSizeListBox.TabIndex = 6;
            // 
            // PdfGeneratorPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2027, 922);
            this.Controls.Add(this.ChoosePaperSizeLabel);
            this.Controls.Add(this.ChoosePaperSizeListBox);
            this.Controls.Add(this.ChooseLayoutLabel);
            this.Controls.Add(this.ChooseLayoutListBox);
            this.Controls.Add(this.ChooseImageFitStyleLabel);
            this.Controls.Add(this.ChooseImageFitStyleListBox);
            this.Controls.Add(this.MergeImagesButton);
            this.Controls.Add(this.SelectImagesButton);
            this.Name = "PdfGeneratorPage";
            this.Text = "PdfGeneratorPage";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button SelectImagesButton;
        private System.Windows.Forms.OpenFileDialog openImageDialog;
        private System.Windows.Forms.Button MergeImagesButton;
        private System.Windows.Forms.ListBox ChooseImageFitStyleListBox;
        private System.Windows.Forms.Label ChooseImageFitStyleLabel;
        private System.Windows.Forms.Label ChooseLayoutLabel;
        private System.Windows.Forms.ListBox ChooseLayoutListBox;
        private System.Windows.Forms.Label ChoosePaperSizeLabel;
        private System.Windows.Forms.ListBox ChoosePaperSizeListBox;
    }
}