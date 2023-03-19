namespace ProjectManagement.Core
{
    /// <summary>
    /// Defines the status of a <see cref="Task"/>
    /// </summary>
    public enum TaskStatus
    {
        /// <summary>
        /// Signals that the <see cref="Task"/> has not been started
        /// </summary>
        NotYetStarted = 0,

        /// <summary>
        /// Signals that the <see cref="Task"/> is in progress
        /// </summary>
        InProgress = 1,

        /// <summary>
        /// Signals that the <see cref="Task"/> is done
        /// </summary>
        Done = 2,

        /// <summary>
        /// Signals that the <see cref="Task"/> is on hold
        /// </summary>
        OnHold = 3
    }
}
