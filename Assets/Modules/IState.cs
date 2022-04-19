namespace Modules
{
    public interface IState
    {
        int Value
        {
            get;
            set;
        }

        void Increase();
        void Decrease();
    }
}