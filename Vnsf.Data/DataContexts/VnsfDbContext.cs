﻿using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Vnsf.Data.Configurations;
using Vnsf.Data.EF;
using Vnsf.Data.EF.Configurations;
using Vnsf.Data.EF.Samples;
using Vnsf.Data.Entities;
using Vnsf.Data.Entities.Account;
using Vnsf.Data.Entities.Globalization;

namespace Vnsf.Data
{
    public class VnsfDbContext : BaseContext<VnsfDbContext>
    {
        //static VnsfDbContext()
        //{
        //    //Database.SetInitializer<VnsfDbContext>(new VnsfDatabaseInitializer());
        //}

        // Standard dbsets
        //public DbSet<Country> Countries { get; set; }
        //public DbSet<CountryLocalized> CountryLocalizeds { get; set; }
        //public DbSet<Language> Languages { get; set; }
        //public DbSet<LanguageLocalized> LanguageLocalizeds { get; set; }
        public DbSet<Culture> Cultures { get; set; }
        public DbSet<UserAccount> UserAccounts { get; set; }
        //public DbSet<CultureLocalized> CultureLocalizeds { get; set; }
        //public DbSet<Region> Regions { get; set; }
        //public DbSet<RegionLocalized> RegionLocalizeds { get; set; }


        //public DbSet<Room> Rooms { get; set; }

        //public DbSet<Application> Applications { get; set; }
        //public DbSet<Operation> Action { get; set; }
        //public DbSet<AppRole> AppRoles { get; set; }
        //public DbSet<AuthorizationPolicy> AuthorizationPolicies { get; set; }
        //public DbSet<ResourceType> ResourceTypes { get; set; }
        //public DbSet<ResourceSubject> ResourceSubjects { get; set; }
        //public DbSet<Target> Targets { get; set; }
        public DbSet<Grant> Grants { get; set; }
        public DbSet<Organization> Organizations { set; get; }
        public DbSet<Category> Categories { set; get; }
        public DbSet<Classification> Classification { set; get; }
        public DbSet<Contact> Contacts { set; get; }
        public DbSet<Storage> Storages { set; get; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Use singular table names
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            //modelBuilder.HasDefaultSchema("vnsf");
            //modelBuilder.Configurations.Add(new CountryConfiguration());
            //modelBuilder.Configurations.Add(new CountryLocalizedConfiguration());
            //modelBuilder.Configurations.Add(new LanguageConfiguration());
            //modelBuilder.Configurations.Add(new LanguageLocalizedConfiguration());
            modelBuilder.Configurations.Add(new CultureConfiguration());
            modelBuilder.Configurations.Add(new PostConfiguration());
            //modelBuilder.Configurations.Add(new RegionConfiguration());
            //modelBuilder.Configurations.Add(new RegionLocalizedConfiguration());

            modelBuilder.Configurations.Add(new AwardConfiguration());
            modelBuilder.Configurations.Add(new ApplicationConfiguration());
            modelBuilder.Configurations.Add(new UserAccountConfiguration());
            modelBuilder.Configurations.Add(new GrantConfiguration());
            modelBuilder.Configurations.Add(new CategoryConfiguration());
            modelBuilder.Configurations.Add(new DocConfiguration());
            modelBuilder.Configurations.Add(new ClassificationConfiguration());
            modelBuilder.Configurations.Add(new UserProfileConfiguration());
        }

    }
}