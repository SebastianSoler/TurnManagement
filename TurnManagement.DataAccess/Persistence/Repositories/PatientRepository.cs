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
    }
}
