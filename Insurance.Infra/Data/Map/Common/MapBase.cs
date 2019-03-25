using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Insurance.Domain.Entities.Common;

namespace Insurance.Infraestructure.Data.Map.Common
{
    public abstract class MapBase<TEntity> : EntityTypeConfiguration<TEntity>
        where TEntity : EntityBase
    {
        public MapBase()
        {

            Property(t => t.Id)
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
}