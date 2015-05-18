using System.Data.Entity.Migrations;

namespace Models.Migrations
{
    public partial class Add_new_tables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FurnitureLocations",
                c => new
                    {
                        FurnitureLocationId = c.Int(nullable: false, identity: true),
                        FurnitureId = c.Int(nullable: false),
                        WorkspaceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FurnitureLocationId)
                .ForeignKey("dbo.Furnitures", t => t.FurnitureId, cascadeDelete: true)
                .ForeignKey("dbo.Workspaces", t => t.WorkspaceId, cascadeDelete: true)
                .Index(t => t.FurnitureId)
                .Index(t => t.WorkspaceId);
            
            CreateTable(
                "dbo.Workspaces",
                c => new
                    {
                        WorkspaceId = c.Int(nullable: false, identity: true),
                        Name = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.WorkspaceId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FurnitureLocations", "WorkspaceId", "dbo.Workspaces");
            DropForeignKey("dbo.FurnitureLocations", "FurnitureId", "dbo.Furnitures");
            DropIndex("dbo.FurnitureLocations", new[] { "WorkspaceId" });
            DropIndex("dbo.FurnitureLocations", new[] { "FurnitureId" });
            DropTable("dbo.Workspaces");
            DropTable("dbo.FurnitureLocations");
        }
    }
}
