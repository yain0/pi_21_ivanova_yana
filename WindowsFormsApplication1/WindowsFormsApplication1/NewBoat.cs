using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public class NewBoat : Boat
    {
        private bool kabina;
        private bool vint;
        private Color dopColor;
        public NewBoat(int maxSpeed, int maxCountPassenger, double weight, Color color,
            bool kabina, bool vint, Color dopColor) :
            base(maxSpeed, maxCountPassenger, weight, color)
        {
            this.kabina = kabina;
            this.vint = vint;
            this.dopColor = dopColor;
        }
        protected override void drawLightBoat(Graphics g)
        {
            if (kabina)
            {
                Pen pen = new Pen(dopColor);
                g.DrawLine(pen, startPosX, startPosY, startPosX, startPosY-20);
                g.DrawLine(pen, startPosX, startPosY - 20, startPosX+20, startPosY-20);
                g.DrawLine(pen, startPosX+20, startPosY - 20, startPosX+20, startPosY);




            }
            if(vint)
            {
                Pen pen = new Pen(Color.Black);
                g.DrawLine(pen, startPosX, startPosY, startPosX-10, startPosY - 10);
                g.DrawLine(pen, startPosX, startPosY, startPosX -10, startPosY);
                g.DrawLine(pen, startPosX, startPosY, startPosX -10, startPosY+10);
            }
            base.drawLightBoat(g);
            Brush br = new SolidBrush(dopColor);
            g.FillRectangle(br, startPosX, startPosY-20, 20, 20);
            
        }
    }
}
