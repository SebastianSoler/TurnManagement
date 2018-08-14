using TurnManagement.Business.Interfaces.Core;
using TurnManagement.Domain.Entities;

namespace TurnManagement.Business.Interfaces.Services
{
    public interface IApplicationUserService : IBaseService<ApplicationUser>
    {
        bool LoginUser(ApplicationUser user);
    }
}
