namespace Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeWrongClient : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Suppliers", "Supplier_SupplierId", "dbo.Suppliers");
            DropIndex("dbo.Suppliers", new[] { "Supplier_SupplierId" });
            DropColumn("dbo.Suppliers", "Supplier_SupplierId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Suppliers", "Supplier_SupplierId", c => c.Int());
            CreateIndex("dbo.Suppliers", "Supplier_SupplierId");
            AddForeignKey("dbo.Suppliers", "Supplier_SupplierId", "dbo.Suppliers", "SupplierId");
        }
    }
}
