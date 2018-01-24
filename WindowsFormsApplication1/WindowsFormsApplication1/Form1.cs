using System;
using NLog;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        Color color;
        Color dopColor;
        int maxSpeed;
        int maxCountPass;
        int weight;
        private Transport inter;

        public Form1()
        {
            InitializeComponent();
            
        }
        private bool checkFields()
        {
            if (!int.TryParse(textBox1.Text, out maxSpeed))
            {
                return false;
            }
            if (!int.TryParse(textBox2.Text, out maxCountPass))
            {
                return false;
            }
            if (!int.TryParse(textBox3.Text, out weight))
            {
                return false;
            }
            return true;
        }
        private void button3_Click_1(object sender, EventArgs e)
        {
            if (checkFields())
            {
                inter = new Boat(maxSpeed, maxCountPass, weight, color);
                Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                Graphics gr = Graphics.FromImage(bmp);
                inter.drawBoat(gr);
                pictureBox1.Image = bmp;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkFields())
            {
                inter = new NewBoat(maxSpeed, maxCountPass, weight, color, checkBox1.Checked, checkBox2.Checked, dopColor);
                Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                Graphics gr = Graphics.FromImage(bmp);
                inter.drawBoat(gr);
                pictureBox1.Image = bmp;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            inter = new NewBoat(100, 50, 1000, color, true, true, dopColor);
            Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Graphics gr = Graphics.FromImage(bmp);
            inter.drawBoat(gr);
            pictureBox1.Image = bmp;
        }

        private void button5_Click(object sender, EventArgs e)
        {
           
            if (inter != null)
            {
                Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                Graphics gr = Graphics.FromImage(bmp);
                inter.moveBoat(gr);
                pictureBox1.Image = bmp;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                color = cd.Color;
                button1.BackColor = color;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                dopColor = cd.Color;
                button2.BackColor = dopColor;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkFields())
            {
                inter = new NewBoat(maxSpeed, maxCountPass, weight, color, checkBox1.Checked, checkBox2.Checked, dopColor);
                Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                Graphics gr = Graphics.FromImage(bmp);
                inter.drawBoat(gr);
                pictureBox1.Image = bmp;
            }
        }
    }
}
