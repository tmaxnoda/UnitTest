using System;
using System.Collections.Generic;
using System.Text;
using UnitTestTutorial.API.Models;

namespace UnitTestTutorial.Test.MockService
{
    public class MockCalculatorService : IcalculatorService
    {
        public MockCalculatorService()
        {
            AddWasCalled = false;
            SubtractWasCalled = false;
            MultiplyWasCalled = false;
            DivideWasCalled = false;
        }


        public bool AddWasCalled { get; private set; }

        public bool SubtractWasCalled { get; private set; }

        public bool MultiplyWasCalled { get; private set; }

        public bool DivideWasCalled  { get; private set; }

        public double ReturnValue { get; set; }
        public double Add(double val1, double val2)
        {
            AddWasCalled = true;
            return ReturnValue;
        }

        public double Divide(double val1, double val2)
        {
            DivideWasCalled = true;
            return ReturnValue;
        }

        public double Multiply(double val1, double val2)
        {
            MultiplyWasCalled = true;
            return ReturnValue;
        }

        public double Subtract(double val1, double val2)
        {
            MultiplyWasCalled = true;
            return ReturnValue;
        }
    }
}
