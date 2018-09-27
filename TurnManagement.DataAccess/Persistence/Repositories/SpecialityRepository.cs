using System.Linq;
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

        public override int Add(Speciality entity, bool withoutSaveChanges = false)
        {
            var query = baseCollection.Where(x => x.Name.ToLower() == entity.Name.ToLower() && x.IsDeleted);

            if (query != null)
            {
                var deletedSpeciality = query.SingleOrDefault();
                deletedSpeciality.IsDeleted = false;

                base.UpdateDeletedEntity(deletedSpeciality, withoutSaveChanges);

                return deletedSpeciality.Id;
            }

            return base.Add(entity, withoutSaveChanges);
        }
    }
}
