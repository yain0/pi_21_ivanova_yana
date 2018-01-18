using System;
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
            color = Color.Yellow;
            dopColor = Color.Green;
            maxSpeed = 150;
            maxCountPass = 4;
            weight = 1500;
            button1.BackColor = color;
            button2.BackColor = dopColor;
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
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

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

        private void button3_Click(object sender, EventArgs e)
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

        private void button4_Click(object sender, EventArgs e)
        {
            inter = new NewBoat(100, 50, 1000, color, true,true, dopColor);
            Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Graphics gr = Graphics.FromImage(bmp);
            inter.drawBoat(gr);
            pictureBox1.Image = bmp;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            inter = new NewBoat(150, 4, 1000, Color.Black, true,true, Color.Yellow);
            Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Graphics gr = Graphics.FromImage(bmp);
            inter.drawBoat(gr);
            pictureBox1.Image = bmp;
        }
    }
}
