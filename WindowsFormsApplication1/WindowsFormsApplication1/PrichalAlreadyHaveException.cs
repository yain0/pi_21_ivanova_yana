using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class PrichalAlreadyHaveException : Exception

    {
        public PrichalAlreadyHaveException() :
            base("Такой корабль уже есть")
        { }
    }
}
