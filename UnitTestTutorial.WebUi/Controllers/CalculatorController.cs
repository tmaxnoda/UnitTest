using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using UnitTestTutorial.API.Models;
using UnitTestTutorial.WebUi.Extensions;
using UnitTestTutorial.WebUi.Models;

namespace UnitTestTutorial.WebUi.Controllers
{
    public class CalculatorController : Controller
    {
        private readonly IcalculatorService _Calculatorservice;
        public CalculatorController(IcalculatorService service)
        {
            if (service == null) throw new ArgumentNullException("Service","Argument cannot be null");
            _Calculatorservice = service;
        }
        public IActionResult Index()
        {
            var model = new CalculatorViewModel();
            model.Operator = CalculatorConstants.Message_ChooseAnOperator;

            model.Operators = GetOperators();

            model.Message = String.Empty;

            model.IsResultValid = false;

            return View(model);
        }


        private List<SelectListItem> GetOperators()
        {
            var operators = new List<SelectListItem>();

            operators.Add(String.Empty, CalculatorConstants.Message_ChooseAnOperator, true);

            operators.Add(CalculatorConstants.OperatorAdd);
            operators.Add(CalculatorConstants.OperatorSubtract);
            operators.Add(CalculatorConstants.OperatorMultiply);
            operators.Add(CalculatorConstants.OperatorDivide);

            return operators;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Calculate(CalculatorViewModel model)
        {
            if (model == null) throw new ArgumentNullException("model", "Argument cannot be null");

            var operation = model.Operator;

            if(operation == CalculatorConstants.OperatorAdd)
            {
                //perform add
                model.ResultValue = _Calculatorservice.Add(model.Value1,model.Value2);

                model.IsResultValid = true;
                model.Message = CalculatorConstants.Message_Success;
                PopulateOperators(model, operation);

                return View("Index", model);
            }
            else if(operation == CalculatorConstants.OperatorDivide)
            {
                if(model.Value2 == 0)
                {
                    model.Value2 = 0;
                    model.IsResultValid = false;
                    model.Message = CalculatorConstants.Message_CantDivideByZero;
                    PopulateOperators(model, operation);

                }
                else
                {
                    model.ResultValue = new Calculator().Divide(model.Value1, model.Value2);
                    model.Message = CalculatorConstants.Message_Success;
                    model.IsResultValid = true;
                    PopulateOperators(model, operation);
                }

                
                return View("Index", model);
            }else if(operation == CalculatorConstants.OperatorSubtract)
            {
                var newoperation = CalculatorConstants.OperatorSubtract;
                model.ResultValue = _Calculatorservice.Subtract(model.Value1, model.Value2);
                model.IsResultValid = true;
                model.Message = CalculatorConstants.Message_Success;
                PopulateOperators(model, newoperation);

                return View("Index", model);
            }else if(operation == CalculatorConstants.OperatorMultiply)
            {
                var newoperation = CalculatorConstants.OperatorMultiply;
                model.ResultValue = _Calculatorservice.Multiply(model.Value1, model.Value2);
                model.IsResultValid = true;
                model.Message = CalculatorConstants.Message_Success;
                PopulateOperators(model, newoperation);

                return View("Index", model);
            }

            return View(model);
           
        }

        private void PopulateOperators(CalculatorViewModel model, string operation)
        {
            model.Operator =  operation;

            var operators = GetOperators();

            foreach(var item in operators)
            {
                item.Selected = false;
            }

            var selectThisOperator = (from temp in operators
                                      where temp.Text == operation
                                      select temp).FirstOrDefault();
            
            if(selectThisOperator != null)
            {
                selectThisOperator.Selected = true;
            }

            model.Operators = operators;
        }
    }
}