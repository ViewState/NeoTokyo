namespace NeoTokyo.ProductionBook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddProcessEntity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Process",
                c => new
                    {
                        ID = c.Guid(nullable: false, identity: true),
                        Name = c.String(),
                        IsOvernightProcess = c.Boolean(nullable: false),
                        CompletedStatusText = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Process");
        }
    }
}
