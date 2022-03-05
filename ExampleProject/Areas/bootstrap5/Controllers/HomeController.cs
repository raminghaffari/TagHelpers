using ExampleProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExampleProject.Areas.bootstrap5.Controllers
{
    [Area("bootstrap5")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly table_model table_Model;

        private readonly List<human> humen;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            this.table_Model = new table_model();
            humen = this.table_Model.GetHumen();
        }

        public IActionResult Index(int pagesize = 10, int pageindex = 1)
        {

            var takehuman = humen.Skip(pagesize * (pageindex - 1)).Take(pagesize);

            paginateddto paginateddto = new paginateddto()
            {
                totalrow = humen.Count,
                pageindex = pageindex,
                pagesize = pagesize,
                Humen = takehuman
            };


            return View(paginateddto);
        }
    }
}
