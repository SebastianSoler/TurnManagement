using System.Collections.Generic;
using System.Linq;
using TurnManagement.DataAccess.Interfaces.Persistence.Core;
using TurnManagement.Domain.Entities;

namespace TurnManagement.DataAccess.Interfaces.Persistence.Repositories
{
    public interface IProfessionalRepository //: IBaseCrudRepository<Professional>
    {
        Professional Get(int id, bool asNoTracking = true);

        IQueryable<Professional> GetAll(bool asNoTracking = true);

        IQueryable<Professional> GetByIds(IEnumerable<int> ids, bool asNoTracking = true);

        int Add(Professional entity, bool withoutSaveChanges = false);

        void Update(Professional entity, bool withoutSaveChanges = false);

        void Delete(int id, bool withoutSaveChanges = false);

        int SaveChanges();
    }
}
