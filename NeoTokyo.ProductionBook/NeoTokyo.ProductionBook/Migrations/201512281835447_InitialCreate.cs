namespace NeoTokyo.ProductionBook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ResourceGroup",
                c => new
                    {
                        ID = c.Guid(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.StaffResourceGroupLink",
                c => new
                    {
                        StaffID = c.Guid(nullable: false),
                        ResourceGroupID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.StaffID)
                .ForeignKey("dbo.ResourceGroup", t => t.ResourceGroupID, cascadeDelete: true)
                .ForeignKey("dbo.Staff", t => t.StaffID)
                .Index(t => t.StaffID)
                .Index(t => t.ResourceGroupID);
            
            CreateTable(
                "dbo.Staff",
                c => new
                    {
                        ID = c.Guid(nullable: false, identity: true),
                        FirstName = c.String(),
                        MiddleName = c.String(),
                        LastName = c.String(),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StaffResourceGroupLink", "StaffID", "dbo.Staff");
            DropForeignKey("dbo.StaffResourceGroupLink", "ResourceGroupID", "dbo.ResourceGroup");
            DropIndex("dbo.StaffResourceGroupLink", new[] { "ResourceGroupID" });
            DropIndex("dbo.StaffResourceGroupLink", new[] { "StaffID" });
            DropTable("dbo.Staff");
            DropTable("dbo.StaffResourceGroupLink");
            DropTable("dbo.ResourceGroup");
        }
    }
}
