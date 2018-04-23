using System.Configuration;
using System.Data.Entity.Migrations;
using TurnManagement.DataAccess.Persistence.Core;

namespace TurnManagement.DataAccess.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<TurnManagementDataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = bool.Parse(ConfigurationManager.AppSettings["AutomaticMigrationsEnabled"]);
            AutomaticMigrationDataLossAllowed = bool.Parse(ConfigurationManager.AppSettings["AutomaticMigrationDataLossAllowed"]);
        }

        protected override void Seed(TurnManagementDataContext context)
        {
            if (bool.Parse(ConfigurationManager.AppSettings["MigrationSeedsActivated"]))
            {
                DataInitializer.Initialize(context);
            }
        }
    }
}
