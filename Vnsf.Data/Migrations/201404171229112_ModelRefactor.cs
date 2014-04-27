namespace Vnsf.Data.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModelRefactor : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Person", "ContactId", "dbo.Contact");
            DropIndex("dbo.Person", new[] { "ContactId" });
            RenameColumn(table: "dbo.Organization", name: "ContactId", newName: "Contact_Id");
            RenameColumn(table: "dbo.Person", name: "ContactId", newName: "Contact_Id");
            RenameIndex(table: "dbo.Organization", name: "IX_ContactId", newName: "IX_Contact_Id");
            AddColumn("dbo.Organization", "OgranizationType_Id", c => c.Guid());
            AlterColumn("dbo.Person", "Contact_Id", c => c.Guid());
            CreateIndex("dbo.Organization", "OgranizationType_Id");
            CreateIndex("dbo.Person", "Contact_Id");
            AddForeignKey("dbo.Organization", "OgranizationType_Id", "dbo.Category", "Id");
            AddForeignKey("dbo.Person", "Contact_Id", "dbo.Contact", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Person", "Contact_Id", "dbo.Contact");
            DropForeignKey("dbo.Organization", "OgranizationType_Id", "dbo.Category");
            DropIndex("dbo.Person", new[] { "Contact_Id" });
            DropIndex("dbo.Organization", new[] { "OgranizationType_Id" });
            AlterColumn("dbo.Person", "Contact_Id", c => c.Guid(nullable: false));
            DropColumn("dbo.Organization", "OgranizationType_Id");
            RenameIndex(table: "dbo.Organization", name: "IX_Contact_Id", newName: "IX_ContactId");
            RenameColumn(table: "dbo.Person", name: "Contact_Id", newName: "ContactId");
            RenameColumn(table: "dbo.Organization", name: "Contact_Id", newName: "ContactId");
            CreateIndex("dbo.Person", "ContactId");
            AddForeignKey("dbo.Person", "ContactId", "dbo.Contact", "Id", cascadeDelete: true);
        }
    }
}
