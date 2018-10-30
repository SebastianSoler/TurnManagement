using System.Linq;
using TurnManagement.DataAccess.Interfaces.Persistence.Core;
using TurnManagement.DataAccess.Interfaces.Persistence.Repositories;
using TurnManagement.DataAccess.Persistence.Core;
using TurnManagement.Domain.Entities;

namespace TurnManagement.DataAccess.Persistence.Repositories
{
    public class PatientRepository : BaseRepository<Patient>,IPatientRepository
    {
        public PatientRepository (ITurnManagementDataContext context) : base(context)
        {
        }

        public override int Add(Patient entity, bool withoutSaveChanges = false)
        {
            var query = baseCollection.Where(x => x.Dni == entity.Dni && x.IsDeleted);

            if (query != null)
            {
                var deletedPatient = query.SingleOrDefault();
                deletedPatient.IsDeleted = false;

                base.UpdateDeletedEntity(deletedPatient, withoutSaveChanges);

                return deletedPatient.Id;
            }

            return base.Add(entity, withoutSaveChanges);
        }
    }
}
