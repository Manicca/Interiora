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
          public Furniture() { }
          public Furniture(string type, string Article, string Cost, string Params, int SupplierId)
          {
               this.Article = Article;
               this.Cost = Cost;
               this.Params = Params;
               this.SupplierId = SupplierId;
          }

          public Furniture(int FurnitureId, string type, string Article, string Cost, string Params, Supplier supplier)
          {
               this.Article = Article;
               this.Cost = Cost;
               this.FurnitureId = FurnitureId;
               this.Params = Params;
               this.SupplierId = supplier.SupplierId;
               this.Supplier = supplier;
          }
     }
}
