namespace Modules
{
    public static class Helpers
    {
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