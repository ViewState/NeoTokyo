namespace NeoTokyo.ProductionBook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDefaultAddressEntities : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CustomerDefaultDeliveryAddress",
                c => new
                    {
                        CustomerID = c.Guid(nullable: false),
                        AddressID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.CustomerID)
                .ForeignKey("dbo.Address", t => t.AddressID, cascadeDelete: true)
                .ForeignKey("dbo.Customer", t => t.CustomerID)
                .Index(t => t.CustomerID)
                .Index(t => t.AddressID);
            
            CreateTable(
                "dbo.CustomerDefaultInvoiceAddress",
                c => new
                    {
                        CustomerID = c.Guid(nullable: false),
                        AddressID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.CustomerID)
                .ForeignKey("dbo.Address", t => t.AddressID, cascadeDelete: true)
                .ForeignKey("dbo.Customer", t => t.CustomerID)
                .Index(t => t.CustomerID)
                .Index(t => t.AddressID);
            
            DropColumn("dbo.CustomerAddressLink", "AddressTypeInt");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CustomerAddressLink", "AddressTypeInt", c => c.Int(nullable: false));
            DropForeignKey("dbo.CustomerDefaultInvoiceAddress", "CustomerID", "dbo.Customer");
            DropForeignKey("dbo.CustomerDefaultInvoiceAddress", "AddressID", "dbo.Address");
            DropForeignKey("dbo.CustomerDefaultDeliveryAddress", "CustomerID", "dbo.Customer");
            DropForeignKey("dbo.CustomerDefaultDeliveryAddress", "AddressID", "dbo.Address");
            DropIndex("dbo.CustomerDefaultInvoiceAddress", new[] { "AddressID" });
            DropIndex("dbo.CustomerDefaultInvoiceAddress", new[] { "CustomerID" });
            DropIndex("dbo.CustomerDefaultDeliveryAddress", new[] { "AddressID" });
            DropIndex("dbo.CustomerDefaultDeliveryAddress", new[] { "CustomerID" });
            DropTable("dbo.CustomerDefaultInvoiceAddress");
            DropTable("dbo.CustomerDefaultDeliveryAddress");
        }
    }
}
