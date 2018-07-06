using TurnManagement.DataAccess.Persistence.EntityConfiguration;
using TurnManagement.Domain.Entities;

namespace TurnManagement.DataAccess.Persistence.EntityConfigurations
{
    public class ApplicationUserConfiguration : BaseEntityConfiguration<ApplicationUser>
    {
        public ApplicationUserConfiguration(): base()
        {
            Property(x => x.UserName).HasMaxLength(25).IsRequired();

            Property(x => x.Password).HasMaxLength(20).IsRequired();
        }
    }
}
