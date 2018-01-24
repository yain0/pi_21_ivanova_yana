using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public class Boat : Vehicle
    {
        public override int MaxSpeed
        {
            get
            {
                return base.MaxSpeed;
            }

            protected set
            {
                if (value > 0 && value < 100)
                {
                    base.MaxSpeed = value;
                }
                else
                {
                    base.MaxSpeed = 50;
                }
            }
        }
        public override int MaxCountPassengers
        {
            get
            {
                return base.MaxCountPassengers;
            }

            protected set
            {
                if (value > 0 && value < 150)
                {
                    base.MaxCountPassengers = value;
                }
                else
                {
                    base.MaxCountPassengers = 140;
                }
            }
        }
        public override double Weight
        {
            get
            {
                return base.Weight;
            }

            protected set
            {
                if (value > 500 && value < 1500)
                {
                    base.Weight = value;
                }
                else
                {
                    base.Weight = 1000;
                }
            }
        }
        public Boat(int maxSpeed, int maxCountPassenger, double weight, Color color)
        {
            this.MaxSpeed = maxSpeed;
            this.MaxCountPassengers = maxCountPassenger;
            this.ColorBody = color;
            this.Weight = weight;
            this.countPassengers = 0;
            Random rand = new Random();
            startPosX = rand.Next(10, 200);
            startPosY = rand.Next(10, 200);
        }
        public override void moveBoat(Graphics g)
        {
            startPosX +=
                (MaxSpeed * 50 / (int)Weight) /
                (countPassengers == 0 ? 1 : countPassengers);
            drawBoat(g);
        }
        public override void drawBoat(Graphics g)
        {
            drawLightBoat(g);
        }
        public void FillPolygonPoint(PaintEventArgs e)
        {
            SolidBrush br = new SolidBrush(ColorBody);
            Point point1 = new Point(startPosX + 40, startPosY + 20);
            Point point2 = new Point(startPosX + 40, startPosY);
            Point point3 = new Point(startPosX + 60, startPosY);
            Point[] curvePoints = { point1, point2, point3 };
            e.Graphics.FillPolygon(br, curvePoints);
        }
        protected virtual void drawLightBoat(Graphics g)
        {
            Pen pen = new Pen(ColorBody, 5);
            Point[] a = { new Point(startPosX, startPosY + 20), new Point(startPosX + 60, startPosY + 20), new Point(startPosX + 40, startPosY + 35), new Point(startPosX, startPosY + 35) };
            g.DrawPolygon(pen, a);
        }
    }
}
