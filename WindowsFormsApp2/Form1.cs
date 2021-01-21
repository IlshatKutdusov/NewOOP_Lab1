using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public static bool form2closed = false;
        public static int redcolor = 0, greencolor = 0, bluecolor = 0;

        private Point? _Previous = null;

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void newImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                SaveFileDialog SaveFD = new SaveFileDialog();
                SaveFD.Title = "Save image ass...";
                SaveFD.OverwritePrompt = true;
                SaveFD.CheckPathExists = true;
                SaveFD.Filter = "Image Files(*.jpg)|*.jpg|Image Files(*.png)|*.png";
                if (SaveFD.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        pictureBox1.Image.Save(SaveFD.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                    }
                    catch
                    {
                        MessageBox.Show("Image don't saved.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Image is empty.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            _Previous = e.Location;
            pictureBox1_MouseMove(sender, e);
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (_Previous != null)
            {
                if (pictureBox1.Image == null)
                {
                    Bitmap newbmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                    using (Graphics grph = Graphics.FromImage(newbmp))
                    {
                        grph.Clear(Color.White);
                    }
                    pictureBox1.Image = newbmp;
                }
                using (Graphics grph = Graphics.FromImage(pictureBox1.Image))
                {
                    grph.DrawLine(new Pen(Color.FromArgb(redcolor, greencolor, bluecolor)), _Previous.Value, e.Location);
                }
                pictureBox1.Invalidate();
                _Previous = e.Location;
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            _Previous = null;
        }

        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 colorsel = new Form2(this);
            colorsel.Show();
            colorToolStripMenuItem.Enabled = false;
            form2closed = false;
        }

        private void Form1_Activated(object sender, EventArgs e)
        {
            if (form2closed == true)
            {
                colorToolStripMenuItem.Enabled = true;
            }
        }
    }
}
