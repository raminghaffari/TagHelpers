using Docs.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Docs.Controllers
{
    public class DemoController : Controller
    {
        private readonly table_model table_Model;
        private readonly List<human> humen;
        public DemoController()
        {
            this.table_Model = new table_model();
            humen = this.table_Model.GetHumen();
        }

        public IActionResult PaginationTagHelper(int pagesize = 10, int pageindex = 1)
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
