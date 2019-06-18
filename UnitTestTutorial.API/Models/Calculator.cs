using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnitTestTutorial.API.Models
{
    public class Calculator:IcalculatorService
    {
       
        public double Add(double val1, double val2)
        {
            return val1 + val2;
        }

       

        public double Subtract(double val1, double value2)
        {
            return val1 - value2;
        }

       

        public double Multiply(double val1, double val2)
        {
            return val1 * val2;
        }

       

        public double Divide(double val1, double val2)
        {
            //var div = val1 / val2;
            if (val2 == 0) throw new InvalidOperationException("Argument cannot be zero");

            return val1 / val2;
        }
    }
}
