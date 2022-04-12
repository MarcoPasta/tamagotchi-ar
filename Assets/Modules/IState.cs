namespace Modules
{
    public interface IState
    {
        int Value
        {
            get;
            set;
        }

        int Clamp(int value, int min, int max);
    }
}