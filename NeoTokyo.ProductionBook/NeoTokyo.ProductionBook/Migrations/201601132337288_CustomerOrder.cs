namespace NeoTokyo.ProductionBook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class CustomerOrder : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CustomerOrder",
                c => new
                    {
                        ID = c.Guid(nullable: false, identity: true),
                        CustomerID = c.Guid(nullable: false),
                        CustomerPONumber = c.String(),
                        OrderDate = c.DateTime(nullable: false),
                        Comments = c.String(),
                        CustomerOrderStatusID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Customer", t => t.CustomerID, cascadeDelete: false)
                .ForeignKey("dbo.CustomerOrderStatus", t => t.CustomerOrderStatusID, cascadeDelete: false)
                .Index(t => t.CustomerID)
                .Index(t => t.CustomerOrderStatusID);
            
            CreateTable(
                "dbo.CustomerOrderStatus",
                c => new
                    {
                        ID = c.Guid(nullable: false, identity: true),
                        Status = c.String(),
                        Description = c.String(),
                        Order = c.Int(nullable: false),
                        Finished = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.CustomerOrderStatusHistory",
                c => new
                    {
                        ID = c.Guid(nullable: false, identity: true),
                        CustomerOrderID = c.Guid(nullable: false),
                        CustomerOrderStatusID = c.Guid(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.CustomerOrder", t => t.CustomerOrderID, cascadeDelete: false)
                .ForeignKey("dbo.CustomerOrderStatus", t => t.CustomerOrderStatusID, cascadeDelete: false)
                .Index(t => t.CustomerOrderID)
                .Index(t => t.CustomerOrderStatusID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CustomerOrder", "CustomerOrderStatusID", "dbo.CustomerOrderStatus");
            DropForeignKey("dbo.CustomerOrderStatusHistory", "CustomerOrderStatusID", "dbo.CustomerOrderStatus");
            DropForeignKey("dbo.CustomerOrderStatusHistory", "CustomerOrderID", "dbo.CustomerOrder");
            DropForeignKey("dbo.CustomerOrder", "CustomerID", "dbo.Customer");
            DropIndex("dbo.CustomerOrderStatusHistory", new[] { "CustomerOrderStatusID" });
            DropIndex("dbo.CustomerOrderStatusHistory", new[] { "CustomerOrderID" });
            DropIndex("dbo.CustomerOrder", new[] { "CustomerOrderStatusID" });
            DropIndex("dbo.CustomerOrder", new[] { "CustomerID" });
            DropTable("dbo.CustomerOrderStatusHistory");
            DropTable("dbo.CustomerOrderStatus");
            DropTable("dbo.CustomerOrder");
        }
    }
}
