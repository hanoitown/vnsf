namespace Vnsf.Data.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigrations : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                        ClassificationId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Classification", t => t.ClassificationId, cascadeDelete: true)
                .Index(t => t.ClassificationId);
            
            CreateTable(
                "dbo.Classification",
                c => new
                    {
                        Id = c.Guid(nullable: false),
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
            
            CreateTable(
                "dbo.UserAccount",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Username = c.String(nullable: false, maxLength: 100),
                        Email = c.String(nullable: false, maxLength: 100),
                        Created = c.DateTime(nullable: false),
                        LastUpdated = c.DateTime(nullable: false),
                        PasswordChanged = c.DateTime(nullable: false),
                        RequiresPasswordReset = c.Boolean(nullable: false),
                        MobileCode = c.String(),
                        MobileCodeSent = c.DateTime(),
                        MobilePhoneNumber = c.String(),
                        AccountTwoFactorAuthMode = c.Int(nullable: false),
                        CurrentTwoFactorAuthStatus = c.Int(nullable: false),
                        IsAccountVerified = c.Boolean(nullable: false),
                        IsLoginAllowed = c.Boolean(nullable: false),
                        IsAccountClosed = c.Boolean(nullable: false),
                        AccountClosed = c.DateTime(),
                        LastLogin = c.DateTime(),
                        LastFailedLogin = c.DateTime(),
                        FailedLoginCount = c.Int(nullable: false),
                        VerificationKey = c.String(maxLength: 100),
                        VerificationPurpose = c.Int(),
                        VerificationKeySent = c.DateTime(),
                        HashedPassword = c.String(nullable: false, maxLength: 200),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Application",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Status = c.Int(nullable: false),
                        BudgetTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BudgetApply = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OpportunityId = c.Guid(nullable: false),
                        Created = c.DateTime(),
                        LastUpdated = c.DateTime(),
                        Applicant_ID = c.Guid(),
                        CreatedBy_ID = c.Guid(),
                        LastUpdatedBy_ID = c.Guid(),
                        UserAccount_ID = c.Guid(),
                        Researcher_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserAccount", t => t.Applicant_ID)
                .ForeignKey("dbo.UserAccount", t => t.CreatedBy_ID)
                .ForeignKey("dbo.UserAccount", t => t.LastUpdatedBy_ID)
                .ForeignKey("dbo.Opportunity", t => t.OpportunityId, cascadeDelete: true)
                .ForeignKey("dbo.UserAccount", t => t.UserAccount_ID)
                .ForeignKey("dbo.Person", t => t.Researcher_Id)
                .Index(t => t.Applicant_ID)
                .Index(t => t.CreatedBy_ID)
                .Index(t => t.LastUpdatedBy_ID)
                .Index(t => t.OpportunityId)
                .Index(t => t.UserAccount_ID)
                .Index(t => t.Researcher_Id);
            
            CreateTable(
                "dbo.ApplicationDocument",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                        Created = c.DateTime(),
                        LastUpdated = c.DateTime(),
                        Application_Id = c.Guid(),
                        Category_Id = c.Guid(),
                        CreatedBy_ID = c.Guid(),
                        Document_Id = c.Guid(),
                        LastUpdatedBy_ID = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Application", t => t.Application_Id)
                .ForeignKey("dbo.Category", t => t.Category_Id)
                .ForeignKey("dbo.UserAccount", t => t.CreatedBy_ID)
                .ForeignKey("dbo.Document", t => t.Document_Id)
                .ForeignKey("dbo.UserAccount", t => t.LastUpdatedBy_ID)
                .Index(t => t.Application_Id)
                .Index(t => t.Category_Id)
                .Index(t => t.CreatedBy_ID)
                .Index(t => t.Document_Id)
                .Index(t => t.LastUpdatedBy_ID);
            
            CreateTable(
                "dbo.Document",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        ContractVersion_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ContractVersion", t => t.ContractVersion_Id)
                .Index(t => t.ContractVersion_Id);
            
            CreateTable(
                "dbo.DocumentShare",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ExpireDate = c.DateTime(nullable: false),
                        SecurityCode = c.String(),
                        Name = c.String(),
                        Description = c.String(),
                        Created = c.DateTime(),
                        LastUpdated = c.DateTime(),
                        CreatedBy_ID = c.Guid(),
                        Document_Id = c.Guid(),
                        LastUpdatedBy_ID = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserAccount", t => t.CreatedBy_ID)
                .ForeignKey("dbo.Document", t => t.Document_Id)
                .ForeignKey("dbo.UserAccount", t => t.LastUpdatedBy_ID)
                .Index(t => t.CreatedBy_ID)
                .Index(t => t.Document_Id)
                .Index(t => t.LastUpdatedBy_ID);
            
            CreateTable(
                "dbo.DocumentFile",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FileName = c.String(),
                        Description = c.String(),
                        FileType = c.String(),
                        FilePath = c.String(),
                        Number = c.Int(nullable: false),
                        Name = c.String(),
                        Created = c.DateTime(),
                        LastUpdated = c.DateTime(),
                        CreatedBy_ID = c.Guid(),
                        Document_Id = c.Guid(),
                        LastUpdatedBy_ID = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserAccount", t => t.CreatedBy_ID)
                .ForeignKey("dbo.Document", t => t.Document_Id)
                .ForeignKey("dbo.UserAccount", t => t.LastUpdatedBy_ID)
                .Index(t => t.CreatedBy_ID)
                .Index(t => t.Document_Id)
                .Index(t => t.LastUpdatedBy_ID);
            
            CreateTable(
                "dbo.DocumentStorage",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        BaseLocation = c.String(),
                        IsActive = c.Boolean(nullable: false),
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
            
            CreateTable(
                "dbo.Opportunity",
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
                        CreatedBy_ID = c.Guid(),
                        LastUpdatedBy_ID = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Classification", t => t.ClassificationId, cascadeDelete: true)
                .ForeignKey("dbo.UserAccount", t => t.CreatedBy_ID)
                .ForeignKey("dbo.Grant", t => t.GrantId, cascadeDelete: true)
                .ForeignKey("dbo.UserAccount", t => t.LastUpdatedBy_ID)
                .Index(t => t.ClassificationId)
                .Index(t => t.CreatedBy_ID)
                .Index(t => t.GrantId)
                .Index(t => t.LastUpdatedBy_ID);
            
            CreateTable(
                "dbo.Announcement",
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
                        CreatedBy_ID = c.Guid(),
                        LastUpdatedBy_ID = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserAccount", t => t.CreatedBy_ID)
                .ForeignKey("dbo.UserAccount", t => t.LastUpdatedBy_ID)
                .ForeignKey("dbo.Opportunity", t => t.OpportunityId, cascadeDelete: true)
                .Index(t => t.CreatedBy_ID)
                .Index(t => t.LastUpdatedBy_ID)
                .Index(t => t.OpportunityId);
            
            CreateTable(
                "dbo.AnnouncementVersion",
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
                .ForeignKey("dbo.Announcement", t => t.AnnouncementId, cascadeDelete: true)
                .Index(t => t.AnnouncementId);
            
            CreateTable(
                "dbo.Award",
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
                        CreatedBy_ID = c.Guid(),
                        LastUpdatedBy_ID = c.Guid(),
                        Opportunity_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Application", t => t.Application_Id)
                .ForeignKey("dbo.UserAccount", t => t.CreatedBy_ID)
                .ForeignKey("dbo.UserAccount", t => t.LastUpdatedBy_ID)
                .ForeignKey("dbo.Opportunity", t => t.Opportunity_Id)
                .Index(t => t.Application_Id)
                .Index(t => t.CreatedBy_ID)
                .Index(t => t.LastUpdatedBy_ID)
                .Index(t => t.Opportunity_Id);
            
            CreateTable(
                "dbo.Report",
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
                        CreatedBy_ID = c.Guid(),
                        LastUpdatedBy_ID = c.Guid(),
                        ReportCategory_Id = c.Guid(),
                        Award_Id = c.Guid(),
                        Contract_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Category", t => t.Category_Id)
                .ForeignKey("dbo.UserAccount", t => t.CreatedBy_ID)
                .ForeignKey("dbo.UserAccount", t => t.LastUpdatedBy_ID)
                .ForeignKey("dbo.Category", t => t.ReportCategory_Id)
                .ForeignKey("dbo.Award", t => t.Award_Id)
                .ForeignKey("dbo.Contract", t => t.Contract_Id)
                .Index(t => t.Category_Id)
                .Index(t => t.CreatedBy_ID)
                .Index(t => t.LastUpdatedBy_ID)
                .Index(t => t.ReportCategory_Id)
                .Index(t => t.Award_Id)
                .Index(t => t.Contract_Id);
            
            CreateTable(
                "dbo.ReportVersion",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Target = c.String(),
                        Scope = c.String(),
                        Result = c.String(),
                        Change = c.String(),
                        Number = c.Int(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                        Created = c.DateTime(),
                        LastUpdated = c.DateTime(),
                        CreatedBy_ID = c.Guid(),
                        Document_Id = c.Guid(),
                        LastUpdatedBy_ID = c.Guid(),
                        Report_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserAccount", t => t.CreatedBy_ID)
                .ForeignKey("dbo.Document", t => t.Document_Id)
                .ForeignKey("dbo.UserAccount", t => t.LastUpdatedBy_ID)
                .ForeignKey("dbo.Report", t => t.Report_Id)
                .Index(t => t.CreatedBy_ID)
                .Index(t => t.Document_Id)
                .Index(t => t.LastUpdatedBy_ID)
                .Index(t => t.Report_Id);
            
            CreateTable(
                "dbo.Education",
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
                        CreatedBy_ID = c.Guid(),
                        Field_Id = c.Guid(),
                        LastUpdatedBy_ID = c.Guid(),
                        Organization_Id = c.Guid(),
                        ReportVersion_Id = c.Guid(),
                        Researcher_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserAccount", t => t.CreatedBy_ID)
                .ForeignKey("dbo.Category", t => t.Field_Id)
                .ForeignKey("dbo.UserAccount", t => t.LastUpdatedBy_ID)
                .ForeignKey("dbo.Organization", t => t.Organization_Id)
                .ForeignKey("dbo.ReportVersion", t => t.ReportVersion_Id)
                .ForeignKey("dbo.Person", t => t.Researcher_Id)
                .Index(t => t.CreatedBy_ID)
                .Index(t => t.Field_Id)
                .Index(t => t.LastUpdatedBy_ID)
                .Index(t => t.Organization_Id)
                .Index(t => t.ReportVersion_Id)
                .Index(t => t.Researcher_Id);
            
            CreateTable(
                "dbo.Organization",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        ShortName = c.String(),
                        ContactId = c.Guid(nullable: false),
                        IsStateOwn = c.Boolean(),
                        IsPublic = c.Boolean(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        Logo_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Contact", t => t.ContactId, cascadeDelete: true)
                .ForeignKey("dbo.DocumentFile", t => t.Logo_Id)
                .Index(t => t.ContactId)
                .Index(t => t.Logo_Id);
            
            CreateTable(
                "dbo.Contact",
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
                        Website = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OrganizationUnit",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ParentId = c.Guid(nullable: false),
                        Depth = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Organization", t => t.ParentId, cascadeDelete: true)
                .Index(t => t.ParentId);
            
            CreateTable(
                "dbo.Expense",
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
                        CreatedBy_ID = c.Guid(),
                        LastUpdatedBy_ID = c.Guid(),
                        Unit_Id = c.Guid(),
                        ReportVersion_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Category", t => t.Category_Id)
                .ForeignKey("dbo.UserAccount", t => t.CreatedBy_ID)
                .ForeignKey("dbo.UserAccount", t => t.LastUpdatedBy_ID)
                .ForeignKey("dbo.MeasurementUnit", t => t.Unit_Id)
                .ForeignKey("dbo.ReportVersion", t => t.ReportVersion_Id)
                .Index(t => t.Category_Id)
                .Index(t => t.CreatedBy_ID)
                .Index(t => t.LastUpdatedBy_ID)
                .Index(t => t.Unit_Id)
                .Index(t => t.ReportVersion_Id);
            
            CreateTable(
                "dbo.MeasurementUnit",
                c => new
                    {
                        Id = c.Guid(nullable: false),
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
            
            CreateTable(
                "dbo.Publication",
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
                        CreatedBy_ID = c.Guid(),
                        Document_Id = c.Guid(),
                        LastUpdatedBy_ID = c.Guid(),
                        Organization_Id = c.Guid(),
                        ReportVersion_Id = c.Guid(),
                        Researcher_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Category", t => t.Category_Id)
                .ForeignKey("dbo.UserAccount", t => t.CreatedBy_ID)
                .ForeignKey("dbo.Document", t => t.Document_Id)
                .ForeignKey("dbo.UserAccount", t => t.LastUpdatedBy_ID)
                .ForeignKey("dbo.Organization", t => t.Organization_Id)
                .ForeignKey("dbo.ReportVersion", t => t.ReportVersion_Id)
                .ForeignKey("dbo.Person", t => t.Researcher_Id)
                .Index(t => t.Category_Id)
                .Index(t => t.CreatedBy_ID)
                .Index(t => t.Document_Id)
                .Index(t => t.LastUpdatedBy_ID)
                .Index(t => t.Organization_Id)
                .Index(t => t.ReportVersion_Id)
                .Index(t => t.Researcher_Id);
            
            CreateTable(
                "dbo.Contract",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                        Created = c.DateTime(),
                        LastUpdated = c.DateTime(),
                        Application_Id = c.Guid(),
                        CreatedBy_ID = c.Guid(),
                        LastUpdatedBy_ID = c.Guid(),
                        Opportunity_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Application", t => t.Application_Id)
                .ForeignKey("dbo.UserAccount", t => t.CreatedBy_ID)
                .ForeignKey("dbo.UserAccount", t => t.LastUpdatedBy_ID)
                .ForeignKey("dbo.Opportunity", t => t.Opportunity_Id)
                .Index(t => t.Application_Id)
                .Index(t => t.CreatedBy_ID)
                .Index(t => t.LastUpdatedBy_ID)
                .Index(t => t.Opportunity_Id);
            
            CreateTable(
                "dbo.ChangeRequest",
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
                        CreatedBy_ID = c.Guid(),
                        LastUpdatedBy_ID = c.Guid(),
                        Contract_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Category", t => t.Category_Id)
                .ForeignKey("dbo.UserAccount", t => t.CreatedBy_ID)
                .ForeignKey("dbo.UserAccount", t => t.LastUpdatedBy_ID)
                .ForeignKey("dbo.Contract", t => t.Contract_Id)
                .Index(t => t.Category_Id)
                .Index(t => t.CreatedBy_ID)
                .Index(t => t.LastUpdatedBy_ID)
                .Index(t => t.Contract_Id);
            
            CreateTable(
                "dbo.ContractVersion",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Number = c.Int(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                        Created = c.DateTime(),
                        LastUpdated = c.DateTime(),
                        Contract_Id = c.Guid(),
                        CreatedBy_ID = c.Guid(),
                        LastUpdatedBy_ID = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Contract", t => t.Contract_Id)
                .ForeignKey("dbo.UserAccount", t => t.CreatedBy_ID)
                .ForeignKey("dbo.UserAccount", t => t.LastUpdatedBy_ID)
                .Index(t => t.Contract_Id)
                .Index(t => t.CreatedBy_ID)
                .Index(t => t.LastUpdatedBy_ID);
            
            CreateTable(
                "dbo.Grant",
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
                        CreatedBy_ID = c.Guid(),
                        LastUpdatedBy_ID = c.Guid(),
                        Logo_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Organization", t => t.AgencyId)
                .ForeignKey("dbo.Classification", t => t.ClassificationSystem_Id)
                .ForeignKey("dbo.UserAccount", t => t.CreatedBy_ID)
                .ForeignKey("dbo.UserAccount", t => t.LastUpdatedBy_ID)
                .ForeignKey("dbo.Document", t => t.Logo_Id)
                .Index(t => t.AgencyId)
                .Index(t => t.ClassificationSystem_Id)
                .Index(t => t.CreatedBy_ID)
                .Index(t => t.LastUpdatedBy_ID)
                .Index(t => t.Logo_Id);
            
            CreateTable(
                "dbo.GrantLocalized",
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
                .ForeignKey("dbo.Culture", t => t.CultureId, cascadeDelete: true)
                .ForeignKey("dbo.Grant", t => t.Grant_Id)
                .Index(t => t.CultureId)
                .Index(t => t.Grant_Id);
            
            CreateTable(
                "dbo.Culture",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Code = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CultureLocalized",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        CultureId = c.Guid(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Culture", t => t.CultureId, cascadeDelete: true)
                .Index(t => t.CultureId);
            
            CreateTable(
                "dbo.Panel",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FromDate = c.DateTime(nullable: false),
                        ToDate = c.DateTime(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                        Created = c.DateTime(),
                        LastUpdated = c.DateTime(),
                        CreatedBy_ID = c.Guid(),
                        LastUpdatedBy_ID = c.Guid(),
                        Opportunity_Id = c.Guid(),
                        Grant_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserAccount", t => t.CreatedBy_ID)
                .ForeignKey("dbo.UserAccount", t => t.LastUpdatedBy_ID)
                .ForeignKey("dbo.Opportunity", t => t.Opportunity_Id)
                .ForeignKey("dbo.Grant", t => t.Grant_Id)
                .Index(t => t.CreatedBy_ID)
                .Index(t => t.LastUpdatedBy_ID)
                .Index(t => t.Opportunity_Id)
                .Index(t => t.Grant_Id);
            
            CreateTable(
                "dbo.Person",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FullName_FirsName = c.String(),
                        FullName_LastName = c.String(),
                        BirthDay = c.DateTime(),
                        Gender = c.Boolean(nullable: false),
                        ContactId = c.Guid(nullable: false),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        PanelMemberRole_Id = c.Guid(),
                        Panel_Id = c.Guid(),
                        Account_ID = c.Guid(),
                        BankAccount_Id = c.Guid(),
                        LoginAccount_ID = c.Guid(),
                        Organization_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PanelMemberRole", t => t.PanelMemberRole_Id)
                .ForeignKey("dbo.Panel", t => t.Panel_Id)
                .ForeignKey("dbo.UserAccount", t => t.Account_ID)
                .ForeignKey("dbo.BankAccount", t => t.BankAccount_Id)
                .ForeignKey("dbo.Contact", t => t.ContactId, cascadeDelete: true)
                .ForeignKey("dbo.UserAccount", t => t.LoginAccount_ID)
                .ForeignKey("dbo.Organization", t => t.Organization_Id)
                .Index(t => t.PanelMemberRole_Id)
                .Index(t => t.Panel_Id)
                .Index(t => t.Account_ID)
                .Index(t => t.BankAccount_Id)
                .Index(t => t.ContactId)
                .Index(t => t.LoginAccount_ID)
                .Index(t => t.Organization_Id);
            
            CreateTable(
                "dbo.BankAccount",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        AccountNo = c.String(),
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
            
            CreateTable(
                "dbo.Job",
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
                        CreatedBy_ID = c.Guid(),
                        LastUpdatedBy_ID = c.Guid(),
                        Organization_Id = c.Guid(),
                        Researcher_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserAccount", t => t.CreatedBy_ID)
                .ForeignKey("dbo.UserAccount", t => t.LastUpdatedBy_ID)
                .ForeignKey("dbo.Organization", t => t.Organization_Id)
                .ForeignKey("dbo.Person", t => t.Researcher_Id)
                .Index(t => t.CreatedBy_ID)
                .Index(t => t.LastUpdatedBy_ID)
                .Index(t => t.Organization_Id)
                .Index(t => t.Researcher_Id);
            
            CreateTable(
                "dbo.PanelMemberRole",
                c => new
                    {
                        Id = c.Guid(nullable: false),
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
            
            CreateTable(
                "dbo.UserCertificate",
                c => new
                    {
                        UserAccountID = c.Guid(nullable: false),
                        Thumbprint = c.String(nullable: false, maxLength: 150),
                        Subject = c.String(maxLength: 250),
                    })
                .PrimaryKey(t => new { t.UserAccountID, t.Thumbprint })
                .ForeignKey("dbo.UserAccount", t => t.UserAccountID, cascadeDelete: true)
                .Index(t => t.UserAccountID);
            
            CreateTable(
                "dbo.UserClaim",
                c => new
                    {
                        UserAccountID = c.Guid(nullable: false),
                        Type = c.String(nullable: false, maxLength: 150),
                        Value = c.String(nullable: false, maxLength: 150),
                    })
                .PrimaryKey(t => new { t.UserAccountID, t.Type, t.Value })
                .ForeignKey("dbo.UserAccount", t => t.UserAccountID, cascadeDelete: true)
                .Index(t => t.UserAccountID);
            
            CreateTable(
                "dbo.LinkedAccount",
                c => new
                    {
                        UserAccountID = c.Guid(nullable: false),
                        ProviderName = c.String(nullable: false, maxLength: 50),
                        ProviderAccountID = c.String(nullable: false, maxLength: 100),
                        LastLogin = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserAccountID, t.ProviderName, t.ProviderAccountID })
                .ForeignKey("dbo.UserAccount", t => t.UserAccountID, cascadeDelete: true)
                .Index(t => t.UserAccountID);
            
            CreateTable(
                "dbo.LinkedAccountClaim",
                c => new
                    {
                        UserAccountID = c.Guid(nullable: false),
                        ProviderName = c.String(nullable: false, maxLength: 50),
                        ProviderAccountID = c.String(nullable: false, maxLength: 100),
                        Type = c.String(nullable: false, maxLength: 150),
                        Value = c.String(maxLength: 150),
                    })
                .PrimaryKey(t => new { t.UserAccountID, t.ProviderName, t.ProviderAccountID, t.Type })
                .ForeignKey("dbo.LinkedAccount", t => new { t.UserAccountID, t.ProviderName, t.ProviderAccountID }, cascadeDelete: true)
                .Index(t => new { t.UserAccountID, t.ProviderName, t.ProviderAccountID });
            
            CreateTable(
                "dbo.CategoryChild",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Order = c.Int(nullable: false),
                        CategoryId = c.Guid(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                        Created = c.DateTime(),
                        LastUpdated = c.DateTime(),
                        CreatedBy_ID = c.Guid(),
                        LastUpdatedBy_ID = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Category", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.UserAccount", t => t.CreatedBy_ID)
                .ForeignKey("dbo.UserAccount", t => t.LastUpdatedBy_ID)
                .Index(t => t.CategoryId)
                .Index(t => t.CreatedBy_ID)
                .Index(t => t.LastUpdatedBy_ID);
            
            CreateTable(
                "dbo.DocumentStorageDocumentFile",
                c => new
                    {
                        DocumentStorage_Id = c.Guid(nullable: false),
                        DocumentFile_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.DocumentStorage_Id, t.DocumentFile_Id })
                .ForeignKey("dbo.DocumentStorage", t => t.DocumentStorage_Id, cascadeDelete: true)
                .ForeignKey("dbo.DocumentFile", t => t.DocumentFile_Id, cascadeDelete: true)
                .Index(t => t.DocumentStorage_Id)
                .Index(t => t.DocumentFile_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Publication", "Researcher_Id", "dbo.Person");
            DropForeignKey("dbo.Person", "Organization_Id", "dbo.Organization");
            DropForeignKey("dbo.Job", "Researcher_Id", "dbo.Person");
            DropForeignKey("dbo.Education", "Researcher_Id", "dbo.Person");
            DropForeignKey("dbo.Application", "Researcher_Id", "dbo.Person");
            DropForeignKey("dbo.Person", "LoginAccount_ID", "dbo.UserAccount");
            DropForeignKey("dbo.Person", "ContactId", "dbo.Contact");
            DropForeignKey("dbo.Person", "BankAccount_Id", "dbo.BankAccount");
            DropForeignKey("dbo.Person", "Account_ID", "dbo.UserAccount");
            DropForeignKey("dbo.CategoryChild", "LastUpdatedBy_ID", "dbo.UserAccount");
            DropForeignKey("dbo.CategoryChild", "CreatedBy_ID", "dbo.UserAccount");
            DropForeignKey("dbo.CategoryChild", "CategoryId", "dbo.Category");
            DropForeignKey("dbo.Classification", "LastUpdatedBy_ID", "dbo.UserAccount");
            DropForeignKey("dbo.Classification", "CreatedBy_ID", "dbo.UserAccount");
            DropForeignKey("dbo.LinkedAccount", "UserAccountID", "dbo.UserAccount");
            DropForeignKey("dbo.LinkedAccountClaim", new[] { "UserAccountID", "ProviderName", "ProviderAccountID" }, "dbo.LinkedAccount");
            DropForeignKey("dbo.UserClaim", "UserAccountID", "dbo.UserAccount");
            DropForeignKey("dbo.UserCertificate", "UserAccountID", "dbo.UserAccount");
            DropForeignKey("dbo.Application", "UserAccount_ID", "dbo.UserAccount");
            DropForeignKey("dbo.Opportunity", "LastUpdatedBy_ID", "dbo.UserAccount");
            DropForeignKey("dbo.Panel", "Grant_Id", "dbo.Grant");
            DropForeignKey("dbo.Panel", "Opportunity_Id", "dbo.Opportunity");
            DropForeignKey("dbo.Person", "Panel_Id", "dbo.Panel");
            DropForeignKey("dbo.Person", "PanelMemberRole_Id", "dbo.PanelMemberRole");
            DropForeignKey("dbo.PanelMemberRole", "LastUpdatedBy_ID", "dbo.UserAccount");
            DropForeignKey("dbo.PanelMemberRole", "CreatedBy_ID", "dbo.UserAccount");
            DropForeignKey("dbo.Job", "Organization_Id", "dbo.Organization");
            DropForeignKey("dbo.Job", "LastUpdatedBy_ID", "dbo.UserAccount");
            DropForeignKey("dbo.Job", "CreatedBy_ID", "dbo.UserAccount");
            DropForeignKey("dbo.BankAccount", "LastUpdatedBy_ID", "dbo.UserAccount");
            DropForeignKey("dbo.BankAccount", "CreatedBy_ID", "dbo.UserAccount");
            DropForeignKey("dbo.Panel", "LastUpdatedBy_ID", "dbo.UserAccount");
            DropForeignKey("dbo.Panel", "CreatedBy_ID", "dbo.UserAccount");
            DropForeignKey("dbo.Opportunity", "GrantId", "dbo.Grant");
            DropForeignKey("dbo.Grant", "Logo_Id", "dbo.Document");
            DropForeignKey("dbo.Grant", "LastUpdatedBy_ID", "dbo.UserAccount");
            DropForeignKey("dbo.GrantLocalized", "Grant_Id", "dbo.Grant");
            DropForeignKey("dbo.GrantLocalized", "CultureId", "dbo.Culture");
            DropForeignKey("dbo.CultureLocalized", "CultureId", "dbo.Culture");
            DropForeignKey("dbo.Grant", "CreatedBy_ID", "dbo.UserAccount");
            DropForeignKey("dbo.Grant", "ClassificationSystem_Id", "dbo.Classification");
            DropForeignKey("dbo.Grant", "AgencyId", "dbo.Organization");
            DropForeignKey("dbo.Opportunity", "CreatedBy_ID", "dbo.UserAccount");
            DropForeignKey("dbo.Contract", "Opportunity_Id", "dbo.Opportunity");
            DropForeignKey("dbo.ContractVersion", "LastUpdatedBy_ID", "dbo.UserAccount");
            DropForeignKey("dbo.Document", "ContractVersion_Id", "dbo.ContractVersion");
            DropForeignKey("dbo.ContractVersion", "CreatedBy_ID", "dbo.UserAccount");
            DropForeignKey("dbo.ContractVersion", "Contract_Id", "dbo.Contract");
            DropForeignKey("dbo.Report", "Contract_Id", "dbo.Contract");
            DropForeignKey("dbo.Contract", "LastUpdatedBy_ID", "dbo.UserAccount");
            DropForeignKey("dbo.ChangeRequest", "Contract_Id", "dbo.Contract");
            DropForeignKey("dbo.ChangeRequest", "LastUpdatedBy_ID", "dbo.UserAccount");
            DropForeignKey("dbo.ChangeRequest", "CreatedBy_ID", "dbo.UserAccount");
            DropForeignKey("dbo.ChangeRequest", "Category_Id", "dbo.Category");
            DropForeignKey("dbo.Contract", "CreatedBy_ID", "dbo.UserAccount");
            DropForeignKey("dbo.Contract", "Application_Id", "dbo.Application");
            DropForeignKey("dbo.Opportunity", "ClassificationId", "dbo.Classification");
            DropForeignKey("dbo.Award", "Opportunity_Id", "dbo.Opportunity");
            DropForeignKey("dbo.Report", "Award_Id", "dbo.Award");
            DropForeignKey("dbo.ReportVersion", "Report_Id", "dbo.Report");
            DropForeignKey("dbo.Publication", "ReportVersion_Id", "dbo.ReportVersion");
            DropForeignKey("dbo.Publication", "Organization_Id", "dbo.Organization");
            DropForeignKey("dbo.Publication", "LastUpdatedBy_ID", "dbo.UserAccount");
            DropForeignKey("dbo.Publication", "Document_Id", "dbo.Document");
            DropForeignKey("dbo.Publication", "CreatedBy_ID", "dbo.UserAccount");
            DropForeignKey("dbo.Publication", "Category_Id", "dbo.Category");
            DropForeignKey("dbo.ReportVersion", "LastUpdatedBy_ID", "dbo.UserAccount");
            DropForeignKey("dbo.Expense", "ReportVersion_Id", "dbo.ReportVersion");
            DropForeignKey("dbo.MeasurementUnit", "LastUpdatedBy_ID", "dbo.UserAccount");
            DropForeignKey("dbo.Expense", "Unit_Id", "dbo.MeasurementUnit");
            DropForeignKey("dbo.MeasurementUnit", "CreatedBy_ID", "dbo.UserAccount");
            DropForeignKey("dbo.Expense", "LastUpdatedBy_ID", "dbo.UserAccount");
            DropForeignKey("dbo.Expense", "CreatedBy_ID", "dbo.UserAccount");
            DropForeignKey("dbo.Expense", "Category_Id", "dbo.Category");
            DropForeignKey("dbo.Education", "ReportVersion_Id", "dbo.ReportVersion");
            DropForeignKey("dbo.Education", "Organization_Id", "dbo.Organization");
            DropForeignKey("dbo.OrganizationUnit", "ParentId", "dbo.Organization");
            DropForeignKey("dbo.Organization", "Logo_Id", "dbo.DocumentFile");
            DropForeignKey("dbo.Organization", "ContactId", "dbo.Contact");
            DropForeignKey("dbo.Education", "LastUpdatedBy_ID", "dbo.UserAccount");
            DropForeignKey("dbo.Education", "Field_Id", "dbo.Category");
            DropForeignKey("dbo.Education", "CreatedBy_ID", "dbo.UserAccount");
            DropForeignKey("dbo.ReportVersion", "Document_Id", "dbo.Document");
            DropForeignKey("dbo.ReportVersion", "CreatedBy_ID", "dbo.UserAccount");
            DropForeignKey("dbo.Report", "ReportCategory_Id", "dbo.Category");
            DropForeignKey("dbo.Report", "LastUpdatedBy_ID", "dbo.UserAccount");
            DropForeignKey("dbo.Report", "CreatedBy_ID", "dbo.UserAccount");
            DropForeignKey("dbo.Report", "Category_Id", "dbo.Category");
            DropForeignKey("dbo.Award", "LastUpdatedBy_ID", "dbo.UserAccount");
            DropForeignKey("dbo.Award", "CreatedBy_ID", "dbo.UserAccount");
            DropForeignKey("dbo.Award", "Application_Id", "dbo.Application");
            DropForeignKey("dbo.Application", "OpportunityId", "dbo.Opportunity");
            DropForeignKey("dbo.AnnouncementVersion", "AnnouncementId", "dbo.Announcement");
            DropForeignKey("dbo.Announcement", "OpportunityId", "dbo.Opportunity");
            DropForeignKey("dbo.Announcement", "LastUpdatedBy_ID", "dbo.UserAccount");
            DropForeignKey("dbo.Announcement", "CreatedBy_ID", "dbo.UserAccount");
            DropForeignKey("dbo.Application", "LastUpdatedBy_ID", "dbo.UserAccount");
            DropForeignKey("dbo.ApplicationDocument", "LastUpdatedBy_ID", "dbo.UserAccount");
            DropForeignKey("dbo.ApplicationDocument", "Document_Id", "dbo.Document");
            DropForeignKey("dbo.DocumentStorage", "LastUpdatedBy_ID", "dbo.UserAccount");
            DropForeignKey("dbo.DocumentStorageDocumentFile", "DocumentFile_Id", "dbo.DocumentFile");
            DropForeignKey("dbo.DocumentStorageDocumentFile", "DocumentStorage_Id", "dbo.DocumentStorage");
            DropForeignKey("dbo.DocumentStorage", "CreatedBy_ID", "dbo.UserAccount");
            DropForeignKey("dbo.DocumentFile", "LastUpdatedBy_ID", "dbo.UserAccount");
            DropForeignKey("dbo.DocumentFile", "Document_Id", "dbo.Document");
            DropForeignKey("dbo.DocumentFile", "CreatedBy_ID", "dbo.UserAccount");
            DropForeignKey("dbo.DocumentShare", "LastUpdatedBy_ID", "dbo.UserAccount");
            DropForeignKey("dbo.DocumentShare", "Document_Id", "dbo.Document");
            DropForeignKey("dbo.DocumentShare", "CreatedBy_ID", "dbo.UserAccount");
            DropForeignKey("dbo.ApplicationDocument", "CreatedBy_ID", "dbo.UserAccount");
            DropForeignKey("dbo.ApplicationDocument", "Category_Id", "dbo.Category");
            DropForeignKey("dbo.ApplicationDocument", "Application_Id", "dbo.Application");
            DropForeignKey("dbo.Application", "CreatedBy_ID", "dbo.UserAccount");
            DropForeignKey("dbo.Application", "Applicant_ID", "dbo.UserAccount");
            DropForeignKey("dbo.Category", "ClassificationId", "dbo.Classification");
            DropIndex("dbo.Publication", new[] { "Researcher_Id" });
            DropIndex("dbo.Person", new[] { "Organization_Id" });
            DropIndex("dbo.Job", new[] { "Researcher_Id" });
            DropIndex("dbo.Education", new[] { "Researcher_Id" });
            DropIndex("dbo.Application", new[] { "Researcher_Id" });
            DropIndex("dbo.Person", new[] { "LoginAccount_ID" });
            DropIndex("dbo.Person", new[] { "ContactId" });
            DropIndex("dbo.Person", new[] { "BankAccount_Id" });
            DropIndex("dbo.Person", new[] { "Account_ID" });
            DropIndex("dbo.CategoryChild", new[] { "LastUpdatedBy_ID" });
            DropIndex("dbo.CategoryChild", new[] { "CreatedBy_ID" });
            DropIndex("dbo.CategoryChild", new[] { "CategoryId" });
            DropIndex("dbo.Classification", new[] { "LastUpdatedBy_ID" });
            DropIndex("dbo.Classification", new[] { "CreatedBy_ID" });
            DropIndex("dbo.LinkedAccount", new[] { "UserAccountID" });
            DropIndex("dbo.LinkedAccountClaim", new[] { "UserAccountID", "ProviderName", "ProviderAccountID" });
            DropIndex("dbo.UserClaim", new[] { "UserAccountID" });
            DropIndex("dbo.UserCertificate", new[] { "UserAccountID" });
            DropIndex("dbo.Application", new[] { "UserAccount_ID" });
            DropIndex("dbo.Opportunity", new[] { "LastUpdatedBy_ID" });
            DropIndex("dbo.Panel", new[] { "Grant_Id" });
            DropIndex("dbo.Panel", new[] { "Opportunity_Id" });
            DropIndex("dbo.Person", new[] { "Panel_Id" });
            DropIndex("dbo.Person", new[] { "PanelMemberRole_Id" });
            DropIndex("dbo.PanelMemberRole", new[] { "LastUpdatedBy_ID" });
            DropIndex("dbo.PanelMemberRole", new[] { "CreatedBy_ID" });
            DropIndex("dbo.Job", new[] { "Organization_Id" });
            DropIndex("dbo.Job", new[] { "LastUpdatedBy_ID" });
            DropIndex("dbo.Job", new[] { "CreatedBy_ID" });
            DropIndex("dbo.BankAccount", new[] { "LastUpdatedBy_ID" });
            DropIndex("dbo.BankAccount", new[] { "CreatedBy_ID" });
            DropIndex("dbo.Panel", new[] { "LastUpdatedBy_ID" });
            DropIndex("dbo.Panel", new[] { "CreatedBy_ID" });
            DropIndex("dbo.Opportunity", new[] { "GrantId" });
            DropIndex("dbo.Grant", new[] { "Logo_Id" });
            DropIndex("dbo.Grant", new[] { "LastUpdatedBy_ID" });
            DropIndex("dbo.GrantLocalized", new[] { "Grant_Id" });
            DropIndex("dbo.GrantLocalized", new[] { "CultureId" });
            DropIndex("dbo.CultureLocalized", new[] { "CultureId" });
            DropIndex("dbo.Grant", new[] { "CreatedBy_ID" });
            DropIndex("dbo.Grant", new[] { "ClassificationSystem_Id" });
            DropIndex("dbo.Grant", new[] { "AgencyId" });
            DropIndex("dbo.Opportunity", new[] { "CreatedBy_ID" });
            DropIndex("dbo.Contract", new[] { "Opportunity_Id" });
            DropIndex("dbo.ContractVersion", new[] { "LastUpdatedBy_ID" });
            DropIndex("dbo.Document", new[] { "ContractVersion_Id" });
            DropIndex("dbo.ContractVersion", new[] { "CreatedBy_ID" });
            DropIndex("dbo.ContractVersion", new[] { "Contract_Id" });
            DropIndex("dbo.Report", new[] { "Contract_Id" });
            DropIndex("dbo.Contract", new[] { "LastUpdatedBy_ID" });
            DropIndex("dbo.ChangeRequest", new[] { "Contract_Id" });
            DropIndex("dbo.ChangeRequest", new[] { "LastUpdatedBy_ID" });
            DropIndex("dbo.ChangeRequest", new[] { "CreatedBy_ID" });
            DropIndex("dbo.ChangeRequest", new[] { "Category_Id" });
            DropIndex("dbo.Contract", new[] { "CreatedBy_ID" });
            DropIndex("dbo.Contract", new[] { "Application_Id" });
            DropIndex("dbo.Opportunity", new[] { "ClassificationId" });
            DropIndex("dbo.Award", new[] { "Opportunity_Id" });
            DropIndex("dbo.Report", new[] { "Award_Id" });
            DropIndex("dbo.ReportVersion", new[] { "Report_Id" });
            DropIndex("dbo.Publication", new[] { "ReportVersion_Id" });
            DropIndex("dbo.Publication", new[] { "Organization_Id" });
            DropIndex("dbo.Publication", new[] { "LastUpdatedBy_ID" });
            DropIndex("dbo.Publication", new[] { "Document_Id" });
            DropIndex("dbo.Publication", new[] { "CreatedBy_ID" });
            DropIndex("dbo.Publication", new[] { "Category_Id" });
            DropIndex("dbo.ReportVersion", new[] { "LastUpdatedBy_ID" });
            DropIndex("dbo.Expense", new[] { "ReportVersion_Id" });
            DropIndex("dbo.MeasurementUnit", new[] { "LastUpdatedBy_ID" });
            DropIndex("dbo.Expense", new[] { "Unit_Id" });
            DropIndex("dbo.MeasurementUnit", new[] { "CreatedBy_ID" });
            DropIndex("dbo.Expense", new[] { "LastUpdatedBy_ID" });
            DropIndex("dbo.Expense", new[] { "CreatedBy_ID" });
            DropIndex("dbo.Expense", new[] { "Category_Id" });
            DropIndex("dbo.Education", new[] { "ReportVersion_Id" });
            DropIndex("dbo.Education", new[] { "Organization_Id" });
            DropIndex("dbo.OrganizationUnit", new[] { "ParentId" });
            DropIndex("dbo.Organization", new[] { "Logo_Id" });
            DropIndex("dbo.Organization", new[] { "ContactId" });
            DropIndex("dbo.Education", new[] { "LastUpdatedBy_ID" });
            DropIndex("dbo.Education", new[] { "Field_Id" });
            DropIndex("dbo.Education", new[] { "CreatedBy_ID" });
            DropIndex("dbo.ReportVersion", new[] { "Document_Id" });
            DropIndex("dbo.ReportVersion", new[] { "CreatedBy_ID" });
            DropIndex("dbo.Report", new[] { "ReportCategory_Id" });
            DropIndex("dbo.Report", new[] { "LastUpdatedBy_ID" });
            DropIndex("dbo.Report", new[] { "CreatedBy_ID" });
            DropIndex("dbo.Report", new[] { "Category_Id" });
            DropIndex("dbo.Award", new[] { "LastUpdatedBy_ID" });
            DropIndex("dbo.Award", new[] { "CreatedBy_ID" });
            DropIndex("dbo.Award", new[] { "Application_Id" });
            DropIndex("dbo.Application", new[] { "OpportunityId" });
            DropIndex("dbo.AnnouncementVersion", new[] { "AnnouncementId" });
            DropIndex("dbo.Announcement", new[] { "OpportunityId" });
            DropIndex("dbo.Announcement", new[] { "LastUpdatedBy_ID" });
            DropIndex("dbo.Announcement", new[] { "CreatedBy_ID" });
            DropIndex("dbo.Application", new[] { "LastUpdatedBy_ID" });
            DropIndex("dbo.ApplicationDocument", new[] { "LastUpdatedBy_ID" });
            DropIndex("dbo.ApplicationDocument", new[] { "Document_Id" });
            DropIndex("dbo.DocumentStorage", new[] { "LastUpdatedBy_ID" });
            DropIndex("dbo.DocumentStorageDocumentFile", new[] { "DocumentFile_Id" });
            DropIndex("dbo.DocumentStorageDocumentFile", new[] { "DocumentStorage_Id" });
            DropIndex("dbo.DocumentStorage", new[] { "CreatedBy_ID" });
            DropIndex("dbo.DocumentFile", new[] { "LastUpdatedBy_ID" });
            DropIndex("dbo.DocumentFile", new[] { "Document_Id" });
            DropIndex("dbo.DocumentFile", new[] { "CreatedBy_ID" });
            DropIndex("dbo.DocumentShare", new[] { "LastUpdatedBy_ID" });
            DropIndex("dbo.DocumentShare", new[] { "Document_Id" });
            DropIndex("dbo.DocumentShare", new[] { "CreatedBy_ID" });
            DropIndex("dbo.ApplicationDocument", new[] { "CreatedBy_ID" });
            DropIndex("dbo.ApplicationDocument", new[] { "Category_Id" });
            DropIndex("dbo.ApplicationDocument", new[] { "Application_Id" });
            DropIndex("dbo.Application", new[] { "CreatedBy_ID" });
            DropIndex("dbo.Application", new[] { "Applicant_ID" });
            DropIndex("dbo.Category", new[] { "ClassificationId" });
            DropTable("dbo.DocumentStorageDocumentFile");
            DropTable("dbo.CategoryChild");
            DropTable("dbo.LinkedAccountClaim");
            DropTable("dbo.LinkedAccount");
            DropTable("dbo.UserClaim");
            DropTable("dbo.UserCertificate");
            DropTable("dbo.PanelMemberRole");
            DropTable("dbo.Job");
            DropTable("dbo.BankAccount");
            DropTable("dbo.Person");
            DropTable("dbo.Panel");
            DropTable("dbo.CultureLocalized");
            DropTable("dbo.Culture");
            DropTable("dbo.GrantLocalized");
            DropTable("dbo.Grant");
            DropTable("dbo.ContractVersion");
            DropTable("dbo.ChangeRequest");
            DropTable("dbo.Contract");
            DropTable("dbo.Publication");
            DropTable("dbo.MeasurementUnit");
            DropTable("dbo.Expense");
            DropTable("dbo.OrganizationUnit");
            DropTable("dbo.Contact");
            DropTable("dbo.Organization");
            DropTable("dbo.Education");
            DropTable("dbo.ReportVersion");
            DropTable("dbo.Report");
            DropTable("dbo.Award");
            DropTable("dbo.AnnouncementVersion");
            DropTable("dbo.Announcement");
            DropTable("dbo.Opportunity");
            DropTable("dbo.DocumentStorage");
            DropTable("dbo.DocumentFile");
            DropTable("dbo.DocumentShare");
            DropTable("dbo.Document");
            DropTable("dbo.ApplicationDocument");
            DropTable("dbo.Application");
            DropTable("dbo.UserAccount");
            DropTable("dbo.Classification");
            DropTable("dbo.Category");
        }
    }
}
