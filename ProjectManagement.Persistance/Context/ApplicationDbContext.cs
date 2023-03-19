using Microsoft.EntityFrameworkCore;
using ProjectManagement.Core;

namespace ProjectManagement.Persistance;

/// <summary>
/// The <see cref="DbContext"/> for the application
/// </summary>
public class ApplicationDbContext: DbContext
{
    #region DbSets

    /// <summary>
    /// Gets the database set for the pools
    /// </summary>
    public DbSet<Pool> Pools { get; set; }

    /// <summary>
    /// Gets the database set for the buckets
    /// </summary>
    public DbSet<Bucket> Buckets { get; set; }

    /// <summary>
    /// Gets the database set for the tasks
    /// </summary>
    public DbSet<Core.Task> Tasks { get; set; }

    /// <summary>
    /// Gets the database set for the tags
    /// </summary>
    public DbSet<Tag> Tags { get; set; }

    #endregion

    #region Configuration

    /// <inheritdoc/>
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Create the directory path of the database file
        var path = Path.Join(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "ProjectManagement");

        // Ensure the directory exists
        if (!Directory.Exists(path))
            Directory.CreateDirectory(path);

        // Setup the database to use sqlite
        optionsBuilder.UseSqlite($"Data Source={Path.Join(path, $"ProjectManagement.db")}");
    }

    /// <inheritdoc/>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Apply configurations
        modelBuilder.ApplyConfiguration(new PoolConfiguration());
        modelBuilder.ApplyConfiguration(new TaskConfiguration());
        modelBuilder.ApplyConfiguration(new TagConfiguration());
    }

    #endregion
}
