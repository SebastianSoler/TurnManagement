using TurnManagement.Domain.Entities;

namespace TurnManagement.DataAccess.Persistence.EntityConfiguration
{
    public class TurnConfiguration : BaseEntityConfiguration<Turn>
    {
        public TurnConfiguration() : base()
        {            
            Property(x => x.ProfessionalId).IsRequired();

            Property(x => x.SpecialityId).IsRequired();

            Property(x => x.PatientId).IsRequired();

            Property(x => x.StartDateTime).IsRequired();
             
            Property(x => x.EndDateTime).IsRequired();

            Property(x => x.Status).IsRequired();

            Property(x => x.Subject).HasMaxLength(256).IsOptional();

            Property(x => x.Comment).HasMaxLength(256).IsOptional();
        }
    }
}
