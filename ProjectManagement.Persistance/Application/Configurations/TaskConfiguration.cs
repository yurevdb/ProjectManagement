using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProjectManagement.Persistence
{
    /// <summary>
    /// Type configuration for <see cref="Core.Task"/>
    /// </summary>
    public class TaskConfiguration : IEntityTypeConfiguration<Core.Task>
    {
        /// <inheritdoc/>
        public void Configure(EntityTypeBuilder<Core.Task> builder)
        {
            builder.HasKey(t => t.Id);

            builder.HasOne(t => t.Pool).WithMany(p => p.Tasks);

            builder.HasMany(t => t.Tags);

            builder.Metadata.FindNavigation(nameof(Core.Task.Tags))?.SetField("mTags");
            builder.Metadata.FindNavigation(nameof(Core.Task.Tags))?.SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
