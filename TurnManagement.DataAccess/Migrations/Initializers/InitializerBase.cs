using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using TurnManagement.DataAccess.Interfaces.Persistence.Core;
using TurnManagement.Domain.Entities;

namespace TurnManagement.DataAccess.Migrations.Initializers
{
    public abstract class InitializerBase<TEntity> where TEntity : BaseEntity
    {
        public abstract IQueryable<TEntity> DataSource();

        protected readonly ITurnManagementDataContext dataContext;

        protected const string DataInitializerUser = "DataInitializer";

        protected InitializerBase(ITurnManagementDataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public virtual void Initialize()
        {
            var info = dataContext.GetType().GetProperty(typeof(TEntity).Name);

            var collection = (DbSet<TEntity>)info.GetValue(dataContext);

            DataSource().ToList().ForEach(x => collection.AddOrUpdate(x));

            dataContext.SaveChanges(DataInitializerUser);
        }
    }
}
