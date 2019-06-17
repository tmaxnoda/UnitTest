using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
                    _SystemUnderTest = new CalculatorController();
                }

                return _SystemUnderTest;
            }
        }

        //if we call the index method do we get back the instance of the model that we want?
        [TestMethod]
        public void CalculatorController_Index_ModelIsNotNull()
        {
            var actual = UnitTestUtility.GetModel<CalculatorViewModel>(SystemUnderTest.Index());

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
    }
}
