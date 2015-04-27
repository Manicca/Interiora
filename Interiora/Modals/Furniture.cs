using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Furniture
    {
        public int FurnitureId { get; set; }
        public string Type { get; set; }
        public string Article { get; set; }
        public string Cost { get; set; }
        public string Params { get; set; }
         

        public int SupplierId { get; set; }
        public virtual Supplier Supplier { get; set; }
    }
}
