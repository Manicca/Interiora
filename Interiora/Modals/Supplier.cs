﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
     public class Supplier
     {
          public int SupplierId { get; set; }
          public string Name { get; set; }
          public string Mail { get; set; }
          public string DG { get; set; }
          public virtual List<Supplier> Suppliers { get; set; }
          public virtual List<WebEquipment> WebEquipment { get; set; }
     }
}
