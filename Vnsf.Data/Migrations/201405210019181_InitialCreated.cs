namespace Vnsf.Data.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreated : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "vnsf.Category",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                        Classification_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("vnsf.Classification", t => t.Classification_Id, cascadeDelete: true)
                .Index(t => t.Classification_Id);
            
            CreateTable(
                "vnsf.CategoryChild",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Order = c.Int(nullable: false),
                        CategoryId = c.Guid(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                        Created = c.DateTime(),
                        LastUpdated = c.DateTime(),
                        User_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("vnsf.Category", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("vnsf.UserAccount", t => t.User_Id)
                .Index(t => t.CategoryId)
                .Index(t => t.User_Id);
            
            CreateTable(
                "vnsf.UserAccount",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Username = c.String(),
                        Email = c.String(),
                        Created = c.DateTime(nullable: false),
                        LastUpdated = c.DateTime(nullable: false),
                        PasswordChanged = c.DateTime(nullable: false),
                        IsAccountVerified = c.Boolean(nullable: false),
                        IsLoginAllowed = c.Boolean(nullable: false),
                        IsAccountClosed = c.Boolean(nullable: false),
                        AccountClosed = c.DateTime(),
                        LastLogin = c.DateTime(),
                        LastFailedLogin = c.DateTime(),
                        FailedLoginCount = c.Int(nullable: false),
                        VerificationKey = c.String(),
                        VerificationPurpose = c.Int(),
                        VerificationKeySent = c.DateTime(),
                        HashedPassword = c.String(),
                        MobilePhoneNumber = c.String(),
                        MobileCode = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "vnsf.Application",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Status = c.Int(nullable: false),
                        BudgetTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BudgetApply = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OpportunityId = c.Guid(nullable: false),
                        UserAccount_Id = c.Guid(),
                        Researcher_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("vnsf.Opportunity", t => t.OpportunityId, cascadeDelete: true)
                .ForeignKey("vnsf.UserAccount", t => t.UserAccount_Id)
                .ForeignKey("vnsf.Person", t => t.Researcher_Id)
                .Index(t => t.OpportunityId)
                .Index(t => t.UserAccount_Id)
                .Index(t => t.Researcher_Id);
            
            CreateTable(
                "vnsf.Opportunity",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        Deadline = c.DateTime(nullable: false),
                        MaxDuration = c.Int(nullable: false),
                        EstimateTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AwardCeiling = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AwardFloor = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Status = c.Int(nullable: false),
                        GrantId = c.Guid(nullable: false),
                        ClassificationId = c.Guid(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                        Created = c.DateTime(),
                        LastUpdated = c.DateTime(),
                        User_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("vnsf.Classification", t => t.ClassificationId, cascadeDelete: true)
                .ForeignKey("vnsf.Grant", t => t.GrantId, cascadeDelete: true)
                .ForeignKey("vnsf.UserAccount", t => t.User_Id)
                .Index(t => t.GrantId)
                .Index(t => t.ClassificationId)
                .Index(t => t.User_Id);
            
            CreateTable(
                "vnsf.Announcement",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Content = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        Deadline = c.DateTime(nullable: false),
                        MaxDuration = c.Int(nullable: false),
                        EstimateTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AwardCeiling = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AwardFloor = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PostDate = c.DateTime(nullable: false),
                        OpportunityId = c.Guid(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                        Created = c.DateTime(),
                        LastUpdated = c.DateTime(),
                        User_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("vnsf.Opportunity", t => t.OpportunityId, cascadeDelete: true)
                .ForeignKey("vnsf.UserAccount", t => t.User_Id)
                .Index(t => t.OpportunityId)
                .Index(t => t.User_Id);
            
            CreateTable(
                "vnsf.AnnouncementVersion",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Content = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        Deadline = c.DateTime(nullable: false),
                        MaxDuration = c.Int(nullable: false),
                        EstimateTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AwardCeiling = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AwardFloor = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PostDate = c.DateTime(nullable: false),
                        Version = c.Int(nullable: false),
                        AnnouncementId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("vnsf.Announcement", t => t.AnnouncementId, cascadeDelete: true)
                .Index(t => t.AnnouncementId);
            
            CreateTable(
                "vnsf.Award",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        AwardDate = c.String(),
                        TotalAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Name = c.String(),
                        Description = c.String(),
                        Created = c.DateTime(),
                        LastUpdated = c.DateTime(),
                        Application_Id = c.Guid(),
                        User_Id = c.Guid(),
                        Opportunity_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("vnsf.Application", t => t.Application_Id)
                .ForeignKey("vnsf.UserAccount", t => t.User_Id)
                .ForeignKey("vnsf.Opportunity", t => t.Opportunity_Id)
                .Index(t => t.Application_Id)
                .Index(t => t.User_Id)
                .Index(t => t.Opportunity_Id);
            
            CreateTable(
                "vnsf.Report",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Status = c.String(),
                        DeadLine = c.DateTime(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                        Created = c.DateTime(),
                        LastUpdated = c.DateTime(),
                        Category_Id = c.Guid(),
                        ReportCategory_Id = c.Guid(),
                        User_Id = c.Guid(),
                        Award_Id = c.Guid(),
                        Contract_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("vnsf.Category", t => t.Category_Id)
                .ForeignKey("vnsf.Category", t => t.ReportCategory_Id)
                .ForeignKey("vnsf.UserAccount", t => t.User_Id)
                .ForeignKey("vnsf.Award", t => t.Award_Id)
                .ForeignKey("vnsf.Contract", t => t.Contract_Id)
                .Index(t => t.Category_Id)
                .Index(t => t.ReportCategory_Id)
                .Index(t => t.User_Id)
                .Index(t => t.Award_Id)
                .Index(t => t.Contract_Id);
            
            CreateTable(
                "vnsf.ReportVersion",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Target = c.String(),
                        Scope = c.String(),
                        Result = c.String(),
                        Change = c.String(),
                        Report_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("vnsf.Report", t => t.Report_Id)
                .Index(t => t.Report_Id);
            
            CreateTable(
                "vnsf.Education",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Program = c.String(),
                        Level = c.Int(nullable: false),
                        OtherOrganization = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        ParticipationDuration = c.Int(nullable: false),
                        Description = c.String(),
                        Created = c.DateTime(),
                        LastUpdated = c.DateTime(),
                        Field_Id = c.Guid(),
                        Organization_Id = c.Guid(),
                        User_Id = c.Guid(),
                        ReportVersion_Id = c.Guid(),
                        Researcher_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("vnsf.Category", t => t.Field_Id)
                .ForeignKey("vnsf.Organization", t => t.Organization_Id)
                .ForeignKey("vnsf.UserAccount", t => t.User_Id)
                .ForeignKey("vnsf.ReportVersion", t => t.ReportVersion_Id)
                .ForeignKey("vnsf.Person", t => t.Researcher_Id)
                .Index(t => t.Field_Id)
                .Index(t => t.Organization_Id)
                .Index(t => t.User_Id)
                .Index(t => t.ReportVersion_Id)
                .Index(t => t.Researcher_Id);
            
            CreateTable(
                "vnsf.Organization",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        ShortName = c.String(),
                        IsStateOwn = c.Boolean(),
                        IsPublic = c.Boolean(),
                        IsActive = c.Boolean(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        Contact_Id = c.Guid(),
                        OgranizationType_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("vnsf.Contact", t => t.Contact_Id)
                .ForeignKey("vnsf.Category", t => t.OgranizationType_Id)
                .Index(t => t.Contact_Id)
                .Index(t => t.OgranizationType_Id);
            
            CreateTable(
                "vnsf.Contact",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Phone = c.String(),
                        Email = c.String(),
                        PostalAddress_Street1 = c.String(),
                        PostalAddress_Street2 = c.String(),
                        PostalAddress_City = c.String(),
                        PostalAddress_Country = c.String(),
                        PostalAddress_ZipCode = c.String(),
                        VisitingAddress_Street1 = c.String(),
                        VisitingAddress_Street2 = c.String(),
                        VisitingAddress_City = c.String(),
                        VisitingAddress_Country = c.String(),
                        VisitingAddress_ZipCode = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "vnsf.OrganizationUnit",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ParentId = c.Guid(nullable: false),
                        Depth = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("vnsf.Organization", t => t.ParentId, cascadeDelete: true)
                .Index(t => t.ParentId);
            
            CreateTable(
                "vnsf.Expense",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Code = c.String(),
                        Quantity = c.Int(nullable: false),
                        Value = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Name = c.String(),
                        Description = c.String(),
                        Created = c.DateTime(),
                        LastUpdated = c.DateTime(),
                        Category_Id = c.Guid(),
                        Unit_Id = c.Guid(),
                        User_Id = c.Guid(),
                        ReportVersion_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("vnsf.Category", t => t.Category_Id)
                .ForeignKey("vnsf.MeasurementUnit", t => t.Unit_Id)
                .ForeignKey("vnsf.UserAccount", t => t.User_Id)
                .ForeignKey("vnsf.ReportVersion", t => t.ReportVersion_Id)
                .Index(t => t.Category_Id)
                .Index(t => t.Unit_Id)
                .Index(t => t.User_Id)
                .Index(t => t.ReportVersion_Id);
            
            CreateTable(
                "vnsf.MeasurementUnit",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                        Created = c.DateTime(),
                        LastUpdated = c.DateTime(),
                        User_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("vnsf.UserAccount", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "vnsf.Publication",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Title = c.String(),
                        Author = c.String(),
                        Date = c.DateTime(nullable: false),
                        ISSN = c.String(),
                        OtherOganization = c.String(),
                        Name = c.String(),
                        Description = c.String(),
                        Created = c.DateTime(),
                        LastUpdated = c.DateTime(),
                        Category_Id = c.Guid(),
                        Document_Id = c.Guid(),
                        Organization_Id = c.Guid(),
                        User_Id = c.Guid(),
                        ReportVersion_Id = c.Guid(),
                        Researcher_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("vnsf.Category", t => t.Category_Id)
                .ForeignKey("vnsf.Doc", t => t.Document_Id)
                .ForeignKey("vnsf.Organization", t => t.Organization_Id)
                .ForeignKey("vnsf.UserAccount", t => t.User_Id)
                .ForeignKey("vnsf.ReportVersion", t => t.ReportVersion_Id)
                .ForeignKey("vnsf.Person", t => t.Researcher_Id)
                .Index(t => t.Category_Id)
                .Index(t => t.Document_Id)
                .Index(t => t.Organization_Id)
                .Index(t => t.User_Id)
                .Index(t => t.ReportVersion_Id)
                .Index(t => t.Researcher_Id);
            
            CreateTable(
                "vnsf.Doc",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                        ContentType = c.String(),
                        ContentLength = c.Int(nullable: false),
                        IsFolder = c.Boolean(nullable: false),
                        Path = c.String(),
                        Parent_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("vnsf.Doc", t => t.Parent_Id)
                .Index(t => t.Parent_Id);
            
            CreateTable(
                "vnsf.DocProtection",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        SecurityCode = c.String(),
                        Doc_Id = c.Guid(),
                        Permission_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("vnsf.Doc", t => t.Doc_Id)
                .ForeignKey("vnsf.Permission", t => t.Permission_Id)
                .Index(t => t.Doc_Id)
                .Index(t => t.Permission_Id);
            
            CreateTable(
                "vnsf.Permission",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                        Allow = c.Boolean(nullable: false),
                        Deny = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "vnsf.DocShare",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ExpireDate = c.DateTime(nullable: false),
                        SecurityCode = c.String(),
                        Account_Id = c.Guid(),
                        Document_Id = c.Guid(),
                        Right_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("vnsf.UserAccount", t => t.Account_Id)
                .ForeignKey("vnsf.Doc", t => t.Document_Id)
                .ForeignKey("vnsf.Permission", t => t.Right_Id)
                .Index(t => t.Account_Id)
                .Index(t => t.Document_Id)
                .Index(t => t.Right_Id);
            
            CreateTable(
                "vnsf.Classification",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                        Created = c.DateTime(),
                        LastUpdated = c.DateTime(),
                        User_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("vnsf.UserAccount", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "vnsf.Contract",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                        Created = c.DateTime(),
                        LastUpdated = c.DateTime(),
                        Application_Id = c.Guid(),
                        User_Id = c.Guid(),
                        Opportunity_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("vnsf.Application", t => t.Application_Id)
                .ForeignKey("vnsf.UserAccount", t => t.User_Id)
                .ForeignKey("vnsf.Opportunity", t => t.Opportunity_Id)
                .Index(t => t.Application_Id)
                .Index(t => t.User_Id)
                .Index(t => t.Opportunity_Id);
            
            CreateTable(
                "vnsf.ChangeRequest",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Value = c.String(),
                        ValueType = c.String(),
                        Name = c.String(),
                        Description = c.String(),
                        Created = c.DateTime(),
                        LastUpdated = c.DateTime(),
                        Category_Id = c.Guid(),
                        User_Id = c.Guid(),
                        Contract_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("vnsf.Category", t => t.Category_Id)
                .ForeignKey("vnsf.UserAccount", t => t.User_Id)
                .ForeignKey("vnsf.Contract", t => t.Contract_Id)
                .Index(t => t.Category_Id)
                .Index(t => t.User_Id)
                .Index(t => t.Contract_Id);
            
            CreateTable(
                "vnsf.Grant",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Code = c.String(),
                        Objective = c.String(),
                        MaxDuration = c.Int(nullable: false),
                        Total = c.Double(nullable: false),
                        MaxAward = c.Int(nullable: false),
                        AgencyId = c.Guid(),
                        Name = c.String(),
                        Description = c.String(),
                        Created = c.DateTime(),
                        LastUpdated = c.DateTime(),
                        ClassificationSystem_Id = c.Guid(),
                        Logo_Id = c.Guid(),
                        User_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("vnsf.Organization", t => t.AgencyId)
                .ForeignKey("vnsf.Classification", t => t.ClassificationSystem_Id)
                .ForeignKey("vnsf.Doc", t => t.Logo_Id)
                .ForeignKey("vnsf.UserAccount", t => t.User_Id)
                .Index(t => t.AgencyId)
                .Index(t => t.ClassificationSystem_Id)
                .Index(t => t.Logo_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "vnsf.GrantLocalized",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Objective = c.String(),
                        CultureId = c.Guid(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                        Grant_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("vnsf.Culture", t => t.CultureId, cascadeDelete: true)
                .ForeignKey("vnsf.Grant", t => t.Grant_Id)
                .Index(t => t.CultureId)
                .Index(t => t.Grant_Id);
            
            CreateTable(
                "vnsf.Culture",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Code = c.String(),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "vnsf.LocalizedCulture",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        CultureId = c.Guid(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("vnsf.Culture", t => t.CultureId, cascadeDelete: true)
                .Index(t => t.CultureId);
            
            CreateTable(
                "vnsf.Panel",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FromDate = c.DateTime(nullable: false),
                        ToDate = c.DateTime(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                        Created = c.DateTime(),
                        LastUpdated = c.DateTime(),
                        Opportunity_Id = c.Guid(),
                        User_Id = c.Guid(),
                        Grant_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("vnsf.Opportunity", t => t.Opportunity_Id)
                .ForeignKey("vnsf.UserAccount", t => t.User_Id)
                .ForeignKey("vnsf.Grant", t => t.Grant_Id)
                .Index(t => t.Opportunity_Id)
                .Index(t => t.User_Id)
                .Index(t => t.Grant_Id);
            
            CreateTable(
                "vnsf.Person",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FullName_FirsName = c.String(),
                        FullName_LastName = c.String(),
                        BirthDay = c.DateTime(),
                        Gender = c.Boolean(nullable: false),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        PanelMemberRole_Id = c.Guid(),
                        Panel_Id = c.Guid(),
                        Account_Id = c.Guid(),
                        BankAccount_Id = c.Guid(),
                        Contact_Id = c.Guid(),
                        Organization_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("vnsf.PanelMemberRole", t => t.PanelMemberRole_Id)
                .ForeignKey("vnsf.Panel", t => t.Panel_Id)
                .ForeignKey("vnsf.UserAccount", t => t.Account_Id)
                .ForeignKey("vnsf.BankAccount", t => t.BankAccount_Id)
                .ForeignKey("vnsf.Contact", t => t.Contact_Id)
                .ForeignKey("vnsf.Organization", t => t.Organization_Id)
                .Index(t => t.PanelMemberRole_Id)
                .Index(t => t.Panel_Id)
                .Index(t => t.Account_Id)
                .Index(t => t.BankAccount_Id)
                .Index(t => t.Contact_Id)
                .Index(t => t.Organization_Id);
            
            CreateTable(
                "vnsf.BankAccount",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        AccountNo = c.String(),
                        Name = c.String(),
                        Description = c.String(),
                        Created = c.DateTime(),
                        LastUpdated = c.DateTime(),
                        User_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("vnsf.UserAccount", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "vnsf.Job",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Position = c.String(),
                        QuitReseason = c.String(),
                        FromDate = c.DateTime(nullable: false),
                        ToDate = c.DateTime(),
                        Company = c.String(),
                        Name = c.String(),
                        Description = c.String(),
                        Created = c.DateTime(),
                        LastUpdated = c.DateTime(),
                        Organization_Id = c.Guid(),
                        User_Id = c.Guid(),
                        Researcher_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("vnsf.Organization", t => t.Organization_Id)
                .ForeignKey("vnsf.UserAccount", t => t.User_Id)
                .ForeignKey("vnsf.Person", t => t.Researcher_Id)
                .Index(t => t.Organization_Id)
                .Index(t => t.User_Id)
                .Index(t => t.Researcher_Id);
            
            CreateTable(
                "vnsf.PanelMemberRole",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                        Created = c.DateTime(),
                        LastUpdated = c.DateTime(),
                        User_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("vnsf.UserAccount", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "vnsf.UserCertificate",
                c => new
                    {
                        UserAccountID = c.Guid(nullable: false),
                        Thumbprint = c.String(nullable: false, maxLength: 150),
                        Subject = c.String(maxLength: 250),
                    })
                .PrimaryKey(t => new { t.UserAccountID, t.Thumbprint })
                .ForeignKey("vnsf.UserAccount", t => t.UserAccountID, cascadeDelete: true)
                .Index(t => t.UserAccountID);
            
            CreateTable(
                "vnsf.UserClaim",
                c => new
                    {
                        UserAccountID = c.Guid(nullable: false),
                        Type = c.String(nullable: false, maxLength: 150),
                        Value = c.String(nullable: false, maxLength: 150),
                    })
                .PrimaryKey(t => new { t.UserAccountID, t.Type, t.Value })
                .ForeignKey("vnsf.UserAccount", t => t.UserAccountID, cascadeDelete: true)
                .Index(t => t.UserAccountID);
            
            CreateTable(
                "vnsf.LinkedAccount",
                c => new
                    {
                        UserAccountID = c.Guid(nullable: false),
                        ProviderName = c.String(nullable: false, maxLength: 50),
                        ProviderAccountID = c.String(nullable: false, maxLength: 100),
                        LastLogin = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserAccountID, t.ProviderName, t.ProviderAccountID })
                .ForeignKey("vnsf.UserAccount", t => t.UserAccountID, cascadeDelete: true)
                .Index(t => t.UserAccountID);
            
            CreateTable(
                "vnsf.LinkedAccountClaim",
                c => new
                    {
                        UserAccountID = c.Guid(nullable: false),
                        ProviderName = c.String(nullable: false, maxLength: 50),
                        ProviderAccountID = c.String(nullable: false, maxLength: 100),
                        Type = c.String(nullable: false, maxLength: 150),
                        Value = c.String(maxLength: 150),
                    })
                .PrimaryKey(t => new { t.UserAccountID, t.ProviderName, t.ProviderAccountID, t.Type })
                .ForeignKey("vnsf.LinkedAccount", t => new { t.UserAccountID, t.ProviderName, t.ProviderAccountID }, cascadeDelete: true)
                .Index(t => new { t.UserAccountID, t.ProviderName, t.ProviderAccountID });
            
            CreateTable(
                "vnsf.Storage",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Location = c.String(),
                        Name = c.String(),
                        Description = c.String(),
                        Created = c.DateTime(),
                        LastUpdated = c.DateTime(),
                        User_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("vnsf.UserAccount", t => t.User_Id)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("vnsf.Storage", "User_Id", "vnsf.UserAccount");
            DropForeignKey("vnsf.Publication", "Researcher_Id", "vnsf.Person");
            DropForeignKey("vnsf.Person", "Organization_Id", "vnsf.Organization");
            DropForeignKey("vnsf.Job", "Researcher_Id", "vnsf.Person");
            DropForeignKey("vnsf.Education", "Researcher_Id", "vnsf.Person");
            DropForeignKey("vnsf.Application", "Researcher_Id", "vnsf.Person");
            DropForeignKey("vnsf.Person", "Contact_Id", "vnsf.Contact");
            DropForeignKey("vnsf.Person", "BankAccount_Id", "vnsf.BankAccount");
            DropForeignKey("vnsf.Person", "Account_Id", "vnsf.UserAccount");
            DropForeignKey("vnsf.CategoryChild", "User_Id", "vnsf.UserAccount");
            DropForeignKey("vnsf.LinkedAccount", "UserAccountID", "vnsf.UserAccount");
            DropForeignKey("vnsf.LinkedAccountClaim", new[] { "UserAccountID", "ProviderName", "ProviderAccountID" }, "vnsf.LinkedAccount");
            DropForeignKey("vnsf.UserClaim", "UserAccountID", "vnsf.UserAccount");
            DropForeignKey("vnsf.UserCertificate", "UserAccountID", "vnsf.UserAccount");
            DropForeignKey("vnsf.Application", "UserAccount_Id", "vnsf.UserAccount");
            DropForeignKey("vnsf.Opportunity", "User_Id", "vnsf.UserAccount");
            DropForeignKey("vnsf.Grant", "User_Id", "vnsf.UserAccount");
            DropForeignKey("vnsf.Panel", "Grant_Id", "vnsf.Grant");
            DropForeignKey("vnsf.Panel", "User_Id", "vnsf.UserAccount");
            DropForeignKey("vnsf.Panel", "Opportunity_Id", "vnsf.Opportunity");
            DropForeignKey("vnsf.Person", "Panel_Id", "vnsf.Panel");
            DropForeignKey("vnsf.PanelMemberRole", "User_Id", "vnsf.UserAccount");
            DropForeignKey("vnsf.Person", "PanelMemberRole_Id", "vnsf.PanelMemberRole");
            DropForeignKey("vnsf.Job", "User_Id", "vnsf.UserAccount");
            DropForeignKey("vnsf.Job", "Organization_Id", "vnsf.Organization");
            DropForeignKey("vnsf.BankAccount", "User_Id", "vnsf.UserAccount");
            DropForeignKey("vnsf.Opportunity", "GrantId", "vnsf.Grant");
            DropForeignKey("vnsf.Grant", "Logo_Id", "vnsf.Doc");
            DropForeignKey("vnsf.GrantLocalized", "Grant_Id", "vnsf.Grant");
            DropForeignKey("vnsf.GrantLocalized", "CultureId", "vnsf.Culture");
            DropForeignKey("vnsf.LocalizedCulture", "CultureId", "vnsf.Culture");
            DropForeignKey("vnsf.Grant", "ClassificationSystem_Id", "vnsf.Classification");
            DropForeignKey("vnsf.Grant", "AgencyId", "vnsf.Organization");
            DropForeignKey("vnsf.Contract", "Opportunity_Id", "vnsf.Opportunity");
            DropForeignKey("vnsf.Contract", "User_Id", "vnsf.UserAccount");
            DropForeignKey("vnsf.Report", "Contract_Id", "vnsf.Contract");
            DropForeignKey("vnsf.ChangeRequest", "Contract_Id", "vnsf.Contract");
            DropForeignKey("vnsf.ChangeRequest", "User_Id", "vnsf.UserAccount");
            DropForeignKey("vnsf.ChangeRequest", "Category_Id", "vnsf.Category");
            DropForeignKey("vnsf.Contract", "Application_Id", "vnsf.Application");
            DropForeignKey("vnsf.Opportunity", "ClassificationId", "vnsf.Classification");
            DropForeignKey("vnsf.Classification", "User_Id", "vnsf.UserAccount");
            DropForeignKey("vnsf.Category", "Classification_Id", "vnsf.Classification");
            DropForeignKey("vnsf.Award", "Opportunity_Id", "vnsf.Opportunity");
            DropForeignKey("vnsf.Award", "User_Id", "vnsf.UserAccount");
            DropForeignKey("vnsf.Report", "Award_Id", "vnsf.Award");
            DropForeignKey("vnsf.ReportVersion", "Report_Id", "vnsf.Report");
            DropForeignKey("vnsf.Publication", "ReportVersion_Id", "vnsf.ReportVersion");
            DropForeignKey("vnsf.Publication", "User_Id", "vnsf.UserAccount");
            DropForeignKey("vnsf.Publication", "Organization_Id", "vnsf.Organization");
            DropForeignKey("vnsf.Publication", "Document_Id", "vnsf.Doc");
            DropForeignKey("vnsf.DocShare", "Right_Id", "vnsf.Permission");
            DropForeignKey("vnsf.DocShare", "Document_Id", "vnsf.Doc");
            DropForeignKey("vnsf.DocShare", "Account_Id", "vnsf.UserAccount");
            DropForeignKey("vnsf.DocProtection", "Permission_Id", "vnsf.Permission");
            DropForeignKey("vnsf.DocProtection", "Doc_Id", "vnsf.Doc");
            DropForeignKey("vnsf.Doc", "Parent_Id", "vnsf.Doc");
            DropForeignKey("vnsf.Publication", "Category_Id", "vnsf.Category");
            DropForeignKey("vnsf.Expense", "ReportVersion_Id", "vnsf.ReportVersion");
            DropForeignKey("vnsf.Expense", "User_Id", "vnsf.UserAccount");
            DropForeignKey("vnsf.MeasurementUnit", "User_Id", "vnsf.UserAccount");
            DropForeignKey("vnsf.Expense", "Unit_Id", "vnsf.MeasurementUnit");
            DropForeignKey("vnsf.Expense", "Category_Id", "vnsf.Category");
            DropForeignKey("vnsf.Education", "ReportVersion_Id", "vnsf.ReportVersion");
            DropForeignKey("vnsf.Education", "User_Id", "vnsf.UserAccount");
            DropForeignKey("vnsf.Education", "Organization_Id", "vnsf.Organization");
            DropForeignKey("vnsf.OrganizationUnit", "ParentId", "vnsf.Organization");
            DropForeignKey("vnsf.Organization", "OgranizationType_Id", "vnsf.Category");
            DropForeignKey("vnsf.Organization", "Contact_Id", "vnsf.Contact");
            DropForeignKey("vnsf.Education", "Field_Id", "vnsf.Category");
            DropForeignKey("vnsf.Report", "User_Id", "vnsf.UserAccount");
            DropForeignKey("vnsf.Report", "ReportCategory_Id", "vnsf.Category");
            DropForeignKey("vnsf.Report", "Category_Id", "vnsf.Category");
            DropForeignKey("vnsf.Award", "Application_Id", "vnsf.Application");
            DropForeignKey("vnsf.Application", "OpportunityId", "vnsf.Opportunity");
            DropForeignKey("vnsf.AnnouncementVersion", "AnnouncementId", "vnsf.Announcement");
            DropForeignKey("vnsf.Announcement", "User_Id", "vnsf.UserAccount");
            DropForeignKey("vnsf.Announcement", "OpportunityId", "vnsf.Opportunity");
            DropForeignKey("vnsf.CategoryChild", "CategoryId", "vnsf.Category");
            DropIndex("vnsf.Storage", new[] { "User_Id" });
            DropIndex("vnsf.LinkedAccountClaim", new[] { "UserAccountID", "ProviderName", "ProviderAccountID" });
            DropIndex("vnsf.LinkedAccount", new[] { "UserAccountID" });
            DropIndex("vnsf.UserClaim", new[] { "UserAccountID" });
            DropIndex("vnsf.UserCertificate", new[] { "UserAccountID" });
            DropIndex("vnsf.PanelMemberRole", new[] { "User_Id" });
            DropIndex("vnsf.Job", new[] { "Researcher_Id" });
            DropIndex("vnsf.Job", new[] { "User_Id" });
            DropIndex("vnsf.Job", new[] { "Organization_Id" });
            DropIndex("vnsf.BankAccount", new[] { "User_Id" });
            DropIndex("vnsf.Person", new[] { "Organization_Id" });
            DropIndex("vnsf.Person", new[] { "Contact_Id" });
            DropIndex("vnsf.Person", new[] { "BankAccount_Id" });
            DropIndex("vnsf.Person", new[] { "Account_Id" });
            DropIndex("vnsf.Person", new[] { "Panel_Id" });
            DropIndex("vnsf.Person", new[] { "PanelMemberRole_Id" });
            DropIndex("vnsf.Panel", new[] { "Grant_Id" });
            DropIndex("vnsf.Panel", new[] { "User_Id" });
            DropIndex("vnsf.Panel", new[] { "Opportunity_Id" });
            DropIndex("vnsf.LocalizedCulture", new[] { "CultureId" });
            DropIndex("vnsf.GrantLocalized", new[] { "Grant_Id" });
            DropIndex("vnsf.GrantLocalized", new[] { "CultureId" });
            DropIndex("vnsf.Grant", new[] { "User_Id" });
            DropIndex("vnsf.Grant", new[] { "Logo_Id" });
            DropIndex("vnsf.Grant", new[] { "ClassificationSystem_Id" });
            DropIndex("vnsf.Grant", new[] { "AgencyId" });
            DropIndex("vnsf.ChangeRequest", new[] { "Contract_Id" });
            DropIndex("vnsf.ChangeRequest", new[] { "User_Id" });
            DropIndex("vnsf.ChangeRequest", new[] { "Category_Id" });
            DropIndex("vnsf.Contract", new[] { "Opportunity_Id" });
            DropIndex("vnsf.Contract", new[] { "User_Id" });
            DropIndex("vnsf.Contract", new[] { "Application_Id" });
            DropIndex("vnsf.Classification", new[] { "User_Id" });
            DropIndex("vnsf.DocShare", new[] { "Right_Id" });
            DropIndex("vnsf.DocShare", new[] { "Document_Id" });
            DropIndex("vnsf.DocShare", new[] { "Account_Id" });
            DropIndex("vnsf.DocProtection", new[] { "Permission_Id" });
            DropIndex("vnsf.DocProtection", new[] { "Doc_Id" });
            DropIndex("vnsf.Doc", new[] { "Parent_Id" });
            DropIndex("vnsf.Publication", new[] { "Researcher_Id" });
            DropIndex("vnsf.Publication", new[] { "ReportVersion_Id" });
            DropIndex("vnsf.Publication", new[] { "User_Id" });
            DropIndex("vnsf.Publication", new[] { "Organization_Id" });
            DropIndex("vnsf.Publication", new[] { "Document_Id" });
            DropIndex("vnsf.Publication", new[] { "Category_Id" });
            DropIndex("vnsf.MeasurementUnit", new[] { "User_Id" });
            DropIndex("vnsf.Expense", new[] { "ReportVersion_Id" });
            DropIndex("vnsf.Expense", new[] { "User_Id" });
            DropIndex("vnsf.Expense", new[] { "Unit_Id" });
            DropIndex("vnsf.Expense", new[] { "Category_Id" });
            DropIndex("vnsf.OrganizationUnit", new[] { "ParentId" });
            DropIndex("vnsf.Organization", new[] { "OgranizationType_Id" });
            DropIndex("vnsf.Organization", new[] { "Contact_Id" });
            DropIndex("vnsf.Education", new[] { "Researcher_Id" });
            DropIndex("vnsf.Education", new[] { "ReportVersion_Id" });
            DropIndex("vnsf.Education", new[] { "User_Id" });
            DropIndex("vnsf.Education", new[] { "Organization_Id" });
            DropIndex("vnsf.Education", new[] { "Field_Id" });
            DropIndex("vnsf.ReportVersion", new[] { "Report_Id" });
            DropIndex("vnsf.Report", new[] { "Contract_Id" });
            DropIndex("vnsf.Report", new[] { "Award_Id" });
            DropIndex("vnsf.Report", new[] { "User_Id" });
            DropIndex("vnsf.Report", new[] { "ReportCategory_Id" });
            DropIndex("vnsf.Report", new[] { "Category_Id" });
            DropIndex("vnsf.Award", new[] { "Opportunity_Id" });
            DropIndex("vnsf.Award", new[] { "User_Id" });
            DropIndex("vnsf.Award", new[] { "Application_Id" });
            DropIndex("vnsf.AnnouncementVersion", new[] { "AnnouncementId" });
            DropIndex("vnsf.Announcement", new[] { "User_Id" });
            DropIndex("vnsf.Announcement", new[] { "OpportunityId" });
            DropIndex("vnsf.Opportunity", new[] { "User_Id" });
            DropIndex("vnsf.Opportunity", new[] { "ClassificationId" });
            DropIndex("vnsf.Opportunity", new[] { "GrantId" });
            DropIndex("vnsf.Application", new[] { "Researcher_Id" });
            DropIndex("vnsf.Application", new[] { "UserAccount_Id" });
            DropIndex("vnsf.Application", new[] { "OpportunityId" });
            DropIndex("vnsf.CategoryChild", new[] { "User_Id" });
            DropIndex("vnsf.CategoryChild", new[] { "CategoryId" });
            DropIndex("vnsf.Category", new[] { "Classification_Id" });
            DropTable("vnsf.Storage");
            DropTable("vnsf.LinkedAccountClaim");
            DropTable("vnsf.LinkedAccount");
            DropTable("vnsf.UserClaim");
            DropTable("vnsf.UserCertificate");
            DropTable("vnsf.PanelMemberRole");
            DropTable("vnsf.Job");
            DropTable("vnsf.BankAccount");
            DropTable("vnsf.Person");
            DropTable("vnsf.Panel");
            DropTable("vnsf.LocalizedCulture");
            DropTable("vnsf.Culture");
            DropTable("vnsf.GrantLocalized");
            DropTable("vnsf.Grant");
            DropTable("vnsf.ChangeRequest");
            DropTable("vnsf.Contract");
            DropTable("vnsf.Classification");
            DropTable("vnsf.DocShare");
            DropTable("vnsf.Permission");
            DropTable("vnsf.DocProtection");
            DropTable("vnsf.Doc");
            DropTable("vnsf.Publication");
            DropTable("vnsf.MeasurementUnit");
            DropTable("vnsf.Expense");
            DropTable("vnsf.OrganizationUnit");
            DropTable("vnsf.Contact");
            DropTable("vnsf.Organization");
            DropTable("vnsf.Education");
            DropTable("vnsf.ReportVersion");
            DropTable("vnsf.Report");
            DropTable("vnsf.Award");
            DropTable("vnsf.AnnouncementVersion");
            DropTable("vnsf.Announcement");
            DropTable("vnsf.Opportunity");
            DropTable("vnsf.Application");
            DropTable("vnsf.UserAccount");
            DropTable("vnsf.CategoryChild");
            DropTable("vnsf.Category");
        }
    }
}
