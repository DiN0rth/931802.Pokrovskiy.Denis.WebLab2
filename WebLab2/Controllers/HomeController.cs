using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebLab2.Models;

namespace WebLab2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult SingleAction()
        {
            if (Request.Method.Equals("POST", StringComparison.OrdinalIgnoreCase))
            {
                CalculationModel calculation = new CalculationModel();
                if (Request.Form["n1"] == "" && Request.Form["n2"] == "")
                {
                    calculation.n1 = 0;
                    calculation.n2 = 0;
                }
                else if (Request.Form["n1"] != "" && Request.Form["n2"] == "")
                {
                    calculation.n1 = Int32.Parse(Request.Form["n1"]);
                    calculation.n2 = 0;
                }
                else if (Request.Form["n1"] == "" && Request.Form["n2"] != "")
                {
                    calculation.n1 = 0;
                    calculation.n2 = Int32.Parse(Request.Form["n2"]);
                }
                else
                {
                    calculation.n1 = Int32.Parse(Request.Form["n1"]);
                    calculation.n2 = Int32.Parse(Request.Form["n2"]);
                }

                calculation.operation = Request.Form["operation"];
                calculation.Calculate();
                ViewBag.Result = calculation.n3;
                return View("Result");
            }
            else return View();
        }


        [HttpGet]
        public IActionResult SeparateActions()
        {
            return View();
        }

        [HttpPost, ActionName("SeparateActions")]
        public IActionResult SeparateActionsPost()
        {
            CalculationModel calculation = new CalculationModel();
            if (Request.Form["n1"] == "" && Request.Form["n2"] == "")
            {
                calculation.n1 = 0;
                calculation.n2 = 0;
            }
            else if (Request.Form["n1"] != "" && Request.Form["n2"] == "")
            {
                calculation.n1 = Int32.Parse(Request.Form["n1"]);
                calculation.n2 = 0;
            }
            else if (Request.Form["n1"] == "" && Request.Form["n2"] != "")
            {
                calculation.n1 = 0;
                calculation.n2 = Int32.Parse(Request.Form["n2"]);
            }
            else
            {
                calculation.n1 = Int32.Parse(Request.Form["n1"]);
                calculation.n2 = Int32.Parse(Request.Form["n2"]);
            }

            calculation.operation = Request.Form["operation"];
            calculation.Calculate();
            ViewBag.Result = calculation.n3;
            return View("Result");
        }

        [HttpGet]
        public IActionResult SeparateModel()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SeparateModel(CalculationModel calculation)
        {
            calculation.Calculate();
            ViewBag.Result = calculation.n3;
            return View("Result");
        }

        [HttpGet]
        public IActionResult ParametersModel()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ParametersModel(int n1, int n2, string operation)
        {
            CalculationModel calculation = new CalculationModel();
            calculation.n1 = n1;
            calculation.n2 = n2;
            calculation.operation = operation;
            calculation.Calculate();
            ViewBag.Result = calculation.n3;
            return View("Result");
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
