using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace testCore.Controllers
{
    public class TestController : Controller
    {
        public String  Index()
        {
            return "hi my name is toukky";
        }
        public IActionResult Welcome(string name)
        {
            ViewData["Name"] = name;
            return View();
        }
    }
}
