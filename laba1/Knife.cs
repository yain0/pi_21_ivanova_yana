using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace $safeprojectname$
{
    class Knife
    {
        public void Clean_potato(Potato p)
        {
            if (p.Have_scin)
            {
                p.Have_scin = false;
            }
        }
        public void Clean_carrot(Carrot p)
        {
            if (p.Have_scin)
            {
                p.Have_scin = false;
            }
        }
        public void CutChicen(Chicken t)
        {
            if (t.cutting)
            {
                t.cutting = false;
            }

        }


    }
}
