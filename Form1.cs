using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Bitmap bitmap;
        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "JPG|*.jpg|PNG|*.png|BMP|*.bmp";
            if (fileDialog.ShowDialog()==DialogResult.OK)
            {
                bitmap = new Bitmap(fileDialog.FileName);
                pictureBox1.Image = bitmap;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Filter();
        }

        void Filter()
        {
            DateTime first = DateTime.Now;
            int h = bitmap.Height;
            int w = bitmap.Width;
            Bitmap bitmap2 = new Bitmap(w, h);

            for (int i = 0; i < h; i++)
            {
                for (int j = 0; j < w; j++)
                {
                    Color c = bitmap.GetPixel(j, i);
                    c = Color.FromArgb(c.G, c.B, c.R);
                    bitmap2.SetPixel(j, i, c);
                }
            }
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.Image = bitmap2;
            DateTime second = DateTime.Now;
            MessageBox.Show((second - first).ToString());
        }

        private void button3_Click(object sender, EventArgs e)
        {
        
            Bitmap bitmap2 = new Bitmap(bitmap);
            Task task = new Task(new Action(() => {

                Filter();
            }));
            task.Start();            
        }
    }
}
