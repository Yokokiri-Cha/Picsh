using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Picsh
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            OpenFileDialog openFile1 = new OpenFileDialog();

            // Initialize the OpenFileDialog to look for text files.
            openFile1.Filter = "画像データ|*.jpg|画像データ|*.png|図|*.gif|画像データ|*.bmp|画像データ|*.tif";

            // Check if the user selected a file from the OpenFileDialog.
            if (openFile1.ShowDialog() == System.Windows.Forms.DialogResult.OK)

                // Load the contents of the file into a RichTextBox control.
                pictureBox1.Load(openFile1.FileName);
            this.Text = "Picsh";








        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string[] files = System.Environment.GetCommandLineArgs();


            if (files.Length > 1)
            {
                
                for (int i = 1; i < files.Length; i++)
                {
                    pictureBox1.ImageLocation = files[i] ;
                }
            }
        }

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            
            if (!e.Data.GetDataPresent(DataFormats.FileDrop)) return;

            
            foreach (var filePath in (string[])e.Data.GetData(DataFormats.FileDrop))
            {
                pictureBox1.ImageLocation = filePath;

            }


        }

        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {

                e.Effect = DragDropEffects.All;
            }
            else
            {

                MessageBox.Show("ファイルのみドラッグアンドドロップが可能です。");
            }

        }
    }
}
