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


        Prichal prichal;
        public Form1()
        {
            InitializeComponent();
            prichal = new Prichal(5);
            for (int i = 1; i < 6; i++)
            {
                listBox1.Items.Add("Уровень " + i);
            }
            listBox1.SelectedIndex = prichal.getCurrentLevel;

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
            if (listBox1.SelectedIndex > -1)
            {
                Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                Graphics gr = Graphics.FromImage(bmp);
                prichal.Draw(gr, pictureBox1.Width, pictureBox1.Height);
                pictureBox1.Image = bmp;
            }

        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {

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
            if (listBox1.SelectedIndex > -1)
            {
                string level = listBox1.Items[listBox1.SelectedIndex].ToString();
                if (maskedTextBox1.Text != "")
                {
                    Transport boat = prichal.GetBoatPrichal(Convert.ToInt32(maskedTextBox1.Text));
                    if (boat != null)
                    {
                        Bitmap bmp = new Bitmap(pictureBox2.Width, pictureBox2.Height);
                        Graphics gr = Graphics.FromImage(bmp);
                        boat.setPosition(5, 5);
                        boat.drawBoat(gr);
                        pictureBox2.Image = bmp;
                        Draw();
                    }
                    else
                    {
                        MessageBox.Show("Извините, на этом месте нет машины");
                    }

                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            prichal.LevelDown();
            listBox1.SelectedIndex = prichal.getCurrentLevel;
            Draw();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            prichal.LevelUp();
            listBox1.SelectedIndex = prichal.getCurrentLevel;
            Draw();
        }
    }
}
