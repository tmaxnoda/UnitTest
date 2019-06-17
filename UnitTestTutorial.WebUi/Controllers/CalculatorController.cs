using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using UnitTestTutorial.WebUi.Extensions;
using UnitTestTutorial.WebUi.Models;

namespace UnitTestTutorial.WebUi.Controllers
{
    public class CalculatorController : Controller
    {
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

        public IActionResult Calculate(CalculatorViewModel model)
        {
            return View();
        }
    }
}