using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PdfTools.Services
{
    public class Prompt
    {
        public static DialogResult PromptAlertDialog(string title, string text)
        {
            Form promptForm = new Form()
            {
                Width = 500,
                Height = 300,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                StartPosition = FormStartPosition.CenterScreen,
                Text = title
            };

            TextBox textBox = new TextBox() { Left = 50, Top = 30, Width = 400, Text = text, ReadOnly = true, Multiline = true, BorderStyle = 0 };
            Button confirmed = new Button() { Text = "Ok", Left = 400, Width = 80, Top = 220, DialogResult = DialogResult.OK };
            confirmed.Click += (sender, e) => { promptForm.Close(); };

            promptForm.Controls.Add(confirmed);
            promptForm.Controls.Add(textBox);
            promptForm.AcceptButton = confirmed;

            return promptForm.ShowDialog();
        }

        public static DialogResult PromptConfirmationDialog(string title, string text)
        {
            Form promptForm = new Form()
            {
                Width = 500,
                Height = 300,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                StartPosition = FormStartPosition.CenterScreen,
                Text = title
            };

            TextBox textBox = new TextBox() { Left = 50, Top = 30, Width = 400, Text = text, ReadOnly = true, Multiline = true, BorderStyle = 0 };

            Button exitProgram = new Button() { Text = "Exit", Left = 400, Width = 80, Top = 220, DialogResult = DialogResult.OK };
            exitProgram.Click += (sender, e) => { promptForm.Close(); };

            Button goBack = new Button() { Text = "Back", Left = 300, Width = 80, Top = 220, DialogResult = DialogResult.Cancel };
            goBack.Click += (sender, e) => { promptForm.Close(); };

            promptForm.Controls.Add(exitProgram);
            promptForm.Controls.Add(goBack);
            promptForm.Controls.Add(textBox);
            promptForm.AcceptButton = exitProgram;

            return promptForm.ShowDialog();
        }
    }
}
