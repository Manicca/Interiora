using System.Data.Entity;
using System;
namespace Models
{
    public class AllModelsContext : DbContext
    {

        public AllModelsContext()
        {
            Database.Connection.ConnectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\Models\SampleDataBase.mdf;Integrated Security=True";
        }
        public DbSet<Furniture> FurnituresDb { get; set; }
        public DbSet<Supplier> SuppliersDb { get; set; }
        public DbSet<WebEquipment> WebEquipmentsDb { get; set; }
        public DbSet<TypeOfWebEquipment> TypeOfWebEquipmentDb { get; set; }

        public DbSet<FurnitureLocation> FurnitureLocationsDb { get; set; }
        public DbSet<Workspace> Workspaces { get; set; }
    }


}
