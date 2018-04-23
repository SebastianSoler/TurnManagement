using System;
using System.Data.Entity;
using TurnManagement.Domain.Entities;

namespace TurnManagement.DataAccess.Interfaces.Persistence.Core
{
    public interface ITurnManagementDataContext : IQuerableDataContext, IDisposable
    {
        IDbSet<Professional> Professionals{ get; set; }
        IDbSet<Patient> Patients { get; set; }       
    }
}
