using System.Linq;
using TurnManagement.Business.Core;
using TurnManagement.Business.Interfaces.Services;
using TurnManagement.DataAccess.Interfaces.Persistence.Repositories;
using TurnManagement.Domain.Entities;

namespace TurnManagement.Business.Services
{
    public class ApplicationUserService : BaseService<ApplicationUser>, IApplicationUserService
    {
        public ApplicationUserService(IApplicationUserRepository baseRepository) : base(baseRepository)
        {
        }

        public bool LoginUser(ApplicationUser user)
        {
            var resultLog = false;

            BusinessValidations(user);

            var todo = baseRepository.GetAll(false).ToList();

            resultLog = baseRepository.GetAll(false).ToList()
                                      .Any(x => !x.IsDeleted &&
                                                 x.UserName.Equals(user.UserName) && 
                                                 x.Password.Equals(user.Password));

            return resultLog;
        }

        protected override void BusinessValidations(ApplicationUser item)
        {
            //validaciones de negocio
        }
    }
}
