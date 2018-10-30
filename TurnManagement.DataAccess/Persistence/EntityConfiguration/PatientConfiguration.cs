using TurnManagement.Domain.Entities;

namespace TurnManagement.DataAccess.Persistence.EntityConfiguration
{
    public class PatientConfiguration : BaseEntityConfiguration<Patient>
    {
        public PatientConfiguration() : base()
        {
            Property(x => x.Name).HasMaxLength(256).IsRequired();

            Property(x => x.SurnName).HasMaxLength(256).IsRequired();
            
            Property(x => x.Dni).HasMaxLength(10).IsRequired();

            Property(x => x.Genre).HasMaxLength(10).IsRequired();

            Property(x => x.DateOfBirth).IsOptional();

            Property(x => x.Address).HasMaxLength(200).IsOptional();

            Property(x => x.HealthInsurance).HasMaxLength(60).IsOptional();

            Property(x => x.Plan).HasMaxLength(20).IsOptional();

            Property(x => x.Email).HasMaxLength(100).IsOptional();

            Property(x => x.CellPhone).HasMaxLength(30).IsOptional();

            Property(x => x.Phone).HasMaxLength(30).IsOptional();

            Property(x => x.Note).HasMaxLength(256).IsOptional();
        }
    }
}
