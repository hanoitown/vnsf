namespace Vnsf.Data.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AgencyUpdate1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Storage",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Location = c.String(),
                        Name = c.String(),
                        Description = c.String(),
                        Created = c.DateTime(),
                        LastUpdated = c.DateTime(),
                        CreatedBy_ID = c.Guid(),
                        LastUpdatedBy_ID = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserAccount", t => t.CreatedBy_ID)
                .ForeignKey("dbo.UserAccount", t => t.LastUpdatedBy_ID)
                .Index(t => t.CreatedBy_ID)
                .Index(t => t.LastUpdatedBy_ID);
            
            AddColumn("dbo.DocumentFile", "Storage_Id", c => c.Guid());
            CreateIndex("dbo.DocumentFile", "Storage_Id");
            AddForeignKey("dbo.DocumentFile", "Storage_Id", "dbo.Storage", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Storage", "LastUpdatedBy_ID", "dbo.UserAccount");
            DropForeignKey("dbo.DocumentFile", "Storage_Id", "dbo.Storage");
            DropForeignKey("dbo.Storage", "CreatedBy_ID", "dbo.UserAccount");
            DropIndex("dbo.Storage", new[] { "LastUpdatedBy_ID" });
            DropIndex("dbo.DocumentFile", new[] { "Storage_Id" });
            DropIndex("dbo.Storage", new[] { "CreatedBy_ID" });
            DropColumn("dbo.DocumentFile", "Storage_Id");
            DropTable("dbo.Storage");
        }
    }
}
