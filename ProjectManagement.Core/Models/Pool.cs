namespace ProjectManagement.Core
{
    /// <summary>
    /// A pool of tasks
    /// </summary>
    public class Pool : BaseAuditableEntity
    {
        #region Private Members

        /// <summary>
        /// The locally stored tasks
        /// </summary>
        private readonly IList<Task> mTasks;

        /// <summary>
        /// The locally stored name
        /// </summary>
        private string mName = string.Empty;

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the name of the <see cref="Pool"/>
        /// </summary>
        public string Name
        {
            get => mName;
            set
            {
                mName = value;
                Update();
            }
        }

        /// <summary>
        /// Gets the tasks in the pool
        /// </summary>
        public IEnumerable<Task> Tasks => mTasks.ToList();

        #endregion

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public Pool()
        {
            // Initialize the lists
            mTasks = new List<Task>();
        }

        #endregion

        #region Public Functions

        /// <summary>
        /// Add a <see cref="Task"/> to the <see cref="Pool"/>
        /// </summary>
        /// <param name="task">The <see cref="Task"/> to add</param>
        public void AddTask(Task task)
        {
            // Add the task
            mTasks.Add(task);
            task.Pool = this;

            // Set as updated
            Update();
        }

        #endregion
    }
}
