using System.Collections.Generic;
using System.Linq;
using TurnManagement.DataAccess.Interfaces.Persistence.Core;
using TurnManagement.Domain.Entities;

namespace TurnManagement.DataAccess.Migrations.Initializers
{
    public class ProfessionalDataInitializer : InitializerBase<Professional>
    {
        public ProfessionalDataInitializer(ITurnManagementDataContext context) : base(context)
        {
        }

        public override IQueryable<Professional> DataSource()
        {
            return new List<Professional>
            {
                new Professional{ Id = 1, Name = "Sebastian" }
                //Crear los necesarios para ver como repercute en la Base de Datos.
            }.AsQueryable();
        }
    }
}