using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WindowsFormsApplication1
{
    public class NewBoat : Boat
    {
        private bool vint;
        private bool kabina;
        private Color dopColor;
        public NewBoat(int maxSpeed, int maxCountPassenger, double weight, Color color,
            bool vint, bool kabina, Color dopColor) :
            base(maxSpeed, maxCountPassenger, weight, color)
        {
            this.vint = vint;
            this.kabina = kabina;
            this.dopColor = dopColor;
        }
        public NewBoat(string info) : base(info)
        {
            string[] strs = info.Split(';');
            if (strs.Length == 7)
            {
                MaxSpeed = Convert.ToInt32(strs[0]);
                MaxCountPassengers = Convert.ToInt32(strs[1]);
                Weight = Convert.ToInt32(strs[2]);
                ColorBody = Color.FromName(strs[3]);
                vint = Convert.ToBoolean(strs[4]);
                kabina = Convert.ToBoolean(strs[5]);
                dopColor = Color.FromName(strs[6]);
            }
        }
        protected override void drawLightBoat(Graphics g)
        {
            if (vint)
            {
                Pen pen3 = new Pen(Color.Blue, 4);
                g.DrawLine(pen3, startPosX - 7, startPosY - 5, startPosX + 10, startPosY + 10);
                g.DrawLine(pen3, startPosX - 7, startPosY + 25, startPosX + 10, startPosY + 10);
                g.DrawLine(pen3, startPosX - 7, startPosY + 10, startPosX + 10, startPosY + 10);


            }
            if (kabina)
            {
                Pen pen4 = new Pen(dopColor, 4);
                g.DrawRectangle(pen4, startPosX + 10, startPosY, 20, 20);


            }
            base.drawLightBoat(g);
            //Pen pen = new Pen(ColorBody, 5);
            // 

            // 
        }
            public void setDopColor(Color color)
        {
            dopColor = color;
        }
        public override string getInfo()
        {
            return MaxSpeed + ";" + MaxCountPassengers + ";" + Weight + ";" + ColorBody.Name + ";" + vint + ";" + kabina + ";" + dopColor.Name;
        }

    }
}
