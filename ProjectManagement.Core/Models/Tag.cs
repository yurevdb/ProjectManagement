namespace ProjectManagement.Core
{
    /// <summary>
    /// Defines a tag
    /// </summary>
    public class Tag : BaseEntity
    {
        #region Properties

        /// <summary>
        /// The name of the tag
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The <see cref="ColourCode"/> of the tag
        /// </summary>
        public ColourCode Colour { get; set; }

        #endregion
    }
}
