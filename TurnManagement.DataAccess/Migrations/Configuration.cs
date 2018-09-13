using System.Configuration;
using System.Data.Entity.Migrations;
using TurnManagement.DataAccess.Migrations.Initializers;

namespace TurnManagement.DataAccess.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<Persistence.Core.TurnManagementDataContext>
    {
        public Configuration()
        {
            if (bool.Parse(ConfigurationManager.AppSettings["AutomaticMigrationsEnabled"]))
            {
                AutomaticMigrationsEnabled = true;
                AutomaticMigrationDataLossAllowed = true;
            }
        }

        protected override void Seed(Persistence.Core.TurnManagementDataContext context)
        {
            //  This method will be called after migrating to the latest version.
            if (bool.Parse(ConfigurationManager.AppSettings["MigrationSeedsActivated"]))
            {
                (new ApplicationUserDataInitializer(context)).Initialize();
                (new SpecialityDataInitializer(context)).Initialize();
            }
        }
    }
}
