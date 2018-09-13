using TurnManagement.Domain.Entities;

namespace TurnManagement.DataAccess.Persistence.EntityConfiguration
{
    public class SpecialityConfiguration : BaseEntityConfiguration<Speciality>
    {
        public SpecialityConfiguration() : base()
        {
            Property(x => x.Name).HasMaxLength(100).IsRequired();
        }
    }
}
