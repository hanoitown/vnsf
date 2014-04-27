using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Vnsf.Presentation.Api.Controllers
{
    public class HomeController : Controller
    {
        private ICalculator calculator;

        public HomeController(ICalculator calculator)
        {
            this.calculator = calculator;
        }
        public ActionResult Index()
        {
            ViewBag.Cal = calculator.increase(3);
            return View();
        }
    }

    public interface ICalculator
    {
        string increase(int i);
    }

    public class Calculator : ICalculator
    {
        public string increase(int i)
        {
            return i.ToString();
        }
    }
}
