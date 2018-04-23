using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using TurnManagement.Domain.Entities;

namespace TurnManagement.DataAccess.Interfaces.Persistence.Core
{
    public interface IQuerableDataContext
    {
        string DataBaseName { get; }

        int SaveChanges(string loggedUser);

        Task<int> SaveChangesAsync(string loggedUser);

        IList<TEntity> ExecuteQuery<TEntity>(string command, params SqlParameter[] parameters);

        int ExecuteNonQuery(string command);

        int ExecuteStoredProcedure(string storedProcedureName, params SqlParameter[] parameters);

        void Clear<TEntity>() where TEntity : BaseEntity;

        void Refresh<T>(T entity) where T : BaseEntity;
    }
}
