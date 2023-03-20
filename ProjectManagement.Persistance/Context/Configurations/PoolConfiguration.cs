using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectManagement.Core;

namespace ProjectManagement.Persistance
{
    /// <summary>
    /// Type configuration for <see cref="Pool"/>
    /// </summary>
    public class PoolConfiguration : IEntityTypeConfiguration<Pool>
    {
        /// <inheritdoc/>
        public void Configure(EntityTypeBuilder<Pool> builder)
        {
            builder.HasKey(p => p.Id);

            builder.HasMany(p => p.Tasks).WithOne(t => t.Pool);

            builder.Metadata.FindNavigation(nameof(Pool.Tasks))?.SetField("mTasks");
            builder.Metadata.FindNavigation(nameof(Pool.Tasks))?.SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
