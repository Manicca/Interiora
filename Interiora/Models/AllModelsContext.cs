using System.Data.Entity;

namespace Models
{
    public class AllModelsContext : DbContext
    {

        public AllModelsContext()
        {
            Database.Connection.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=Modals.AllModelsContext;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False";
        }
        public DbSet<Furniture> FurnituresDb { get; set; }
        public DbSet<Supplier> SuppliersDb { get; set; }
        public DbSet<WebEquipment> WebEquipmentsDb { get; set; }
        public DbSet<TypeOfWebEquipment> TypeOfWebEquipmentDb { get; set; }

        public DbSet<FurnitureLocation> FurnitureLocationsDb { get; set; }
        public DbSet<Workspace> Workspaces { get; set; }
    }


}
