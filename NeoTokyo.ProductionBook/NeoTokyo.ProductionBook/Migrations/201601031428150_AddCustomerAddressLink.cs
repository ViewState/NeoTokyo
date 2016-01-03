namespace NeoTokyo.ProductionBook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCustomerAddressLink : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CustomerAddressLink",
                c => new
                    {
                        ID = c.Guid(nullable: false, identity: true),
                        AddressID = c.Guid(nullable: false),
                        CustomerID = c.Guid(nullable: false),
                        AddressTypeInt = c.Int(nullable: false),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Address", t => t.AddressID, cascadeDelete: true)
                .ForeignKey("dbo.Customer", t => t.CustomerID, cascadeDelete: true)
                .Index(t => t.AddressID)
                .Index(t => t.CustomerID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CustomerAddressLink", "CustomerID", "dbo.Customer");
            DropForeignKey("dbo.CustomerAddressLink", "AddressID", "dbo.Address");
            DropIndex("dbo.CustomerAddressLink", new[] { "CustomerID" });
            DropIndex("dbo.CustomerAddressLink", new[] { "AddressID" });
            DropTable("dbo.CustomerAddressLink");
        }
    }
}
