using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using UnitTestTutorial.API.Models;

namespace UnitTestTutorial.Test
{
    [TestClass]
    public class CalculatorFixture
    {

        [TestInitialize]
        public void OonTestInitialize()
        {
            _SystemUnderTest = null;
            _calculattorService = null;
        }
        private Calculator _SystemUnderTest;

        public Calculator SystemUnderTest {
            get {
                if (_SystemUnderTest == null) {
                    _SystemUnderTest = new Calculator();
                }

                return _SystemUnderTest;
            }
        }

        private IcalculatorService _calculattorService;

        public IcalculatorService CalculatorService
        {
            get
            {
                if(_calculattorService == null)
                {
                    _calculattorService = new Calculator();
                }

                return _calculattorService;
            }
        }

        [TestMethod]
        public void Add()
        {
            //arrange
            double val1 = 2;
            double val2 = 3;
            double expectedvalue = 5;
            //act
        //    var sut = new Calculator();
            double actual = SystemUnderTest.Add(val1, val2);
            //assert
            Assert.AreEqual<double>(expectedvalue, actual, "Wrong Result");
        }

        [TestMethod]

        public void Subtract()
        {
            //arrange
            double val1 = 6;
            double val2 = 2;
            double expectedvalue = 4;

            //act
            // var sut = new Calculator();
            double actual = SystemUnderTest.Subtract(val1, val2);

            //assert
            Assert.AreEqual<double>(expectedvalue, actual, "Wrong Result");
        }


        [TestMethod]

        public void Multtiplication()
        {
            //arrange
            double val1 = 6;
            double val2 = 2;
            double expectedvalue = 12;

            //act
            // var sut = new Calculator();
            double actual = SystemUnderTest.Multiply(val1, val2);

            //assert
            Assert.AreEqual<double>(expectedvalue, actual, "Wrong Result");
        }


        [TestMethod]

        public void Division()
        {
            //arrange
            double val1 = 6;
            double val2 = 2;
            double expectedvalue = 3;

            //act
            // var sut = new Calculator();
            double actual = SystemUnderTest.Divide(val1, val2);

            //assert
            Assert.AreEqual<double>(expectedvalue, actual, "Wrong Result");
        }


        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]

        public void DivisionByZero()
        {
            //arrange
            double val1 = 6;
            double val2 = 0;
            //int expectedvalue = 3;

            //act
            // var sut = new Calculator();
            double actual = SystemUnderTest.Divide(val1, val2);

            //assert
            //Assert.AreEqual<int>(expectedvalue, actual, "Wrong Result");
        }
    }
}
