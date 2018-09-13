using TurnManagement.Business.Core;
using TurnManagement.Business.Interfaces.Services;
using TurnManagement.DataAccess.Interfaces.Persistence.Repositories;
using TurnManagement.Domain.Entities;

namespace TurnManagement.Business.Services
{
    public class SpecialityService : BaseService<Speciality>, ISpecialityService
    {
        public SpecialityService(ISpecialityRepository baseRepository) : base(baseRepository)
        {
        }

        protected override void BusinessValidations(Speciality item)
        {
            //validaciones de negocio
        }
    }
}
