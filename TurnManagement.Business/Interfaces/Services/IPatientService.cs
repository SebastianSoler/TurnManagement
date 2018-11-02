using System.Collections.Generic;
using TurnManagement.Business.Interfaces.Core;
using TurnManagement.Domain.Entities;

namespace TurnManagement.Business.Interfaces.Services
{
    public interface IPatientService : IBaseService<Patient>
    {
        IEnumerable<Patient> GetPatients(string PatientSearch);
    }
}
