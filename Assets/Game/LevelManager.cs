using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/LevelLoadingOrder", order = 1)]
    public class LevelManager : ScriptableObject
    { 
        public List<GameObject> levelLoadingOrder = new List<GameObject>();
    }
}
