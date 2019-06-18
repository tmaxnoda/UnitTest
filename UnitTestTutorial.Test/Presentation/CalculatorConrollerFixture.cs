using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnitTestTutorial.API.Models;
using UnitTestTutorial.WebUi.Controllers;
using UnitTestTutorial.WebUi.Models;

namespace UnitTestTutorial.Test.Presentation
{
    [TestClass]
    public class CalculatorConrollerFixture
    {
        [TestInitialize]
        public void OonTestInitialize()
        {
            _SystemUnderTest = null;
        }
        private CalculatorController _SystemUnderTest;

        public CalculatorController SystemUnderTest
        {
            get
            {
                if (_SystemUnderTest == null)
                {
                    _SystemUnderTest = new CalculatorController(CalculatorServiceInstance);
                }

                return _SystemUnderTest;
            }
        }

        private IcalculatorService _CalculateServiceInstance;

        public IcalculatorService CalculatorServiceInstance
        {
            get
            {
                if(_CalculateServiceInstance == null)
                {
                    _CalculateServiceInstance = new Calculator();
                }
                return _CalculateServiceInstance;
            }
        }

        //if we call the index method do we get back the instance of the model that we want?
        [TestMethod]
        public void CalculatorController_Index_ModelIsNotNull()
        {
            var actual = UnitTestUtility.GetModel<CalculatorViewModel>
                (SystemUnderTest.Index());

            Assert.IsNotNull(actual, "model was Null");
        }

        [TestMethod]
        public void CalculatorController_Index_Value1Instatialize()
        {
            var model = UnitTestUtility.GetModel<CalculatorViewModel>(SystemUnderTest.Index());

            var actual = model.Value1;
            var expected = 0d;


            Assert.AreEqual<double>(actual,expected, "Value1 field was wrong!");
        }

        [TestMethod]
        public void CalculatorController_Index_Model_Value2Inistatialize()
        {
            var model = UnitTestUtility.GetModel<CalculatorViewModel>(SystemUnderTest.Index());

            var actual = model.Value2;
            var expected = 0d;


            Assert.AreEqual<double>(actual, expected, "value2 field was wrong!");
        }


        [TestMethod]
        public void CalculatorController_Index_Model_OperatorIsInitialized()
        {
            var model = UnitTestUtility.GetModel<CalculatorViewModel>(SystemUnderTest.Index());

            var actual = model.Operator;
            var expected = CalculatorConstants.Message_ChooseAnOperator;


            Assert.AreEqual<string>(actual, expected, "operator  field value was wrong!");
        }

        [TestMethod]
        public void CalculatorController_Index_Model_MessageInitialized()
        {
            var model = UnitTestUtility.GetModel<CalculatorViewModel>(SystemUnderTest.Index());

            var actual = model.Message;
            var expected = string.Empty;


            Assert.AreEqual<string>(actual, expected, "Message  field value was wrong!");
        }


        [TestMethod]
        public void CalculatorController_Index_Model_IsResultValueShouldBeFalse()
        {
            var model = UnitTestUtility.GetModel<CalculatorViewModel>(SystemUnderTest.Index());

            var actual = model.IsResultValid;
            var expected = false;


            Assert.AreEqual<bool>(actual, expected, "IsResult  field value was wrong!");
        }


        [TestMethod]
        public void CalculatorController_Index_Model_OperatiorsCollectionIsPopulated()
        {
            var model = UnitTestUtility.GetModel<CalculatorViewModel>(SystemUnderTest.Index());

            Assert.IsNotNull(model.Operators, "Operators collection was null.");

            var actual = model.Operators.Select(x => x.Text).ToList();
            
            var expected = new List<string>();

            expected.Add(CalculatorConstants.Message_ChooseAnOperator);
            expected.Add(CalculatorConstants.OperatorAdd);
            expected.Add(CalculatorConstants.OperatorSubtract);
            expected.Add(CalculatorConstants.OperatorMultiply);
            expected.Add(CalculatorConstants.OperatorDivide);

            CollectionAssert.AreEqual(expected, actual, "Wrong Values in operators collection");


           // Assert.AreEqual<List<string>>(actual, expected, "IsResult  field value was wrong!");
        }

        [TestMethod]
        public void CalculatorController_Calculate_Add()
        {
            //arrange
            var model = UnitTestUtility.GetModel<CalculatorViewModel>(SystemUnderTest.Index());

            double value1 = 2;
            double value2 = 3;
            double expected = 5;

            model.Value1 = value1;
            model.Value2 = value2;
            model.Operator = CalculatorConstants.OperatorAdd;

            //act
            var actual = UnitTestUtility.
                GetModel<CalculatorViewModel>(SystemUnderTest.Calculate(model));

            //assert
            Assert.IsTrue(actual.IsResultValid, "Result should be valid.");
            Assert.AreEqual<double>(expected, actual.ResultValue, "Result was wrong.");
            Assert.AreEqual<string>(CalculatorConstants.Message_Success, actual.Message, "Message was wrong");

            AssertOperatorsAndSelectedOperator(model, CalculatorConstants.OperatorAdd);
        }

