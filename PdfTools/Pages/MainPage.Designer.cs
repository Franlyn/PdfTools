namespace PdfTools.Pages
{
    partial class MainPage
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
            this.PdfGeneratorButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // PdfGeneratorButton
            // 
            this.PdfGeneratorButton.Location = new System.Drawing.Point(724, 332);
            this.PdfGeneratorButton.Name = "PdfGeneratorButton";
            this.PdfGeneratorButton.Size = new System.Drawing.Size(260, 118);
            this.PdfGeneratorButton.TabIndex = 0;
            this.PdfGeneratorButton.Text = "Generate PDF with Images ";
            this.PdfGeneratorButton.UseVisualStyleBackColor = true;
            this.PdfGeneratorButton.Click += new System.EventHandler(this.generatePdf_Click);
            // 
            // MainPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1810, 872);
            this.Controls.Add(this.PdfGeneratorButton);
            this.Name = "MainPage";
            this.Text = "Main";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button PdfGeneratorButton;
    }
}

