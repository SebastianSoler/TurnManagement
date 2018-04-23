using TurnManagement.DataAccess.Interfaces.Persistence.Core;
using TurnManagement.DataAccess.Migrations.Initializers;

namespace TurnManagement.DataAccess.Migrations
{
    public static class DataInitializer
    {
        public static void Initialize(ITurnManagementDataContext context)
        {
            var professionals = new ProfessionalDataInitializer(context);

            professionals.Initialize();
        }
    }
}
