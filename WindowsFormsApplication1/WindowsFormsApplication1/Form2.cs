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
    public partial class Form2 : Form
    {
        Transport boat = null;
        public Transport getBoat { get { return boat; } }

        private void DrawBoat()
        {
            if (boat != null)
            {
                Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                Graphics gr = Graphics.FromImage(bmp);
                boat.setPosition(5, 5);
                boat.drawBoat(gr);
                pictureBox1.Image = bmp;
            }
        }
        private event myDel eventAddBoat;

        public void AddEvent(myDel ev)
        {
            if (eventAddBoat == null)
            {
                eventAddBoat = new myDel(ev);
            }
            else
            {
                eventAddBoat += ev;
            }
        }
        public Form2()
        {
            InitializeComponent();
            panelRed.MouseDown += panelColor_MouseDown;
            panelOrange.MouseDown += panelColor_MouseDown;
            panelYellow.MouseDown += panelColor_MouseDown;
            panelGray.MouseDown += panelColor_MouseDown;
            panelWhite.MouseDown += panelColor_MouseDown;
            panelGreen.MouseDown += panelColor_MouseDown;
            panelBlue.MouseDown += panelColor_MouseDown;
            panelMagenta.MouseDown += panelColor_MouseDown;

            button4.Click += (object sender, EventArgs e) => { Close(); };
        }


        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            label1.DoDragDrop(label1.Text, DragDropEffects.Move | DragDropEffects.Copy);
        }
        private void label2_MouseDown(object sender, MouseEventArgs e)
        {
            label2.DoDragDrop(label2.Text, DragDropEffects.Move |
                DragDropEffects.Copy);
        }
        private void panel1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        private void panel1_DragDrop(object sender, DragEventArgs e)
        {
            switch (e.Data.GetData(DataFormats.Text).ToString())
            {
                case "Boat":
                    boat = new Boat(100, 4, 500, Color.Red);
                    break;
                case "New Boat":
                    boat = new NewBoat(100, 4, 500, Color.Red, true, true, Color.Green);
                    break;
            }
            DrawBoat();
        }
        private void panelColor_MouseDown(object sender, MouseEventArgs e)
        {
            (sender as Control).DoDragDrop((sender as Control).BackColor,
                DragDropEffects.Move | DragDropEffects.Copy);
        }
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label3_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(Color)))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        private void label3_DragDrop(object sender, DragEventArgs e)
        {
            if (boat != null)
            {
                boat.setMainColor((Color)e.Data.GetData(typeof(Color)));
                DrawBoat();
            }
        }



        private void button3_Click(object sender, EventArgs e)
        {
            if (eventAddBoat != null)
            {
                eventAddBoat(boat);

            }
            Close();
        }



        private void label4_DragDrop(object sender, DragEventArgs e)
        {
            if (boat != null)
            {
                if (boat is NewBoat)
                {
                    (boat as NewBoat).setDopColor((Color)e.Data.GetData(typeof(Color)));
                    DrawBoat();
                }
            }
        }

        private void label4_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(Color)))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;

        }
    }
}
