namespace Vnsf.Data.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FrameworkUpdate : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Category", "ClassificationId", "dbo.Classification");
            DropIndex("dbo.Category", new[] { "ClassificationId" });
            RenameColumn(table: "dbo.Category", name: "ClassificationId", newName: "Classification_Id");
            AlterColumn("dbo.Category", "Classification_Id", c => c.Guid());
            CreateIndex("dbo.Category", "Classification_Id");
            AddForeignKey("dbo.Category", "Classification_Id", "dbo.Classification", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Category", "Classification_Id", "dbo.Classification");
            DropIndex("dbo.Category", new[] { "Classification_Id" });
            AlterColumn("dbo.Category", "Classification_Id", c => c.Guid(nullable: false));
            RenameColumn(table: "dbo.Category", name: "Classification_Id", newName: "ClassificationId");
            CreateIndex("dbo.Category", "ClassificationId");
            AddForeignKey("dbo.Category", "ClassificationId", "dbo.Classification", "Id", cascadeDelete: true);
        }
    }
}
