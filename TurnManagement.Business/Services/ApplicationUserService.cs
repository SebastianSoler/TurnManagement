using System.Collections.Generic;
using TurnManagement.Business.Core;
using TurnManagement.Business.Interfaces.Services;
using TurnManagement.DataAccess.Interfaces.Persistence.Core;
using TurnManagement.DataAccess.Interfaces.Persistence.Repositories;
using TurnManagement.Domain.Entities;

namespace TurnManagement.Business.Services
{
    public class ApplicationUserService : IApplicationUserService// BaseService<ApplicationUser>, IApplicationUserService
    {
        private readonly IApplicationUserRepository baseRepository;

        public ApplicationUserService(IApplicationUserRepository baseRepository)// : base(baseRepository)
        {
            this.baseRepository = baseRepository;
        }

        public int Add(ApplicationUser item)
        {
            return Add(item);
        }

        public void Delete(int id)
        {
            Delete(id);
        }

        public ApplicationUser Get(int id)
        {
            return Get(id);
        }

        public IEnumerable<ApplicationUser> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<ApplicationUser> GetByIds(IEnumerable<int> Ids)
        {
            throw new System.NotImplementedException();
        }

        public void Update(ApplicationUser item)
        {
            Update(item);
        }

        protected void BusinessValidations(ApplicationUser item)
        {
            BusinessValidations(item);
        }

        protected void PreAddEntityHandler(ApplicationUser item)
        {
            PreAddEntityHandler(item);
        }
    }
}
