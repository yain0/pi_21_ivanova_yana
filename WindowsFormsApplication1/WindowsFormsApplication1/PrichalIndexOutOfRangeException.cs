using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class PrichalIndexOutOfRangeException : Exception

    {
        public PrichalIndexOutOfRangeException() :
            base("На этом месте нет кораблей")
        { }
    }
}
