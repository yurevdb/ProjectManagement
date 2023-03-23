using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectManagement.Core;

namespace ProjectManagement.Persistence
{
    /// <summary>
    /// Type configuration for <see cref="Tag"/>
    /// </summary>
    public class TagConfiguration : IEntityTypeConfiguration<Tag>
    {
        /// <inheritdoc/>
        public void Configure(EntityTypeBuilder<Tag> builder)
        {
            builder.OwnsOne(t => t.Colour);
        }
    }
}
