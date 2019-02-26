using System.Linq;
using TurnManagement.DataAccess.Interfaces.Persistence.Core;
using TurnManagement.DataAccess.Interfaces.Persistence.Repositories;
using TurnManagement.DataAccess.Persistence.Core;
using TurnManagement.Domain.Entities;

namespace TurnManagement.DataAccess.Persistence.Repositories
{
    public class ProfessionalRepository : BaseRepository<Professional>, IProfessionalRepository
    {
        public ProfessionalRepository(ITurnManagementDataContext context) : base(context)
        {
        }

        public override int Add(Professional entity, bool withoutSaveChanges = false)
        {
            var query = baseCollection.Where(x => x.Dni == entity.Dni && x.IsDeleted);

            if (query != null)
            {
                var deletedProfessional = query.SingleOrDefault();
                deletedProfessional.IsDeleted = false;

                base.UpdateDeletedEntity(deletedProfessional, withoutSaveChanges);

                return deletedProfessional.Id;
            }

            return base.Add(entity, withoutSaveChanges);
        }
    }
}
