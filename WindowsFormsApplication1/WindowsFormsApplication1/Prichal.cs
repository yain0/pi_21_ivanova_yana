using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class Prichal
    {
        ClassArray<Transport> prichal;
        int countPlaces = 20;
        int placeSizeWidth = 210;
        int placeSizeHeight = 80;
        public Prichal()
        {
            prichal = new ClassArray<Transport>(countPlaces, null);
        }
        public int PutBoatPrichal(Transport boat)
        {
            return prichal + boat;
        }
        public Transport GetBoatPrichal(int ticket)
        {
            return prichal - ticket;
        }
        public void Draw(Graphics g, int width, int height)
        {
            DrawMarking(g);
            for (int i = 0; i < countPlaces; i++)
            {
                var boat = prichal.getObject(i);
                if (boat != null)
                {
                    boat.setPosition(5 + i / 5 * placeSizeWidth + 5, i % 5 * placeSizeHeight + 15);
                    boat.drawBoat(g);
                }
            }
        }
        private void DrawMarking(Graphics g)
        {
            Pen pen = new Pen(Color.Black, 3);
            g.DrawRectangle(pen, 0, 0, (countPlaces / 5) * placeSizeWidth, 480);
            for (int i = 0; i < countPlaces / 5; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    g.DrawLine(pen, i * placeSizeWidth, j * placeSizeHeight, i * placeSizeWidth + 110, j * placeSizeHeight);

                }
                g.DrawLine(pen, i * placeSizeWidth, 0, i * placeSizeWidth, 400);
            }
        }
    }
}
