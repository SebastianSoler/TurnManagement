using System.Collections.Generic;
using TurnManagement.Business.Interfaces.Core;
using TurnManagement.Domain.Entities;

namespace TurnManagement.Business.Interfaces.Services
{
    public interface IApplicationUserService //: IBaseService<ApplicationUser>
    {
        IEnumerable<ApplicationUser> GetAll();

        IEnumerable<ApplicationUser> GetByIds(IEnumerable<int> Ids);

        ApplicationUser Get(int id);

        int Add(ApplicationUser item);

        void Update(ApplicationUser item);

        void Delete(int id);
    }
}
