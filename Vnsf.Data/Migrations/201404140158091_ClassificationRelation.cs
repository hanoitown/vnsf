namespace Vnsf.Data.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ClassificationRelation : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Category", "Classification_Id", "dbo.Classification");
            DropIndex("dbo.Category", new[] { "Classification_Id" });
            AlterColumn("dbo.Category", "Classification_Id", c => c.Guid(nullable: false));
            CreateIndex("dbo.Category", "Classification_Id");
            AddForeignKey("dbo.Category", "Classification_Id", "dbo.Classification", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Category", "Classification_Id", "dbo.Classification");
            DropIndex("dbo.Category", new[] { "Classification_Id" });
            AlterColumn("dbo.Category", "Classification_Id", c => c.Guid());
            CreateIndex("dbo.Category", "Classification_Id");
            AddForeignKey("dbo.Category", "Classification_Id", "dbo.Classification", "Id");
        }
    }
}
