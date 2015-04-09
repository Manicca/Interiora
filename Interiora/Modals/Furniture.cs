using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    class Furniture
    {
        public string Type { get; set; }
        public string Article { get; set; }
        public string Cost { get; set; }
        public string Params { get; set; }
        public Supplier supplier;
    }
}
