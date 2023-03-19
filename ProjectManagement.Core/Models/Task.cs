namespace ProjectManagement.Core
{
    /// <summary>
    /// Defines a thing to do
    /// </summary>
    public class Task : BaseAuditableEntity
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the description of the task
        /// </summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the status
        /// </summary>
        public TaskStatus Status { get; set; } = TaskStatus.NotYetStarted;

        /// <summary>
        /// Gets or sets the <see cref="Core.Pool"/> associated with the <see cref="Task"/>
        /// </summary>
        public Pool? Pool { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="Core.Bucket"/> that the task is in
        /// </summary>
        public Bucket? Bucket { get; set; }

        #endregion
    }
}
