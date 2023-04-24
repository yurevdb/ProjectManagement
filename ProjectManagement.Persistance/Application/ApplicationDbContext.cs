using Microsoft.EntityFrameworkCore;
using ProjectManagement.Core;

namespace ProjectManagement.Persistence;

/// <summary>
/// The <see cref="DbContext"/> for the application
/// </summary>
public class ApplicationDbContext: DbContext
{
    #region Private Members

    /// <summary>
    /// The locally stored <see cref="IConfig"/>
    /// </summary>
    private readonly IConfig mConfig;

    #endregion

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

    #region Constructor

    /// <summary>
    /// Default Constructor
    /// </summary>
    public ApplicationDbContext(IConfig config)
    {
        mConfig = config;
    }

    #endregion

    #region Configuration

    /// <inheritdoc/>
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
#if DEBUG
        optionsBuilder.UseInMemoryDatabase("debug");
#endif

#if !DEBUG
        // TODO: find a more beautiful solution to choosing the persistence method
        if (mConfig.SqlServer != null)
        {
            mConfig.SqlServer.Configure(optionsBuilder);
            return;
        }

        if (mConfig.Sqlite != null)
        {
            mConfig.Sqlite.Configure(optionsBuilder);
            return;
        }
#endif
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
