using TurnManagement.DataAccess.Interfaces.Persistence.Core;
using TurnManagement.DataAccess.Interfaces.Persistence.Repositories;
using TurnManagement.DataAccess.Persistence.Core;
using TurnManagement.Domain.Entities;

namespace TurnManagement.DataAccess.Persistence.Repositories
{
    public class SpecialityRepository : BaseRepository<Speciality>, ISpecialityRepository
    {
        public SpecialityRepository(ITurnManagementDataContext context) : base(context)
        {
        }
    }
}
