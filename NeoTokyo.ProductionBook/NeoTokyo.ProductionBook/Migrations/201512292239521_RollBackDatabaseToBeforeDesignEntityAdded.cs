namespace NeoTokyo.ProductionBook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RollBackDatabaseToBeforeDesignEntityAdded : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Design", "Designer_StaffID", "dbo.Designer");
            DropIndex("dbo.Design", new[] { "Designer_StaffID" });
            DropTable("dbo.Design");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Design",
                c => new
                    {
                        ID = c.Guid(nullable: false, identity: true),
                        DesignNumber = c.String(),
                        DesignerID = c.Guid(nullable: false),
                        Created = c.DateTime(nullable: false),
                        Active = c.Boolean(nullable: false),
                        Designer_StaffID = c.Guid(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateIndex("dbo.Design", "Designer_StaffID");
            AddForeignKey("dbo.Design", "Designer_StaffID", "dbo.Designer", "StaffID");
        }
    }
}
