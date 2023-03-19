namespace ProjectManagement.Core
{
    /// <summary>
    /// Base Auditable Entity for any entities that need auditability
    /// </summary>
    public class BaseAuditableEntity : BaseEntity
    {
        #region Public Properties

        /// <summary>
        /// Gets the creation time of the <see cref="BaseAuditableEntity"/>
        /// </summary>
        public DateTime CreationTime { get; private set; }

        /// <summary>
        /// Gets the creation user of the <see cref="BaseAuditableEntity"/>
        /// </summary>
        public string CreationUser { get; private set; }

        /// <summary>
        /// Gets the update time of the <see cref="BaseAuditableEntity"/>
        /// </summary>
        public DateTime? UpdateTime { get; private set; }

        /// <summary>
        /// Gets the update user of the <see cref="BaseAuditableEntity"/>
        /// </summary>
        public string? UpdateUser { get; private set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public BaseAuditableEntity() : base()
        {
            // Set creation variables
            CreationTime = DateTime.Now;
            CreationUser = Environment.UserName;
        }

        #endregion

        #region Protected Functions

        /// <summary>
        /// Updates the <see cref="BaseAuditableEntity"/>
        /// </summary>
        protected void Update()
        {
            // Set update user
            UpdateUser = Environment.UserName;
            // Set update time
            UpdateTime = DateTime.Now;
        }

        #endregion
    }
}
