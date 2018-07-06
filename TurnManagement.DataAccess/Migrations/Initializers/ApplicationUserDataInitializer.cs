using System.Collections.Generic;
using System.Linq;
using TurnManagement.DataAccess.Interfaces.Persistence.Core;
using TurnManagement.Domain.Entities;

namespace TurnManagement.DataAccess.Migrations.Initializers
{
    public class ApplicationUserDataInitializer : InitializerBase<ApplicationUser>
    {
        public ApplicationUserDataInitializer(ITurnManagementDataContext context) : base(context)
        {
        }

        public override IQueryable<ApplicationUser> DataSource()
        {
            return new List<ApplicationUser>
            {
                new ApplicationUser{ Id = 1, UserName = "Admin", Password = "Turnero!1" }
            }.AsQueryable();
        }
    }
}
