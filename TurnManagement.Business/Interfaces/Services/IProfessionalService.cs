using System.Collections.Generic;
using TurnManagement.Business.Interfaces.Core;
using TurnManagement.Domain.Entities;

namespace TurnManagement.Business.Interfaces.Services
{
    public interface IProfessionalService : IBaseService<Professional>
    {
        IEnumerable<Professional> GetProfessionals(string professionalSearch);
    }
}
