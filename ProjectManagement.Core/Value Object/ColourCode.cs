namespace ProjectManagement.Core
{
    /// <summary>
    /// Defines a colour
    /// </summary>
    public class ColourCode : ValueObject
    {
        #region Public Properties

        /// <summary>
        /// Gets the red value
        /// </summary>
        public byte R { get; private set; }

        /// <summary>
        /// Gets the green value
        /// </summary>
        public byte G { get; private set; }

        /// <summary>
        /// Gets the blue value
        /// </summary>
        public byte B { get; private set; }

        /// <summary>
        /// Gets the alpha value
        /// </summary>
        public byte A { get; private set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="R">The red value</param>
        /// <param name="G">The green value</param>
        /// <param name="B">The blue value</param>
        public ColourCode(byte R, byte G, byte B)
        {
            this.R = R;
            this.G = G;
            this.B = B;
            A = 1;
        }

        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="R">The red value</param>
        /// <param name="G">The green value</param>
        /// <param name="B">The blue value</param>
        /// <param name="A">The alpha value</param>
        public ColourCode(byte R, byte G, byte B, byte A)
        {
            this.R = R;
            this.G = G;
            this.B = B;
            this.A = A;
        }

        #endregion

        #region Overrides

        /// <inheritdoc/>
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return R;
            yield return G;
            yield return B;
            yield return A;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            if (A == 255)
                return $"#{R:x2}{G:x2}{B:x2}";
            else
                return $"#{A:x2}{R:x2}{G:x2}{B:x2}";
        }

        #endregion
    }
}
