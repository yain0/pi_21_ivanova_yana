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


        Prichal prichal;
        Form2 form;
        private Logger log;
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
                prichal.Draw(gr);
                pictureBox1.Image = bmp;
            }

        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            form = new Form2();
            form.AddEvent(AddBoat);
            form.Show();
        }


        private void AddBoat(Transport boat)
        {

            if (boat != null)
            {
                try
                {

                    int place = prichal.PutBoatPrichal(boat);
                    Draw();
                    MessageBox.Show("Ваше место: " + place);
                }
                catch (PrichalOverflowException ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка переполнения", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Общая ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    try
                    {
                        Transport boat = prichal.GetBoatPrichal(Convert.ToInt32(maskedTextBox1.Text));

                        Bitmap bmp = new Bitmap(pictureBox2.Width, pictureBox2.Height);
                        Graphics gr = Graphics.FromImage(bmp);
                        boat.setPosition(5, 5);
                        boat.drawBoat(gr);
                        pictureBox2.Image = bmp;
                        Draw();
                    }
                    catch (PrichalIndexOutOfRangeException ex)
                    {
                        MessageBox.Show(ex.Message, "Неверный номер", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Общая ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                prichal.LevelDown();
                listBox1.SelectedIndex = prichal.getCurrentLevel;
            }
            catch (PrichalLevelException ex)
            {
                MessageBox.Show(ex.Message, "Ошибка уровня", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Общая ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            log.Info("Переходим на уровень ниже. Текущий уровень: " + prichal.getCurrentLevel);
            Draw();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                prichal.LevelUp();
                listBox1.SelectedIndex = prichal.getCurrentLevel;


            }
            catch (PrichalLevelException ex)
            {
                MessageBox.Show(ex.Message, "Ошибка уровня", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Общая ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            log.Info("Переходим на уровень выше. Текущий уровень: " + prichal.getCurrentLevel);

            Draw();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void загрузитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            log.Info("Загружаем файл");
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (prichal.LoadData(openFileDialog1.FileName))
                {
                    MessageBox.Show("Загрузили", "",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    MessageBox.Show("Не загрузили", "",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                Draw();
            }
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            log.Info("Созраняем файл");
            if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (prichal.SaveData(saveFileDialog1.FileName))
                {
                    MessageBox.Show("Сохранен", "",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Не сохранилось", "",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
