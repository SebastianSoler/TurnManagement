using TurnManagement.Domain.Entities;

namespace TurnManagement.DataAccess.Persistence.EntityConfiguration
{
    public class ProfessionalConfiguration : BaseEntityConfiguration<Professional>
    {
        public ProfessionalConfiguration() : base()
        {            
            Property(x => x.Name).HasMaxLength(256).IsRequired();

            Property(x => x.SurnName).HasMaxLength(256).IsRequired();
             
            Property(x => x.DateOfBirth).IsRequired();

            Property(x => x.Email).IsRequired();

            Property(x => x.CellPhone).HasMaxLength(30).IsOptional();

            Property(x => x.Dni).IsOptional().HasMaxLength(10);
            
            Property(x => x.Genre).HasMaxLength(10).IsRequired();
            
            Property(x => x.Address).HasMaxLength(200).IsOptional();
        }
    }
}
