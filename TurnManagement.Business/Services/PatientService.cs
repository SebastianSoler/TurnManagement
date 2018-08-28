using TurnManagement.Business.Core;
using TurnManagement.Business.Interfaces.Services;
using TurnManagement.DataAccess.Interfaces.Persistence.Repositories;
using TurnManagement.Domain.Entities;

namespace TurnManagement.Business.Services
{
    public class PatientService : BaseService<Patient>, IPatientService
    {
        public PatientService(IPatientRepository baseRepository) : base(baseRepository)
        {
        }

        protected override void BusinessValidations(Patient item)
        {
            //validaciones de negocio
        }
    }
}
