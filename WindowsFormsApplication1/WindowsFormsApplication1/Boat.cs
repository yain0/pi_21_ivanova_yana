using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public class Boat : Vehicle, IComparable<Boat>, IEquatable<Boat>
    {
        public int CompareTo(Boat other)
        {
            if (other == null)
            {
                return 1;
            }
            if (MaxSpeed != other.MaxSpeed)
            {
                return MaxSpeed.CompareTo(other.MaxSpeed);
            }
            if (MaxCountPassengers != other.MaxCountPassengers)
            {
                return MaxCountPassengers.CompareTo(other.MaxCountPassengers);
            }
            if (Weight != other.Weight)
            {
                return Weight.CompareTo(other.Weight);
            }
            if (ColorBody != other.ColorBody)
            {
                ColorBody.Name.CompareTo(other.ColorBody.Name);
            }
            return 0;
        }
        public bool Equals(Boat other)
        {
            if (other == null)
            {
                return false;
            }
            if (MaxSpeed != other.MaxSpeed)
            {
                return false;
            }
            if (MaxCountPassengers != other.MaxCountPassengers)
            {
                return false;
            }
            if (Weight != other.Weight)
            {
                return false;
            }
            if (ColorBody != other.ColorBody)
            {
                return false;
            }
            return true;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            Boat boatObj = obj as Boat;
            if (boatObj == null)
            {
                return false;
            }
            else
            {
                return Equals(boatObj);
            }
        }
        public override int GetHashCode()
        {
            return MaxSpeed.GetHashCode();
        }
       
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
        public Boat(string info)
        {
            string[] strs = info.Split(';');
            if (strs.Length == 4)
            {
                MaxSpeed = Convert.ToInt32(strs[0]);
                MaxCountPassengers = Convert.ToInt32(strs[1]);
                Weight = Convert.ToInt32(strs[2]);
                ColorBody = Color.FromName(strs[3]);
            }
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
            //g.DrawLine(pen, startPosX, startPosY, startPosX+80, startPosY);
            /*g.DrawLine(pen, startPosX, startPosY, startPosX + 20, startPosY+20);
            g.DrawLine(pen, startPosX+20, startPosY+20, startPosX + 60, startPosY+20);
            g.DrawLine(pen, startPosX+60, startPosY+20, startPosX + 80, startPosY);*/
            // Point[] a = { new Point(startPosX-20, startPosY), new Point(startPosX + 60, startPosY), new Point(startPosX + 40, startPosY + 20), new Point(startPosX, startPosY + 20), };
            //g.DrawPolygon(pen, a);
            //Pen pen2 = new Pen(Color.Red, 5);
            // Point[] b = { new Point(startPosX + 20, startPosY), new Point(startPosX + 20, startPosY-20), new Point(startPosX + 25, startPosY -15), new Point(startPosX+20, startPosY - 10), };
            // g.DrawPolygon(pen2, b);
            Point[] a = { new Point(startPosX, startPosY + 20), new Point(startPosX + 60, startPosY + 20), new Point(startPosX + 40, startPosY + 35), new Point(startPosX, startPosY + 35) };
            g.DrawPolygon(pen, a);
            // Pen pen = new Pen(Color.Brown, 5);
            //Point[] b = { new Point(startPosX+10, startPosY), new Point(startPosX + 10, startPosY-20), new Point(startPosX + 30, startPosY - 20), new Point(startPosX+30, startPosY), };
            // g.DrawPolygon(pen, b);
            // g.Dispose();





        }
        public override string getInfo()
        {
            return MaxSpeed + ";" + MaxCountPassengers + ";" + Weight + ";" + ColorBody.Name;
        }


    }
}
