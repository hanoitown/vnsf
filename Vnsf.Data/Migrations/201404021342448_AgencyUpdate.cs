namespace Vnsf.Data.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AgencyUpdate : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Organization", "ContactId", "dbo.Contact");
            DropIndex("dbo.Organization", new[] { "ContactId" });
            AddColumn("dbo.Organization", "IsActive", c => c.Boolean());
            AlterColumn("dbo.Organization", "ContactId", c => c.Guid());
            CreateIndex("dbo.Organization", "ContactId");
            AddForeignKey("dbo.Organization", "ContactId", "dbo.Contact", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Organization", "ContactId", "dbo.Contact");
            DropIndex("dbo.Organization", new[] { "ContactId" });
            AlterColumn("dbo.Organization", "ContactId", c => c.Guid(nullable: false));
            DropColumn("dbo.Organization", "IsActive");
            CreateIndex("dbo.Organization", "ContactId");
            AddForeignKey("dbo.Organization", "ContactId", "dbo.Contact", "Id", cascadeDelete: true);
        }
    }
}
