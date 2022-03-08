using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Docs.Controllers
{
    public class DocsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult BasicSetup()
        {
            return View();
        }

        public IActionResult Attributes()
        {
            return View();
        }

        public IActionResult NumberFormats()
        {
            return View();
        }

        public IActionResult Theme()
        {
            return View();
        }
    }
}
