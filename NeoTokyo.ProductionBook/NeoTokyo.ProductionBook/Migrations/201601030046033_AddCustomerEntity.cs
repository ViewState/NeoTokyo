namespace NeoTokyo.ProductionBook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCustomerEntity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customer",
                c => new
                    {
                        ID = c.Guid(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Customer");
        }
    }
}
