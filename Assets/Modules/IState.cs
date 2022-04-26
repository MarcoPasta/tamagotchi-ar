namespace Modules
{
    public interface IState
    {
        double StateValue
        {
            get;
            set;
        }

        void Increase(double value, double factor = 1);
        void Decrease(double value, double factor = 1);
    }
}