namespace NeoTokyo.ProductionBook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedDesignerStaffIDToID : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Designer", name: "StaffID", newName: "ID");
            RenameIndex(table: "dbo.Designer", name: "IX_StaffID", newName: "IX_ID");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Designer", name: "IX_ID", newName: "IX_StaffID");
            RenameColumn(table: "dbo.Designer", name: "ID", newName: "StaffID");
        }
    }
}
