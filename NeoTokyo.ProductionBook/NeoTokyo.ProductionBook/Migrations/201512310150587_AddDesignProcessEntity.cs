namespace NeoTokyo.ProductionBook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDesignProcessEntity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DesignProcess",
                c => new
                    {
                        ID = c.Guid(nullable: false, identity: true),
                        DesignID = c.Guid(nullable: false),
                        ProcessID = c.Guid(nullable: false),
                        DepartmentID = c.Guid(nullable: false),
                        ProcessTime = c.Int(nullable: false),
                        ProcessOrder = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Department", t => t.DepartmentID, cascadeDelete: true)
                .ForeignKey("dbo.Design", t => t.DesignID, cascadeDelete: true)
                .ForeignKey("dbo.Process", t => t.ProcessID, cascadeDelete: true)
                .Index(t => t.DesignID)
                .Index(t => t.ProcessID)
                .Index(t => t.DepartmentID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DesignProcess", "ProcessID", "dbo.Process");
            DropForeignKey("dbo.DesignProcess", "DesignID", "dbo.Design");
            DropForeignKey("dbo.DesignProcess", "DepartmentID", "dbo.Department");
            DropIndex("dbo.DesignProcess", new[] { "DepartmentID" });
            DropIndex("dbo.DesignProcess", new[] { "ProcessID" });
            DropIndex("dbo.DesignProcess", new[] { "DesignID" });
            DropTable("dbo.DesignProcess");
        }
    }
}
