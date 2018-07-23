using System;
using System.Collections.Generic;
using System.Linq;
using TurnManagement.Domain.Entities;

namespace TurnManagement.DataAccess.Interfaces.Persistence.Core
{
    public interface IBaseRepository<TEntity> : IDisposable where TEntity : BaseEntity
    {
        TEntity Get(int id, bool asNoTracking = true);
        
        IQueryable<TEntity> GetAll(bool asNoTracking = true);

        IQueryable<TEntity> GetByIds(IEnumerable<int> ids, bool asNoTracking = true);

        int Add(TEntity entity, bool withoutSaveChanges = false);

        void Update(TEntity entity, bool withoutSaveChanges = false);

        void Delete(int id, bool withoutSaveChanges = false);

        int SaveChanges();
    }
}

