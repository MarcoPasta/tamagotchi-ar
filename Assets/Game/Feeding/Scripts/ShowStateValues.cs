using TMPro;
using UnityEngine;

namespace Game.Feeding.Scripts
{
    public class ShowStateValues : MonoBehaviour
    {
        [SerializeField]
        private StateValues stateValues;
        private TextMeshProUGUI _textMesh;
        
        private void Start()
        {
            _textMesh = GetComponent<TextMeshProUGUI>();
        }

        // Update is called once per frame
        void Update()
        {
            string stateDisplayText = $"Health: {stateValues.health}\nHunger: {stateValues.hunger}\nHappiness: {stateValues.happiness}";
            _textMesh.text = stateDisplayText;
        }
    }
}
