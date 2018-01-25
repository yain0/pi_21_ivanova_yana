using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace $safeprojectname$
{
    public partial class FormKitchen : Form
    {
        private Salt salt;

        private WaterTap waterTap;

        private Knife knife;

        private Pan pan;

        private Stove stove;
        private Water water;
        private Potato[] potato;
        private Lapsha lapsha;
        private Chicken chicken;
        private Carrot[] carrot;
        

        public FormKitchen()
        {
            InitializeComponent();
            waterTap = new WaterTap();
            knife = new Knife();
            pan = new Pan();
            stove = new Stove();
            waterTap = new WaterTap();


           

            
        }
        private void FormKitchen_Load(object sender, EventArgs e)
        {
            

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (carrot == null)
            {
                MessageBox.Show("Добавьте морковь", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (carrot.Length == 0)
            {
                MessageBox.Show("Добавьте морковь", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            for (int i = 0; i < carrot.Length; ++i)
            {
                knife.Clean_carrot(carrot[i]);
            }
            button12.Enabled = true;
            MessageBox.Show("Морковь можно добавлять в кастрюлю", "Кухня", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            knife.CutChicen(chicken);
            MessageBox.Show("Курицу можно добавлять в кастрюлю", "Кухня", MessageBoxButtons.OK, MessageBoxIcon.Information);
            button10.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (potato == null)
            {
                MessageBox.Show("Добавьте картофель", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (potato.Length == 0)
            {
                MessageBox.Show("Добавьте картофель", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            for (int i = 0; i < potato.Length; i++)
            {
                knife.Clean_potato(potato[i]);
            }
            button9.Enabled = true;
            MessageBox.Show("Картошку  можно добавлять в кастрюлю", "Кухня", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                waterTap.State = false;
            }

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                waterTap.State = true;
            }

        }

        private void numericUpDownPOP_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (potato == null)
            {
                MessageBox.Show("Добавьте картофель", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (potato.Length == 0)
            {
                MessageBox.Show("Добавьте картофель", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            for (int i = 0; i < potato.Length; ++i)
            {
               
                if (potato[i].Have_scin)
                {
                    MessageBox.Show("Еще не почистили", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
                pan.AddPotato(potato);
            
        
            MessageBox.Show("Картофель в кастрюльке", "Кухня", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (carrot == null)
            {
                MessageBox.Show("Добавьте морковь", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (carrot.Length == 0)
            {
                MessageBox.Show("Добавьте морковь", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            for (int i = 0; i < carrot.Length; ++i)
            {

                if (carrot[i].Have_scin)
                {
                    MessageBox.Show("Еще не очистили", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            
                pan.AddCarrot(carrot);
      
            MessageBox.Show("Морковь положили", "Кухня", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (lapsha == null)
            {
                MessageBox.Show("Добавьте лапшу", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            MessageBox.Show("Лапша в кастрюльке", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
            pan.AddLapsha(lapsha);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (chicken == null)
            {
                MessageBox.Show("Добавьте курицу", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (chicken.cutting)
            {
                MessageBox.Show("Нарежте курицу", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MessageBox.Show("Курица в кастрюльке", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
            pan.AddChicken(chicken);

        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (!waterTap.State)
            {
                MessageBox.Show("Кран закрыт", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
           
                pan.AddWater(waterTap.GetWater());
            
            button13.Enabled = true;
            radioButton2.Checked = true;
            MessageBox.Show("Вода в кастрюльке", "Кухня", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void button13_Click(object sender, EventArgs e)
        {
            salt = new Salt();
            salt.Count = Convert.ToInt32(numericUpDown3.Value);
            if (salt.Count > 0)
            {
                pan.AddSalt(salt);
                MessageBox.Show("Посолено", "Кухня", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Посолите", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            stove.Pan = pan;
            button7.Enabled = true;
            MessageBox.Show("Кастрюля на плите", "Кухня", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (!stove.pan1())
            {
                MessageBox.Show("Еще не все сделано для готовки", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!stove.State)
            {
                MessageBox.Show("На холодной плите долго варить будем, лучше включить", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            stove.Cook();
            if (!stove.Pan.Isready())
            {
                radioButton3.Checked = false;
                MessageBox.Show("Готово", "Кухня", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Стой, что-то не так", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
        }
        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            stove.State = radioButton3.Checked;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            
            potato = new Potato[3];
            for (int i = 0; i < potato.Length; i++) {
                potato[i] = new Potato();
                
            }
            carrot = new Carrot[2];
            for (int i = 0; i < carrot.Length; i++) {
                carrot[i] = new Carrot();
            }
            
            chicken = new Chicken();
           lapsha = new Lapsha();
            

        }

		private void FormKitchen_Load_1(object sender, EventArgs e)
		{

		}

        private void button4_Click(object sender, EventArgs e)
        {
            if (!waterTap.State)
            {
                MessageBox.Show("Кран закрыт", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
           
            else {
				for (int i = 0; i < potato.Length; ++i)
				{
					potato[i] = new Potato();
				}
				for (int i = 0; i < potato.Length; ++i)
				{
					potato[i].Dirty = 0;
				}

			}


			MessageBox.Show("Картофель чистенький", "Кухня", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void button16_Click(object sender, EventArgs e)
		{
			if (!waterTap.State)
			{
				MessageBox.Show("Кран закрыт", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			else
			{
				for (int i = 0; i < carrot.Length; ++i)
				{
					carrot[i] = new Carrot();
				}
				for (int i = 0; i < carrot.Length; ++i)
				{
					carrot[i].Dirty = 0;
				}
			}
			MessageBox.Show("Морковь чистенькая", "Кухня", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void button17_Click(object sender, EventArgs e)
		{
			if (!waterTap.State)
			{
				MessageBox.Show("Кран закрыт", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
		}
	}
}
