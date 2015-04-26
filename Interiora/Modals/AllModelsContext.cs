using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;


namespace Models
{
     public class AllModelsContext : DbContext
     {
          public DbSet<Furniture> FurnituresDb { get; set; }
          public DbSet<Supplier> SuppliersDb { get; set; }
          public DbSet<WebEquipment> WebEquipmentsDb { get; set; }
          public DbSet<TypeOfWebEquipment> TypeOfWebEquipmentDb { get; set; }
     }

    
}
