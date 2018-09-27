using System.Linq;
using Propago.Net.CrossCutting.CustomException;
using TurnManagement.Business.Core;
using TurnManagement.Business.Interfaces.Services;
using TurnManagement.CrossCutting.Strings;
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
            base.BusinessValidations(item);
            
            var baseQuery = baseRepository.GetAll();

            AddBusinessExceptionValidation(!string.IsNullOrWhiteSpace(item.Name), ValidationMessages.EmptyName);

            AddBusinessExceptionValidation(!baseQuery.Any(x => x.Name.ToLower() == item.Name.ToLower()), ValidationMessages.DuplicatedSpecialityName);
        }

        public override void Update(Speciality item)
        {
            var duplicatedNameSpeciality = baseRepository.GetAll().Any(x => x.Name.ToLower() == item.Name.ToLower() && x.Id != item.Id);

            if (duplicatedNameSpeciality)
            {
                throw new BusinessException(ValidationMessages.DuplicatedSpecialityName);
            }

            base.Update(item);
        }
    }
}
