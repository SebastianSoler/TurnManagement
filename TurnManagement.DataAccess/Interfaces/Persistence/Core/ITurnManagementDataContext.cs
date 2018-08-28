using System;
using System.Data.Entity;
using TurnManagement.Domain.Entities;

namespace TurnManagement.DataAccess.Interfaces.Persistence.Core
{
    public interface ITurnManagementDataContext : IQuerableDataContext, IDisposable
    {
        IDbSet<Professional> Professional{ get; set; }
        IDbSet<Patient> Patient { get; set; }
        IDbSet<ApplicationUser> ApplicationUser { get; set; }
    }
}
