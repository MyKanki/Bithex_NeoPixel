using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bithex_NeoPixel
{
    public partial class Form1 : Form
    {
        public Bitmap image1;
        public Form1()
        {
            InitializeComponent();
        }

        private void hakkındaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bu Program MyKanki Tarafından 24/06/2021 tarinde yazılmıştır. \n" +
                "Programın amacı Neopixel 16x16 led sistemi için bitmap resim kodunu 16 bitlik" +
                "hex koduna dönüştürmeye yarar. \n" +
                "Tüm Hakları MyKanki ye aittir ve onun güvencesi altındadır. \n" +
                "Version 1.0");
        }

        private void açBitmap24ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.Filter = "Bitmap24 Dosyası (.bmp)|*.bmp";
            file.FilterIndex = 1;
            file.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            file.RestoreDirectory = true;
            file.CheckFileExists = false;
            file.Title = "Bitmap24 Dosyası Seçiniz...";
            file.Multiselect = false;

            if (file.ShowDialog() == DialogResult.OK)
            {
                string DosyaYolu = file.FileName;
                string DosyaAdi = file.SafeFileName;
                try
                {
                    // Retrieve the image.
                    image1 = new Bitmap(DosyaYolu, true);

                    // Loop through the images pixels to reset color.

                    for (int str = 0; str < 16; str++)
                    {
                        if (str % 2 == 0)
                        {
                            for (int stn = 0; stn < 16; stn++)
                            {
                                Color pixelColor = image1.GetPixel(str, stn);
                                string hexValue = pixelColor.R.ToString("X2") + pixelColor.G.ToString("X2") + pixelColor.B.ToString("X2");
                                richTextBox1.AppendText("0x" + hexValue + ",");
                            }
                        }
                        else
                        {
                            for (int stn = 15; stn >= 0; stn--)
                            {
                                Color pixelColor = image1.GetPixel(str, stn);
                                string hexValue = pixelColor.R.ToString("X2") + pixelColor.G.ToString("X2") + pixelColor.B.ToString("X2");
                                richTextBox1.AppendText("0x" + hexValue + ",");
                            }
                        }
                        richTextBox1.AppendText("\n");
                    }
                    pictureBox1.Image = image1;
                    if (image1.PixelFormat.ToString() != "Format24bppRgb")
                    {
                        MessageBox.Show("Resim Formatı 24 bitlik bitmap formatı değil renk sorunu yaşayabilirsiniz!");
                    }

                    //label1.Text = "Pixel format: " + image1.PixelFormat.ToString();
                }
                catch (ArgumentException)
                {
                    MessageBox.Show("There was an error. Check the path to the image file.");
                }
            }
        }

        private void çıkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
