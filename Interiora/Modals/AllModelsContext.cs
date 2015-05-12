using System.Data.Entity;

namespace Modals
{
    public class AllModelsContext : DbContext
    {
        public DbSet<Furniture> FurnituresDb { get; set; }
        public DbSet<Supplier> SuppliersDb { get; set; }
        public DbSet<WebEquipment> WebEquipmentsDb { get; set; }
        public DbSet<TypeOfWebEquipment> TypeOfWebEquipmentDb { get; set; }

        public DbSet<FurnitureLocation> FurnitureLocationsDb { get; set; }
        public DbSet<Workspace> Workspaces { get; set; }
    }


}
