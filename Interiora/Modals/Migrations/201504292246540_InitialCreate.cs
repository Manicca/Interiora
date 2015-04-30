namespace Modals.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Furnitures",
                c => new
                    {
                        FurnitureId = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                        Article = c.String(),
                        Cost = c.String(),
                        Params = c.String(),
                        SupplierId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FurnitureId)
                .ForeignKey("dbo.Suppliers", t => t.SupplierId, cascadeDelete: true)
                .Index(t => t.SupplierId);
            
            CreateTable(
                "dbo.Suppliers",
                c => new
                    {
                        SupplierId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Mail = c.String(),
                        DG = c.String(),
                        Supplier_SupplierId = c.Int(),
                    })
                .PrimaryKey(t => t.SupplierId)
                .ForeignKey("dbo.Suppliers", t => t.Supplier_SupplierId)
                .Index(t => t.Supplier_SupplierId);
            
            CreateTable(
                "dbo.WebEquipments",
                c => new
                    {
                        WebEquipmentId = c.Int(nullable: false, identity: true),
                        Cost = c.String(),
                        Atributes = c.String(),
                        TypeOfWebEquipmentId = c.Int(nullable: false),
                        SupplierId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.WebEquipmentId)
                .ForeignKey("dbo.Suppliers", t => t.SupplierId, cascadeDelete: true)
                .ForeignKey("dbo.TypeOfWebEquipments", t => t.TypeOfWebEquipmentId, cascadeDelete: true)
                .Index(t => t.TypeOfWebEquipmentId)
                .Index(t => t.SupplierId);
            
            CreateTable(
                "dbo.TypeOfWebEquipments",
                c => new
                    {
                        TypeOfWebEquipmentId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.TypeOfWebEquipmentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Furnitures", "SupplierId", "dbo.Suppliers");
            DropForeignKey("dbo.WebEquipments", "TypeOfWebEquipmentId", "dbo.TypeOfWebEquipments");
            DropForeignKey("dbo.WebEquipments", "SupplierId", "dbo.Suppliers");
            DropForeignKey("dbo.Suppliers", "Supplier_SupplierId", "dbo.Suppliers");
            DropIndex("dbo.WebEquipments", new[] { "SupplierId" });
            DropIndex("dbo.WebEquipments", new[] { "TypeOfWebEquipmentId" });
            DropIndex("dbo.Suppliers", new[] { "Supplier_SupplierId" });
            DropIndex("dbo.Furnitures", new[] { "SupplierId" });
            DropTable("dbo.TypeOfWebEquipments");
            DropTable("dbo.WebEquipments");
            DropTable("dbo.Suppliers");
            DropTable("dbo.Furnitures");
        }
    }
}
