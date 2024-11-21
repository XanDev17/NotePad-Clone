using System;
using System.Drawing.Printing;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextEditor
{
    public partial class Form1 : Form
    {
        private string filePath =  string.Empty;
        private float fontSize = 12.0F;
       
        public Form1()
        {
            InitializeComponent();
            richTextBox1.Font = new Font("Arial", fontSize);
        }

        private void alignLeftToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Left;

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void alignRightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Right;
        }

        private void alignCenterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Center;
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(filePath))
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Rich Text Files (*.rtf)|*.rtf";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    filePath = saveFileDialog.FileName;
                }
            }

            if (!string.IsNullOrEmpty(filePath))
            {
                richTextBox1.SaveFile(filePath, RichTextBoxStreamType.RichText);
                MessageBox.Show("File saved successfully!");
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Application.Exit();
           
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Rich Text Files (*.rtf)|*.rtf";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                filePath = openFileDialog.FileName;
                richTextBox1.LoadFile(filePath, RichTextBoxStreamType.RichText);
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Rich Text Files (*.rtf)|*.rtf";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                filePath = saveFileDialog.FileName;
                richTextBox1.SaveFile(filePath, RichTextBoxStreamType.RichText);
                MessageBox.Show("File saved successfully!");
            }
        }

        private void increaseToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            if (richTextBox1.SelectionLength > 0)
            {
                richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont, FontStyle.Regular);
                richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont.FontFamily, richTextBox1.SelectionFont.Size + 2.0F);
            }
        }

        private void decreaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionLength > 0)
            {
                richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont, FontStyle.Regular);
                if (richTextBox1.SelectionFont.Size > 6.0F)
                {
                    richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont.FontFamily, richTextBox1.SelectionFont.Size - 2.0F);
                }
            }
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {

            richTextBox1.Undo();
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Redo();
        }

        private void fontSizeToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void chkDarkMode_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDarkMode.Checked)
                
            {
                // Dark Mode
                chkDarkMode.ForeColor = Color.White;
                richTextBox1.BackColor = Color.FromArgb(40, 40, 40);
                richTextBox1.ForeColor = Color.White;
                this.BackColor = Color.FromArgb(32, 32, 32);
            }
            else
            {
                chkDarkMode.BackColor = Color.Gray;
                // Light Mode
                richTextBox1.BackColor = Color.White;
                richTextBox1.ForeColor = Color.Black;
                this.BackColor = Color.White;
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

            
        }
    }
}
