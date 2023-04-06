using Microsoft.EntityFrameworkCore;

namespace ProjectManagement.Persistence
{
    /// <summary>
    /// Persistence model for sql server
    /// </summary>
    public class SqlServerPersistence : BasePersistance
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the connection string
        /// </summary>
        public string Server { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the username
        /// </summary>
        public string UserName { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the password
        /// </summary>
        public string Password { get; set; } = string.Empty;

        #endregion

        #region Public Functions

        /// <inheritdoc/>
        public override void Configure(DbContextOptionsBuilder optionsBuilder)
        {
            // Build the connection string
            var connectionString = $"Server={Server};Database=Taskr;User Id={UserName};Password={Password};TrustServerCertificate=True;";

            // Set the use of sql server
            optionsBuilder.UseSqlServer(connectionString);
        }

        #endregion
    }
}
