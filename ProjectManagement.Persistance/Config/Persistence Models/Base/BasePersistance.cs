using Microsoft.EntityFrameworkCore;

namespace ProjectManagement.Persistence
{
    /// <summary>
    /// Base persistance configuration
    /// </summary>
    public abstract class BasePersistance
    {
        /// <summary>
        /// Configure the <see cref="DbContext"/> for the specified persistance method
        /// </summary>
        /// <param name="optionsBuilder"></param>
        public abstract void Configure(DbContextOptionsBuilder optionsBuilder);
    }
}
