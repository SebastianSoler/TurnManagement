using System;
using System.Collections.Generic;
using System.Linq;
using TurnManagement.DataAccess.Interfaces.Persistence.Core;
using TurnManagement.DataAccess.Interfaces.Persistence.Repositories;
using TurnManagement.DataAccess.Persistence.Core;
using TurnManagement.Domain.Entities;

namespace TurnManagement.DataAccess.Persistence.Repositories
{
    public class ApplicationUserRepository : IApplicationUserRepository//: BaseCrudRepository<ApplicationUser>, IApplicationUserRepository
    {
        protected ITurnManagementDataContext dataContext { get; }

        public ApplicationUserRepository ()//(ITurnManagementDataContext context) //: base(context)
        {
            //dataContext = context;
        }

        public int Add(ApplicationUser entity, bool withoutSaveChanges = false)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id, bool withoutSaveChanges = false)
        {
            throw new NotImplementedException();
        }

        public ApplicationUser Get(int id, bool asNoTracking = true)
        {
            throw new NotImplementedException();
        }

        public IQueryable<ApplicationUser> GetAll(bool asNoTracking = true)
        {
            throw new NotImplementedException();
        }

        public IQueryable<ApplicationUser> GetByIds(IEnumerable<int> ids, bool asNoTracking = true)
        {
            throw new NotImplementedException();
        }

        public int SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void Update(ApplicationUser entity, bool withoutSaveChanges = false)
        {
            throw new NotImplementedException();
        }
    }
}
