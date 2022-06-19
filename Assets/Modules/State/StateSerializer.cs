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
    }
}