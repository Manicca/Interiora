using System.Collections.Generic;

namespace Modals
{
     public class Supplier
     {
          public int SupplierId { get; set; }
          public string Name { get; set; }
          public string Mail { get; set; }
          public string DG { get; set; }
          public virtual List<Supplier> Suppliers { get; set; }
          public virtual List<WebEquipment> WebEquipment { get; set; }
          public Supplier(string Name, string Mail, string DG)
          {
               this.Name = Name;
               this.Mail = Mail;
               this.DG = DG;
          }
          public Supplier() { }
     }
}
