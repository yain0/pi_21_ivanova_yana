using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public abstract class Vehicle : Transport
    {
        protected float startPosX;
        protected float startPosY;
        protected int countPassengers;
        public virtual int MaxCountPassengers { protected set; get; }
        public virtual int MaxSpeed { protected set; get; }
        public Color ColorBody { protected set; get; }
        public virtual double Weight { protected set; get; }
        public abstract void moveBoat(Graphics g);
        public abstract void drawBoat(Graphics g);
        public void setPosition(int x, int y)
        {
            startPosX = x;
            startPosY = y;
        }
        public void loadPassenger(int count)
        {
            if (countPassengers + count < MaxCountPassengers)
            {
                countPassengers += count;
            }
        }
        public int getPassenger()
        {
            int count = countPassengers;
            countPassengers = 0;
            return count;
        }
    }
}
