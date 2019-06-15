using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestTutorial.API.Models;

namespace UnitTestTutorial.Test
{
    [TestClass]
    public class CalculatorFixture
    {
        [TestMethod]
        public void Add()
        {
            //arrange
            int val1 = 2;
            int val2 = 3;
            int expectedvalue = 5;
            //act
            var sut = new Calculator();
            int actual = sut.Add(val1, val2);
            //assert
            Assert.AreEqual<int>(expectedvalue, actual, "Wrong Result");
        }
    }
}
