using System.Collections.Generic;
using Vnsf.Data.Entities;
using Vnsf.Data.Entities.Account;

namespace Vnsf.Data.EF.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Vnsf.Data.VnsfDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            //if (System.Diagnostics.Debugger.IsAttached == false)
            //    System.Diagnostics.Debugger.Launch();
        }

        protected override void Seed(Vnsf.Data.VnsfDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            //context.Grants.AddOrUpdate(
            //    g => g.Code,
            //    new Grant { Id = Guid.NewGuid(), Code = "119", Name = "Đề tài 119", Description = "Đề tài theo nghị định 119NDCP", MaxAward = 0, MaxDuration = 24, Objective = "119" }
            //    );

            //var admin =UserAccount.Init("admin", "654321", "admin@hanoitown.com");
            //var hanm = UserAccount.Init("hanm", "123456", "ha@hanoitown.com");
            //context.UserAccounts.AddOrUpdate(p => p.Email, admin);
            //context.UserAccounts.AddOrUpdate(p => p.Email, hanm);

            //context.SaveChanges();
            //context.Classification.AddOrUpdate(c => c.Name, new Classification
            //{
            //    Id = Guid.NewGuid(),
            //    Name = "119",
            //    Categories = new List<Category>
            //                        {
            //                            new Category{Id= Guid.NewGuid(), Name = "Đơn đề nghị"},
            //                            new Category{Id= Guid.NewGuid(),Name = "Thuyết minh đề cương"}
            //                        }
            //});
            //var postal = new Address
            //              {
            //                  Street1 = "39 THD",
            //                  Street2 = "39 THD",
            //                  City = "Hanoi",
            //                  Country = "VN",
            //                  ZipCode = "10000"
            //              };
            //var visiting = new Address
            //{
            //    Street1 = "39 THD",
            //    Street2 = "39 THD",
            //    City = "Hanoi",
            //    Country = "VN",
            //    ZipCode = "10000"
            //};
            //var contact = new Contact
            //{
            //    Email = "nafosted@most.gov.vn",
            //    Id = Guid.NewGuid(),
            //    Name = "Nafosted",
            //    PostalAddress = postal,
            //    Phone = "39446666",
            //    VisitingAddress = visiting,
            //    Website = "www.nafosted.gov.vn"
            //};
            //context.Contacts.AddOrUpdate(c => c.Name, contact);
            //context.SaveChanges();

            //var agency = new FundingAgency
            //{
            //    Id = Guid.NewGuid(),
            //    Name = "QUY PTKHCN QG",
            //    ShortName = "Nafosted",
            //    IsActive = true,
            //};


            //context.Organizations.AddOrUpdate(o => o.ShortName, agency);

            //context.SaveChanges();


        }
    }
}
