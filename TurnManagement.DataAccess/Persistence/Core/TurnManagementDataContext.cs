using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using TurnManagement.DataAccess.Interfaces.Persistence.Core;
using TurnManagement.DataAccess.Persistence.EntityConfiguration;
using TurnManagement.Domain.Entities;

namespace TurnManagement.DataAccess.Persistence.Core
{
    public class TurnManagementDataContext : DbContext, ITurnManagementDataContext
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["TurnManagementConnection"].ToString();

        public string DataBaseName { get { return Database.Connection.Database; } }

        public virtual IDbSet<Professional> Professionals { get; set; }
        public virtual IDbSet<Patient> Patients { get; set; }
        public virtual IDbSet<ApplicationUser> ApplicationUser { get; set; }

        public TurnManagementDataContext(): base(connectionString)//("name=TurnManagementConnection")
        {
            Configuration.ProxyCreationEnabled = true;
            Configuration.LazyLoadingEnabled = true;

            Database.SetInitializer<TurnManagementDataContext>(null);

            ((IObjectContextAdapter)this).ObjectContext.CommandTimeout = 120;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Configurations.Add(new ProfessionalConfiguration());
            modelBuilder.Configurations.Add(new ApplicationUserConfiguration());
            modelBuilder.Configurations.Add(new PatientConfiguration());

        }

        public int SaveChanges(string loggedUser)
        {            
            return base.SaveChanges();
        }

        public async Task<int> SaveChangesAsync(string loggedUser)
        {
            return await base.SaveChangesAsync();
        }

        public void Clear<TEntity>() where TEntity : BaseEntity
        {
            foreach (var item in Set<TEntity>())
            {
                Entry(item).State = EntityState.Deleted;
            }
        }

        public void Refresh<T>(T entity) where T : BaseEntity
        {
            if (entity == null)
            {
                return;
            }

            Entry(entity).Reload();
        }

        public IList<TEntity> ExecuteQuery<TEntity>(string command, params SqlParameter[] parameters)
        {
            return Database.SqlQuery<TEntity>(command, parameters).ToList();
        }

        public int ExecuteNonQuery(string command)
        {
            return Database.ExecuteSqlCommand(command);
        }

        public int ExecuteStoredProcedure(string storedProcedureName, params SqlParameter[] parameters)
        {
            string parametersName = parameters.Aggregate(" ", (current, param) => current + "@" + param.ParameterName + ", ");

            if (parameters.Any())
            {
                parametersName = parametersName.Substring(0, parametersName.Length - 2);
            }

            return Database.ExecuteSqlCommand(storedProcedureName + parametersName, parameters);
        }
    }
}
