namespace ProjectManagement.Persistence
{
    /// <summary>
    /// Configuration definition
    /// </summary>
    public interface IConfig
    {
        /// <summary>
        /// Event that gets triggered when the save is called
        /// </summary>
        event EventHandler ConfigUpdated;

        /// <summary>
        /// Gets whether or not to show the "Done" Tasks
        /// </summary>
        bool ShowDoneTasks { get; set; }

        /// <summary>
        /// Saves the <see cref="IConfig"/>
        /// </summary>
        void Save();
    }
}
