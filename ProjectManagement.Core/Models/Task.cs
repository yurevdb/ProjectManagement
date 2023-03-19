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

        /// <summary>
        /// The locally stored complexity
        /// </summary>
        private TaskComplexity mComplexity = TaskComplexity.Medium;

        /// <summary>
        /// The locally stored tags
        /// </summary>
        private readonly IList<Tag> mTags;

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
        /// Gets or sets the complexity
        /// </summary>
        public TaskComplexity Complexity 
        {
            get => mComplexity;
            set
            {
                mComplexity = value;
                Update();
            }
        }

        /// <summary>
        /// Gets the tags associated with the task
        /// </summary>
        public IEnumerable<Tag> Tags => mTags.ToList();

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

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public Task()
        {
            // Initialize the lists
            mTags = new List<Tag>();
        }

        #endregion
    }
}
