using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using TurnManagement.Domain.Entities;

namespace TurnManagement.DataAccess.Persistence.EntityConfiguration
{
    public class BaseEntityConfiguration<TEntity> : EntityTypeConfiguration<TEntity> where TEntity : BaseEntity
    {
        public BaseEntityConfiguration()
        {
            HasKey(x => x.Id);

            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.CreatedDate).IsRequired();

            Property(x => x.CreatedBy).IsRequired();

            Property(x => x.ModifiedBy).IsOptional();

            Property(x => x.ModifiedDate).IsOptional();
                        
            Property(x => x.IsDeleted).IsRequired();

            ToTable(typeof(TEntity).Name);
        }
    }
}
