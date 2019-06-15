using Microsoft.VisualStudio.TestTools.UnitTesting;
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

        [TestMethod]
        public void Add()
        {
            //arrange
            int val1 = 2;
            int val2 = 3;
            int expectedvalue = 5;
            //act
        //    var sut = new Calculator();
            int actual = SystemUnderTest.Add(val1, val2);
            //assert
            Assert.AreEqual<int>(expectedvalue, actual, "Wrong Result");
        }

        [TestMethod]

        public void Subtract()
        {
            //arrange
            int val1 = 6;
            int val2 = 2;
            int expectedvalue = 4;

            //act
           // var sut = new Calculator();
            int actual = SystemUnderTest.Subtract(val1, val2);

            //assert
            Assert.AreEqual<int>(expectedvalue, actual, "Wrong Result");
        }
    }
}
