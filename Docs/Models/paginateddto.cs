using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Docs.Models
{
    public class paginateddto
    {
        public int totalrow { get; set; }
        public int pagesize { get; set; }
        public int pageindex { get; set; }
        public IEnumerable<human> Humen { get; set; }

    }
}
