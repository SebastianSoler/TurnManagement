using System.Collections.Generic;
using System.Linq;
using TurnManagement.DataAccess.Interfaces.Persistence.Core;
using TurnManagement.Domain.Entities;

namespace TurnManagement.DataAccess.Migrations.Initializers
{
    public class ApplicationUserDataInitializer : BaseInitializer<ApplicationUser>
    {
        public ApplicationUserDataInitializer(ITurnManagementDataContext dataContext) : base(dataContext) { }

        public override IQueryable<ApplicationUser> DataSource()
        {
            var list = new List<ApplicationUser>()
            {
                new ApplicationUser(){ Id = 1, UserName = "SuperAdmin", Password = "SuperAdmin!1" , IsDeleted = false },
                new ApplicationUser(){ Id = 2, UserName = "Administrador", Password = "admin1234" , IsDeleted = false }
            };

            return list.AsQueryable();
        }
    }
}
