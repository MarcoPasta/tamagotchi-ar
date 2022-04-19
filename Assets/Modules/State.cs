namespace Modules
{
    public class State : IState
    {
        public int Value { get; set; }
        
        public State(int value)
        {
            Value = Helpers.Clamp(value, 0, 100);
        }
        
        public void Increase()
        {
            
        }

        public void Decrease()
        {
            
        }
    }
}