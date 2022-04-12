namespace Modules
{
    public class State : IState
    {
        public int Value { get; set; }

        public int Clamp(int value, int min, int max)
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