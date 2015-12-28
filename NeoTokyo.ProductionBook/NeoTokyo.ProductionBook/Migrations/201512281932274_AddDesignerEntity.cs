namespace NeoTokyo.ProductionBook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDesignerEntity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Designer",
                c => new
                    {
                        StaffID = c.Guid(nullable: false),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.StaffID)
                .ForeignKey("dbo.Staff", t => t.StaffID)
                .Index(t => t.StaffID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Designer", "StaffID", "dbo.Staff");
            DropIndex("dbo.Designer", new[] { "StaffID" });
            DropTable("dbo.Designer");
        }
    }
}
