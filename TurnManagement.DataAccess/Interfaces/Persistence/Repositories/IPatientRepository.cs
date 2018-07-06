using System.Collections.Generic;
using System.Linq;
using TurnManagement.Domain.Entities;

namespace TurnManagement.DataAccess.Interfaces.Persistence.Repositories
{
    public interface IPatientRepository //: IBaseCrudRepository<Patient>
    {
        Patient Get(int id, bool asNoTracking = true);

        IQueryable<Patient> GetAll(bool asNoTracking = true);

        IQueryable<Patient> GetByIds(IEnumerable<int> ids, bool asNoTracking = true);

        int Add(Patient entity, bool withoutSaveChanges = false);

        void Update(Patient entity, bool withoutSaveChanges = false);

        void Delete(int id, bool withoutSaveChanges = false);

        int SaveChanges();
    }
}
