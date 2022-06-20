using UnityEngine;

namespace Modules.State
{
    public static class StateSerializer
    {
        public static void Save(IState state)
        {
            PlayerPrefs.SetFloat(state.Name, (float)state.Value);
        }

        public static double Load(IState state)
        {
            return PlayerPrefs.GetFloat(state.Name, 1);
        }

        public static void SaveStateByName(string name, double value)
        {
            PlayerPrefs.SetFloat(name, (float)value);
        }

        public static double LoadStateByName(string name)
        {
            return PlayerPrefs.GetFloat(name, 1);
        }
    }
}