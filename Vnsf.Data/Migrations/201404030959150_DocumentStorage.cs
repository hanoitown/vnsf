namespace Vnsf.Data.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DocumentStorage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Document", "StorageId", c => c.Guid(nullable: false));
            CreateIndex("dbo.Document", "StorageId");
            AddForeignKey("dbo.Document", "StorageId", "dbo.Storage", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Document", "StorageId", "dbo.Storage");
            DropIndex("dbo.Document", new[] { "StorageId" });
            DropColumn("dbo.Document", "StorageId");
        }
    }
}
