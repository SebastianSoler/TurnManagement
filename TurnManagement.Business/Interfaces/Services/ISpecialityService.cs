using System.Collections.Generic;
using TurnManagement.Business.Interfaces.Core;
using TurnManagement.Domain.Entities;

namespace TurnManagement.Business.Interfaces.Services
{
    public interface ISpecialityService : IBaseService<Speciality>
    {
        IEnumerable<Speciality> GetSpecialities(string specialityName);
    }
}
