using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        Image imgOriginal1;
        Image imgOriginal2;
        public Form1()
        {
            InitializeComponent();
            pictureBox1.Image = Properties.Resources.Tulips;
            //textBox1.Text = nameof(Properties.Resources.Tulips);
        }

        private void Preset_Image_Click(object sender, EventArgs e)
        {
            var model = new window_model();
            OpenFileDialog ofd = new OpenFileDialog();
            string fileExe = model.fileExe;
            ofd.Filter = fileExe;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                // display image in picture box  
                //pictureBox1.Image = new Bitmap(ofd.FileName);
                //string tulips = "Tulips";
                // image file path
                string result;
                textBox1.Text = ofd.FileName;
                result = Path.GetFileName(ofd.FileName);
                textBox1.Text = result;
                // display image in panel1_Paint 
                panel1.AutoScroll = true;
                panel3.AutoScroll = true;
                //pictureBox1.Image = Image.FromFile(ofd.FileName);
                pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
                pictureBox2.Image = Image.FromFile(ofd.FileName);
                pictureBox2.SizeMode = PictureBoxSizeMode.AutoSize;
                imgOriginal1 = pictureBox1.Image;
                imgOriginal2 = pictureBox2.Image;

                //MessageBox.Show(model.testMsg);
            }
        }
        //Zoom image file
        Image Zoom(Image img, Size size)
        {
            Bitmap bmp = new Bitmap(img, img.Width + (img.Width * size.Width / 100), img.Height + (img.Height * size.Height / 100));
            Graphics g = Graphics.FromImage(bmp);
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            return bmp;
        }

        private void trackBar1_Scroll_1(object sender, EventArgs e)
        {
            try
            {
                if (trackBar1.Value > 0)
                {
                    pictureBox1.Image = Zoom(imgOriginal1, new Size(trackBar1.Value, trackBar1.Value));
                    pictureBox2.Image = Zoom(imgOriginal2, new Size(trackBar1.Value, trackBar1.Value));
                }
            }
            catch (Exception)
            {
                var model = new window_model();
                MessageBox.Show(model.badAlert);
                trackBar1.SmallChange = 2;
            }
        }
        public void getResponse(string anyResult, int counter, string imgName){
            string[] row = new string[] { imgName, anyResult };
            dataGridView1.Rows.Add(row);
        }

        private void passButton_Click(object sender, EventArgs e){
            string passResult = "PASS";
            int counter = 1;
            string imgName = textBox1.Text;
            getResponse(passResult, counter, imgName);
        }

        private void failButton_Click(object sender, EventArgs e){
            string failResult = "FAIL";
            int counter = 1;
            string imgName = textBox1.Text;
            getResponse(failResult, counter, imgName);
        }

        public void getResponse(){
            var model = new window_model();

            DialogResult dialogResult = MessageBox.Show(model.clickMsg, model.LD_Compare, MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                string anyResult = "PASS";
                string[] row = new string[] { "Some LD Number", anyResult };
                dataGridView1.Rows.Add(row);
            }
            else if (dialogResult == DialogResult.No)
            {
                string anyResult = "FAIL";
                string[] row = new string[] { "Some LD Number", anyResult };
                dataGridView1.Rows.Add(row);
            }
            //MessageBox.Show("Click pass or fail");
        }
        private void oDImage_Click(object sender, EventArgs e){
            var model = new window_model();
            passButton.Enabled = false;
            failButton.Enabled = false;
            string[] imageName = new string[8] { "Desert", "Chrysanthemum", "Jellyfish", "Koala", "Lighthouse", "Penguins", "Hydrangeas", "Koala" };
            int i = 0;
            int[] values = new int[8] { 0,1,2,3,4,5,6,7 };

            //string tulips = "Tulips";
            int MAX = values.Length;
            do
            {
                int value = values[i];
                switch (value)
                {
                    case 0:
                        pictureBox2.Image = Image.FromFile(model.rootImage + imageName[i] + model.exe);
                        string imgName = textBox1.Text;
                        getResponse();
                        //MessageBox.Show("hi");
                        break;
                    case 1:
                        pictureBox2.Image = Image.FromFile(model.rootImage + imageName[i] + model.exe);
                        getResponse();
                        break;
                    case 2:
                        pictureBox2.Image = Image.FromFile(model.rootImage + imageName[i] + model.exe);
                        getResponse();
                        break;
                    case 3:
                        pictureBox2.Image = Image.FromFile(model.rootImage + imageName[i] + model.exe);
                        getResponse();
                        break;
                    case 4:
                        pictureBox2.Image = Image.FromFile(model.rootImage + imageName[i] + model.exe);
                        getResponse();
                        break;
                    case 5:
                        pictureBox2.Image = Image.FromFile(model.rootImage + imageName[i] + model.exe);
                        break;
                    case 6:
                        pictureBox2.Image = Image.FromFile(model.rootImage + imageName[i] + model.exe);
                        getResponse();
                        break;
                    case 7:
                        pictureBox2.Image = Image.FromFile(model.rootImage + imageName[i] + model.exe);
                        getResponse();
                        break;
                }
                i++;
            } while (i < MAX);
            //pictureBox2.Image = Image.FromFile(model.rootImage + tulips + model.space + 2 + model.exe);
        }

        private void Form1_Validating(object sender, CancelEventArgs e){

        }
    }
}
