using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace görüntü
{
    public partial class Form1 : Form
    {
        islemler islemler = new islemler();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openfile = new OpenFileDialog();
            if (openfile.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(openfile.FileName);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            if (comboBox1.SelectedItem.ToString() == "negatif")
            {
                Bitmap gelenresim =
                islemler.negative((Bitmap)pictureBox1.Image);
                pictureBox2.Image = gelenresim;
            }
            else if (comboBox1.SelectedItem.ToString() == "gri")
            {
                Bitmap gelenresim2 =
                islemler.grey((Bitmap)pictureBox1.Image);
                pictureBox2.Image = gelenresim2;
            }
            else if (comboBox1.SelectedItem.ToString() == "eşikleme")
            {
                Bitmap gelenresim3 =
                islemler.whiteblack((Bitmap)pictureBox1.Image);
                pictureBox2.Image = gelenresim3;
            }
            else if (comboBox1.SelectedItem.ToString() == "parlaklık")
            {
                Bitmap gelenresim3 =
                islemler.parlaklik((Bitmap)pictureBox1.Image,trackBar1.Value);
                pictureBox2.Image = gelenresim3;
            }
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {

        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                if (comboBox1.SelectedItem.ToString() == "mausemodu")
                {
                    Bitmap bit = (Bitmap)pictureBox1.Image;

                    Color color = bit.GetPixel(e.X, e.Y);
                    pictureBox2.BackColor = color;
                }
            }
            
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.ToString() == "mausemodu")
            {
                pictureBox1.SizeMode = PictureBoxSizeMode.Normal;
                pictureBox2.SizeMode = PictureBoxSizeMode.Normal;
            }
            else
            {
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox2.BackColor = Color.Lavender;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
        }
    }
}
