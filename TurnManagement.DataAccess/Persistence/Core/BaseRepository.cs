using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using TurnManagement.DataAccess.Interfaces.Persistence.Core;
using TurnManagement.Domain.Entities;

namespace TurnManagement.DataAccess.Persistence.Core
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        protected ITurnManagementDataContext dataContext { get; }

        protected readonly DbSet<TEntity> baseCollection;

        private bool disposed;

        public BaseRepository(ITurnManagementDataContext dataContext)
        {
            this.dataContext = dataContext;

            baseCollection = GetCollection(dataContext);
                        
            disposed = false;
        }

        public virtual IQueryable<TEntity> GetAll(bool asNoTracking = true)
        {
            var query = baseCollection.Where(x => !x.IsDeleted);

            if (asNoTracking)
            {
                return query.AsNoTracking();
            }

            return query;
        }

        public virtual TEntity Get(int id, bool asNoTracking = true)
        {    
            return GetAll(asNoTracking).SingleOrDefault(x => x.Id == id && !x.IsDeleted);
        }

        public virtual IQueryable<TEntity> GetByIds(IEnumerable<int> ids, bool asNoTracking = true)
        {
            return GetAll(asNoTracking).Where(x => ids.Contains(x.Id) && !x.IsDeleted);
        }

        public virtual int Add(TEntity entity, bool withoutSaveChanges = false)
        {
            baseCollection.Add(entity);

            if (!withoutSaveChanges)
            {
                SaveChanges();
            }

            return entity.Id;
        }

        public virtual void Delete(int id, bool withoutSaveChanges = false)
        {
            var dbEntity = Get(id);

            dbEntity.IsDeleted = true;

            Update(dbEntity, withoutSaveChanges);
        }

        public virtual void Update(TEntity entity, bool withoutSaveChanges = false)
        {
            var dbEntity = Get(entity.Id, false);

            if (dbEntity != null)
            {
                ((DbContext)dataContext).Entry(dbEntity).CurrentValues.SetValues(entity);

                if (!withoutSaveChanges)
                {
                    SaveChanges();
                }
            }
        }

        public int SaveChanges()
        {
            var loggedUser = "Admin";

            return dataContext.SaveChanges(loggedUser);
        }

        public void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed && disposing)
            {
                dataContext.Dispose();             
            }

            disposed = true;
        }

        [DbFunction("Edm", "TruncateTime")]
        protected static DateTime? TruncateTime(DateTime? date)
        {
            return date.HasValue ? date.Value.Date : (DateTime?)null;
        }

        private DbSet<TEntity> GetCollection(ITurnManagementDataContext context)
        {
            if (baseCollection != null)
            { 
                return baseCollection;
            }

            var propertyName = string.Concat(typeof(TEntity).Name, "s");

            var info = context.GetType().GetProperty(typeof(TEntity).Name);

            return (DbSet<TEntity>)info.GetValue(context);
        }
    }
}