        [TestMethod]
        public void CalculatorController_Calculate_Subtract()
        {
            //arrange
            var model = UnitTestUtility.GetModel<CalculatorViewModel>(SystemUnderTest.Index());
            double value1 = 30;
            double value2 = 5;
            double expected = 25;

            model.Value1 = value1;
            model.Value2 = value2;
            model.Operator = CalculatorConstants.OperatorSubtract;

            //act
            var actual = UnitTestUtility.GetModel<CalculatorViewModel>(SystemUnderTest.Calculate(model));

            Assert.IsTrue(actual.IsResultValid, "Resullt should be valid");
            Assert.AreEqual(expected, actual.ResultValue, "Result was wrong");
            Assert.AreEqual<string>(CalculatorConstants.Message_Success, actual.Message, "Message does not match");
           // Assert.ThrowsException<InvalidOperationException>(actual as InvalidOperationException);
        }


        [TestMethod]
        public void CalculatorController_Calculate_Multiplication()
        {
            //arrange
            var model = UnitTestUtility.GetModel<CalculatorViewModel>(SystemUnderTest.Index());
            double value1 = 5;
            double value2 = 5;
            double expected = 25;

            model.Value1 = value1;
            model.Value2 = value2;
            model.Operator = CalculatorConstants.OperatorMultiply;

            //act
            var actual = UnitTestUtility.GetModel<CalculatorViewModel>(SystemUnderTest.Calculate(model)) ;

            Assert.IsTrue(actual.IsResultValid, "Resullt should be valid");
            Assert.AreEqual(expected, actual.ResultValue, "Result was wrong");
            Assert.AreEqual<string>(CalculatorConstants.Message_Success, actual.Message, "Message does not match");
           // Assert.IsInstanceOfType(actual as InvalidOperationException, typeof(InvalidOperationException));
            // Assert.ThrowsException<InvalidOperationException>(actual as InvalidOperationException);
        }




        [TestMethod]
        public void CalculatorController_Calculate_DivideBySero()
        {
            var model = UnitTestUtility.GetModel<CalculatorViewModel>(SystemUnderTest.Index());

            double value1 = 8;
            double value2 = 0;

            model.Value1 = value1;
            model.Value2 = value2;
            model.Operator = CalculatorConstants.OperatorDivide;

            var actual = UnitTestUtility.GetModel<CalculatorViewModel>(SystemUnderTest.Calculate(model));

            Assert.IsFalse(actual.IsResultValid, "Result should be valid");

            Assert.AreEqual<double>(0, actual.ResultValue, "Result was wrong");

            Assert.AreEqual<string>(CalculatorConstants.Message_CantDivideByZero, actual.Message, "Message was wrong");

            AssertOperatorsAndSelectedOperator(model, CalculatorConstants.OperatorDivide);

        }

        private void AssertOperatorsAndSelectedOperator(CalculatorViewModel model, string expectedSelectedOperator)
        {
            Assert.IsNotNull(model.Operators, "Operators collection was null.");

            var actual = model.Operators.Select(x => x.Text).ToList();

            var expected = new List<string>();

            expected.Add(CalculatorConstants.Message_ChooseAnOperator);
            expected.Add(CalculatorConstants.OperatorAdd);
            expected.Add(CalculatorConstants.OperatorSubtract);
            expected.Add(CalculatorConstants.OperatorMultiply);
            expected.Add(CalculatorConstants.OperatorDivide);


            CollectionAssert.AreEqual(expected, actual, "Operators in collection were wrong.");

            AssertSelectedOperator(model, expectedSelectedOperator);
        }

        private void AssertSelectedOperator(CalculatorViewModel model, string expectedSelectedOperator)
        {
            Assert.IsNotNull(model.Operators, "Operators collection was null.");

            Assert.AreEqual<string>(expectedSelectedOperator, model.Operator, "Operator property was wrong.");

            var match = (from temp in model.Operators
                         where temp.Text == expectedSelectedOperator
                         select temp).FirstOrDefault();

            Assert.IsNotNull(match, "Could not find '{0}' in Operators.", expectedSelectedOperator);

            Assert.IsTrue(match.Selected, "Operator '{0}' should have been selected.", expectedSelectedOperator);
        }
    }
}
