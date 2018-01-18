using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class PrichalOverflowException : Exception
    {
        public PrichalOverflowException() :
            base("На причале нет свободных мест")
        { }
    }
}
