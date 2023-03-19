namespace ProjectManagement.Core
{
    /// <summary>
    /// Base value object
    /// </summary>
    public abstract class ValueObject
    {
        /// <summary>
        /// Check for equality between the given <see cref="ValueObject"/>
        /// </summary>
        /// <param name="left">First <see cref="ValueObject"/> to check equality</param>
        /// <param name="right">Second <see cref="ValueObject"/> to compare to</param>
        /// <returns>True if both <see cref="ValueObject"/> are equal, false otherwise</returns>
        protected static bool EqualOperator(ValueObject left, ValueObject right)
        {
            if (ReferenceEquals(left, null) ^ ReferenceEquals(right, null))
            {
                return false;
            }
            return ReferenceEquals(left, right) || left.Equals(right);
        }

        /// <summary>
        /// Check for inequality between the given <see cref="ValueObject"/>
        /// </summary>
        /// <param name="left">The first <see cref="ValueObject"/> to check inequality for</param>
        /// <param name="right">The second <see cref="ValueObject"/> to compare to</param>
        /// <returns>True if both <see cref="ValueObject"/> are different</returns>
        protected static bool NotEqualOperator(ValueObject left, ValueObject right)
        {
            return !(EqualOperator(left, right));
        }

        /// <summary>
        /// Function to return equality components
        /// </summary>
        /// <returns></returns>
        protected abstract IEnumerable<object> GetEqualityComponents();

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != GetType())
            {
                return false;
            }

            var other = (ValueObject)obj;

            return this.GetEqualityComponents().SequenceEqual(other.GetEqualityComponents());
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return GetEqualityComponents()
                .Select(x => x != null ? x.GetHashCode() : 0)
                .Aggregate((x, y) => x ^ y);
        }

        public static bool operator ==(ValueObject one, ValueObject two)
        {
            return EqualOperator(one, two);
        }

        public static bool operator !=(ValueObject one, ValueObject two)
        {
            return NotEqualOperator(one, two);
        }
    }
}
