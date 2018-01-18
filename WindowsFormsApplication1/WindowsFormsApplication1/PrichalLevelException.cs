using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class PrichalLevelException : Exception

    {
        public PrichalLevelException() :
            base("Такого уровня нет")
        { }
    }
}
