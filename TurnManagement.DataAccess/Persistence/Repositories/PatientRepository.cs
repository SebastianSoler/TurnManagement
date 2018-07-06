using TurnManagement.DataAccess.Interfaces.Persistence.Core;

namespace TurnManagement.DataAccess.Persistence.Repositories
{
    public class PatientRepository //: BaseCrudRepository<Patient>,
    {
        public PatientRepository(ITurnManagementDataContext context) //: base(context)
        {
        }
    }
}
