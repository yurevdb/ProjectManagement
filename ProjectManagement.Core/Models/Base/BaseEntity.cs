namespace ProjectManagement.Core
{
    /// <summary>
    /// Base entity for any and all entities
    /// </summary>
    public class BaseEntity
    {
        #region Public Properties

        /// <summary>
        /// Gets the Id of the <see cref="BaseEntity"/>
        /// </summary>
        public Guid Id { get; private set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public BaseEntity()
        {
            // Create an ID
            Id = Guid.NewGuid();
        }

        #endregion
    }
}
