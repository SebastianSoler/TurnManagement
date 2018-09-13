using System.Collections.Generic;
using System.Linq;
using TurnManagement.DataAccess.Interfaces.Persistence.Core;
using TurnManagement.Domain.Entities;

namespace TurnManagement.DataAccess.Migrations.Initializers
{
    public class SpecialityDataInitializer : BaseInitializer<Speciality>
    {
        public SpecialityDataInitializer(ITurnManagementDataContext dataContext) : base(dataContext) { }

        public override IQueryable<Speciality> DataSource()
        {
            var list = new List<Speciality>()
            {
                new Speciality(){ Id = 1, Name = "Odontología", IsDeleted = false },
                new Speciality(){ Id = 2, Name = "Psicología", IsDeleted = false },
                new Speciality(){ Id = 3, Name = "Neurología", IsDeleted = false },
                new Speciality(){ Id = 4, Name = "Psicopedagogía", IsDeleted = false }
            };

            return list.AsQueryable();
        }
    }
}
