namespace NeoTokyo.ProductionBook.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class AddAddressCountryContactMethodEntities : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Address",
                c => new
                    {
                        ID = c.Guid(nullable: false, identity: true),
                        AddressName = c.String(),
                        AddressLine1 = c.String(),
                        AddressLine2 = c.String(),
                        Town = c.String(),
                        County = c.String(),
                        CountryID = c.Guid(nullable: false),
                        PostCode = c.String(),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Country", t => t.CountryID, cascadeDelete: true)
                .Index(t => t.CountryID);
            
            CreateTable(
                "dbo.Country",
                c => new
                    {
                        ID = c.Guid(nullable: false, identity: true),
                        CountryName = c.String(),
                        CountryCode = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ContactMethod",
                c => new
                    {
                        ID = c.Guid(nullable: false, identity: true),
                        ContactType = c.Short(nullable: false),
                        ContactTypeDetails = c.String(),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Address", "CountryID", "dbo.Country");
            DropIndex("dbo.Address", new[] { "CountryID" });
            DropTable("dbo.ContactMethod");
            DropTable("dbo.Country");
            DropTable("dbo.Address");
        }
    }
}
