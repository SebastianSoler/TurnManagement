using TurnManagement.Domain.Entities;

namespace TurnManagement.DataAccess.Persistence.EntityConfiguration
{
    public class ProfessionalConfiguration : BaseEntityConfiguration<Professional>
    {
        public ProfessionalConfiguration() : base()
        {            
            Property(x => x.Name).HasMaxLength(256).IsRequired();

            Property(x => x.SurName).HasMaxLength(256).IsRequired();
             
            Property(x => x.Date).IsRequired();

            Property(x => x.Telphone).HasMaxLength(25).IsOptional();

            Property(x => x.Dni).IsOptional().HasMaxLength(8);
        }
    }
}
