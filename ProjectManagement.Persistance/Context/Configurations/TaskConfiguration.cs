using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectManagement.Core;

namespace ProjectManagement.Persistance
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
        }
    }
}
