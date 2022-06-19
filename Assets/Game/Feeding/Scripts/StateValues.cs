using UnityEngine;

namespace Game.Feeding.Scripts
{
    [CreateAssetMenu(menuName = "ScriptableObjects/StateValues")]
    public class StateValues : ScriptableObject
    {
        public double health;
        public double happiness;
        public double hunger;
    }
}
