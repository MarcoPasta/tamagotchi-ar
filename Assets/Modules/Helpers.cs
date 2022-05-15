namespace Modules
{
    /// <summary>
    /// A static class supplying various helper functions.
    /// </summary>
    public static class Helpers
    {
        /// <summary>
        /// This method is used to clamp a given value, so it fits into the given range.
        /// </summary>
        /// <param name="value">The value that should be clamped.</param>
        /// <param name="min">The lower boundary.</param>
        /// <param name="max">The upper boundary.</param>
        /// <returns></returns>
        public static double Clamp(double value, double min, double max)
        {
            if (value.CompareTo(min) < 0) {
                return min;
            }

            if (value.CompareTo(max) > 0) {
                return max;
            }
            
            return value;
        }
    }
}