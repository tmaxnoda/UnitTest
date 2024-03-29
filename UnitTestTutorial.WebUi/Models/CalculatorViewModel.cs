﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UnitTestTutorial.WebUi.Models
{
    public class CalculatorViewModel
    {
        [Display(Name = "Value 1")]
        public double Value1 { get; set; }

        [Display(Name = "Value 2")]
        public double Value2 { get; set; }

        [Display(Name = "Result")]
        public double ResultValue { get; set; }

        [Display(Name = "Operators")]
        public List<SelectListItem> Operators { get; set; }

        public string Message { get; set; }

        [Display(Name ="Is result valid")]
        public bool IsResultValid { get; set; }
        [Display(Name = "Operator")]
        public string  Operator {get;set;}
    }


    //private static List<string> StringOperators()
    //{
    //    var list = new List<string>();
    //    string[] operators = new string[] {"*","+","-","/" };
    //    foreach (var item in operators)
    //    {
    //        list.Add(item);
           
    //    }

    //    return list;
    //}
}
