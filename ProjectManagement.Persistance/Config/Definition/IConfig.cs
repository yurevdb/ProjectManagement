namespace ProjectManagement.Persistence
{
    /// <summary>
    /// Configuration definition
    /// </summary>
    public interface IConfig
    {
        #region Code Stuff

        /// <summary>
        /// Event that gets triggered when the save is called
        /// </summary>
        event EventHandler ConfigUpdated;

        /// <summary>
        /// Saves the <see cref="IConfig"/>
        /// </summary>
        void Save();

        #endregion

        #region Configuration

        /// <summary>
        /// Gets whether or not to show the "Done" Tasks
        /// </summary>
        bool ShowDoneTasks { get; set; }

        /// <summary>
        /// Gets the persistence method for sqlite
        /// </summary>
        SqlitePersistance? Sqlite { get; set; }

        /// <summary>
        /// Gets the persistence method for sql server
        /// </summary>
        SqlServerPersistence? SqlServer { get; set; }

        #endregion
    }
}
