using Microsoft.EntityFrameworkCore;

namespace ProjectManagement.Persistence
{
    /// <summary>
    /// Persistance model for sqlite
    /// </summary>
    public class SqlitePersistance : BasePersistance
    {
        #region Public Properties

        /// <summary>
        /// Gets the location for the sqlite file
        /// </summary>
        public string Path { get; set; } = string.Empty;

        #endregion

        #region Public Functions

        /// <inheritdoc/>
        public override void Configure(DbContextOptionsBuilder optionsBuilder)
        {
            // Ensure the directory exists
            if (!Directory.Exists(System.IO.Path.GetDirectoryName(Path)))
                Directory.CreateDirectory(System.IO.Path.GetDirectoryName(Path));

            // Setup the database to use SQLite
            optionsBuilder.UseSqlite($"Data Source={Path}");
        }

        #endregion
    }
}
