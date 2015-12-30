namespace NeoTokyo.ProductionBook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedDesignEntity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Design",
                c => new
                    {
                        ID = c.Guid(nullable: false, identity: true),
                        DesignerID = c.Guid(nullable: false),
                        Created = c.DateTime(nullable: false),
                        Active = c.Boolean(nullable: false),
                        DesignNumber = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Designer", t => t.DesignerID, cascadeDelete: true)
                .Index(t => t.DesignerID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Design", "DesignerID", "dbo.Designer");
            DropIndex("dbo.Design", new[] { "DesignerID" });
            DropTable("dbo.Design");
        }
    }
}
