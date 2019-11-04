using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMathConsoleApp
{
    public class MyMath2
    {
        public static byte Add(byte x, byte y)
        {
            checked
            {
                return (byte)(x + y);
        
            }
        }
    }
}
