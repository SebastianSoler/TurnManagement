using TurnManagement.Business.Core;
using TurnManagement.Business.Interfaces.Services;
using TurnManagement.DataAccess.Interfaces.Persistence.Repositories;
using TurnManagement.Domain.Entities;

namespace TurnManagement.Business.Services
{
    public class TurnService : BaseService<Turn>, ITurnService
    {
        public TurnService (ITurnRepository baseRepository) : base(baseRepository)
        {
        }
    }
}
