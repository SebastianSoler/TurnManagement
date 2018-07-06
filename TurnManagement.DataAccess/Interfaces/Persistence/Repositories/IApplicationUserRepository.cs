using System.Collections.Generic;
using System.Linq;
using TurnManagement.DataAccess.Interfaces.Persistence.Core;
using TurnManagement.Domain.Entities;

namespace TurnManagement.DataAccess.Interfaces.Persistence.Repositories
{
    public interface IApplicationUserRepository //: IBaseCrudRepository<ApplicationUser>
    {
        ApplicationUser Get(int id, bool asNoTracking = true);

        IQueryable<ApplicationUser> GetAll(bool asNoTracking = true);

        IQueryable<ApplicationUser> GetByIds(IEnumerable<int> ids, bool asNoTracking = true);

        int Add(ApplicationUser entity, bool withoutSaveChanges = false);

        void Update(ApplicationUser entity, bool withoutSaveChanges = false);

        void Delete(int id, bool withoutSaveChanges = false);

        int SaveChanges();
    }
}
