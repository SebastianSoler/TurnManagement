using TurnManagement.Business.Core;
using TurnManagement.Business.Interfaces.Services;
using TurnManagement.DataAccess.Interfaces.Persistence.Repositories;
using TurnManagement.Domain.Entities;

namespace TurnManagement.Business.Services
{
    public class ProfessionalService : BaseService<Professional>, IProfessionalService
    {
        public ProfessionalService(IProfessionalRepository baseRepository) : base(baseRepository)
        {
        }

        protected override void BusinessValidations(Professional item)
        {
            //validaciones de negocio
        }
    }
}
