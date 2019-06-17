using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnitTestTutorial.API.Models
{
    public class Calculator
    {
        public int Add(int val1, int val2)
        {
            return val1 + val2;
        }

        public int Subtract(int val1, int val2)
        {
            return val1 - val2;
        }

        public int Multiply(int val1, int val2)
        {
            return val1 * val2;
        }

        public int Divide(int val1, int val2)
        {
            //var div = val1 / val2;
            if (val2 == 0) throw new InvalidOperationException("Argument cannot be zero");

            return val1/val2;
        }
    }
}
