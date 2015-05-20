using System.Data.Entity;
using Models.Initializers;

namespace Models
{
    
    public class AllModelsContext : DbContext
    {

        public AllModelsContext() : base("AllModelsContext")
        {
            var ensureDllIsCopied = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
            Database.SetInitializer<AllModelsContext>(new TestDataDbInitializer());
        }
        public DbSet<Furniture> FurnitureDb { get; set; }
        public DbSet<Supplier> SupplierDb { get; set; }
        public DbSet<WebEquipment> WebEquipmentDb { get; set; }
        public DbSet<TypeOfWebEquipment> TypeOfWebEquipmentDb { get; set; }

        public DbSet<FurnitureLocation> FurnitureLocationDb { get; set; }
        public DbSet<Workspace> WorkspaceDb { get; set; }



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Configure domain classes using Fluent API here

            base.OnModelCreating(modelBuilder);
        }
    }


}
