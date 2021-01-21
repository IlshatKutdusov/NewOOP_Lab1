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
    public partial class Form2 : Form
    {
        Form1 form1 { get; set; }
        public Form2(Form1 form1)
        {
            InitializeComponent();
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form1.form2closed = true;
        }

        private void numericUpDown1_Validated(object sender, EventArgs e)
        {
            trackBar1.Value = Convert.ToInt16(numericUpDown1.Value);
            Form1.redcolor = trackBar1.Value;
            button1.BackColor = Color.FromArgb(Form1.redcolor, Form1.greencolor, Form1.bluecolor);
        }

        private void numericUpDown2_Validated(object sender, EventArgs e)
        {
            trackBar2.Value = Convert.ToInt16(numericUpDown2.Value);
            Form1.greencolor = trackBar2.Value;
            button1.BackColor = Color.FromArgb(Form1.redcolor, Form1.greencolor, Form1.bluecolor);
        }

        private void numericUpDown3_Validated(object sender, EventArgs e)
        {
            trackBar3.Value = Convert.ToInt16(numericUpDown3.Value);
            Form1.bluecolor = trackBar3.Value;
            button1.BackColor = Color.FromArgb(Form1.redcolor, Form1.greencolor, Form1.bluecolor);
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            numericUpDown1.Value = trackBar1.Value;
            Form1.redcolor = trackBar1.Value;
            button1.BackColor = Color.FromArgb(Form1.redcolor, Form1.greencolor, Form1.bluecolor);
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            numericUpDown2.Value = trackBar2.Value;
            Form1.greencolor = trackBar2.Value;
            button1.BackColor = Color.FromArgb(Form1.redcolor, Form1.greencolor, Form1.bluecolor);
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            numericUpDown3.Value = trackBar3.Value;
            Form1.bluecolor = trackBar3.Value;
            button1.BackColor = Color.FromArgb(Form1.redcolor, Form1.greencolor, Form1.bluecolor);
        }
    }
}
