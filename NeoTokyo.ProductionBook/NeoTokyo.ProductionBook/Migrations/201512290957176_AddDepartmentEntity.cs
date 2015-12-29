namespace NeoTokyo.ProductionBook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDepartmentEntity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Department",
                c => new
                    {
                        ID = c.Guid(nullable: false, identity: true),
                        Name = c.String(),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);

            Guid departmentID = Guid.NewGuid();
            String sqlDepartmentInsert = String.Format("INSERT Into dbo.Department (ID, Name, Active) VALUES ('{0}', 'Large Winding', 1)", departmentID.ToString());
            Sql(sqlDepartmentInsert);

            AddColumn("dbo.ResourceGroup", "DepartmentID", c => c.Guid(nullable: false, defaultValue: departmentID));
            CreateIndex("dbo.ResourceGroup", "DepartmentID");
            AddForeignKey("dbo.ResourceGroup", "DepartmentID", "dbo.Department", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ResourceGroup", "DepartmentID", "dbo.Department");
            DropIndex("dbo.ResourceGroup", new[] { "DepartmentID" });
            DropColumn("dbo.ResourceGroup", "DepartmentID");
            DropTable("dbo.Department");
        }
    }
}
