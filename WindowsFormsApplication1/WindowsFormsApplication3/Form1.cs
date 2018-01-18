using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication3
{
    public partial class Form1 : Form
    {
        Prichal prichal;
        public Form1()
        {
            InitializeComponent();
            prichal = new Prichal();
            Draw();
        }
        /*private void pictureBox1_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Graphics gr = Graphics.FromImage(bmp);
            prichal.Draw(gr, pictureBox1.Width, pictureBox1.Height);
            pictureBox1.Image = bmp;

        }*/
        private void Draw()
        {
            Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Graphics gr = Graphics.FromImage(bmp);
            prichal.Draw(gr, pictureBox1.Width, pictureBox1.Height);
            pictureBox1.Image = bmp;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ColorDialog dialog = new ColorDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                var boat = new Boat(100, 4, 1000, dialog.Color);
                int place = prichal.PutBoatPrichal(boat);
                Draw();
                MessageBox.Show("Ваше место: " + place);
                
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            ColorDialog dialog = new ColorDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                ColorDialog dialogDop = new ColorDialog();
                if (dialogDop.ShowDialog() == DialogResult.OK)
                {
                    var boat = new NewBoat(100, 4, 1000, dialog.Color, true, true, dialogDop.Color);
                    int place = prichal.PutBoatPrichal(boat);
                    Draw();
                    MessageBox.Show("Ваше место: " + place);
                }
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (maskedTextBox1.Text != "")
            {
                var boat = prichal.GetBoatPrichal(Convert.ToInt32(maskedTextBox1.Text));

                Bitmap bmp = new Bitmap(pictureBox2.Width, pictureBox2.Height);
                Graphics gr = Graphics.FromImage(bmp);
                boat.setPosition(5, 5);
                boat.drawBoat(gr);
                pictureBox2.Image = bmp;
                Draw();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }

}
