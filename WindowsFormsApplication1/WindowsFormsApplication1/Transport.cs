using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public interface Transport
    {
        void moveBoat(Graphics g);
        void drawBoat(Graphics g);
        void setPosition(int x, int y);
        void loadPassenger(int count);
        int getPassenger();
        void setMainColor(Color color);
        string getInfo();
    }
}
