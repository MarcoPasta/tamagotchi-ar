namespace Modules
{
    public interface IState
    {
        int StateValue
        {
            get;
            set;
        }

        int IncreaseFactor
        {
            get;
            set;
        }

        int DecreaseFactor
        {
            get;
            set;
        }

        void Increase(int value);
        void Decrease(int value);
    }
}