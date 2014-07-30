using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vnsf.Data.EF.Migrations;

namespace Vnsf.Data.EF.DataContexts
{
    public class VnsfDbInit
    {
        public static void InitDb()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<VnsfDbContext, Configuration>());
            var dbMigrator = new DbMigrator(new Configuration());
            dbMigrator.Update();
        }
    }

}
