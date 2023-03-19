namespace ProjectManagement.Core
{
    /// <summary>
    /// Defines a thing to do
    /// </summary>
    public class Task : BaseAuditableEntity
    {
        #region Private Members

        /// <summary>
        /// The locally stored description
        /// </summary>
        private string mDescription = string.Empty;

        /// <summary>
        /// The locally stored status
        /// </summary>
        private TaskStatus mStatus = TaskStatus.NotYetStarted;

        /// <summary>
        /// The locally stored pool
        /// </summary>
        private Pool? mPool = null;

        /// <summary>
        /// The locally stored bucket
        /// </summary>
        private Bucket? mBucket = null;

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the description of the task
        /// </summary>
        public string Description 
        {
            get => mDescription;
            set
            {
                mDescription = value;
                Update();
            }
        }

        /// <summary>
        /// Gets or sets the status
        /// </summary>
        public TaskStatus Status 
        {
            get => mStatus;
            set
            {
                mStatus = value;
                Update();
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="Core.Pool"/> associated with the <see cref="Task"/>
        /// </summary>
        public Pool? Pool {
            get => mPool;
            set
            {
                mPool = value;
                Update();
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="Core.Bucket"/> that the task is in
        /// </summary>
        public Bucket? Bucket {
            get => mBucket;
            set
            {
                mBucket = value;
                Update();
            }
        }

        #endregion
    }
}
