using System.Collections.Generic;
using DG.Tweening;
using Modules.State;
using Modules.Timestamp;
using UnityEngine;

namespace Game.MainScene.Scripts
{
    public class StateController : MonoBehaviour
    {
        private List<IState> _states;
        private int _minutesPassedSinceLastPlayed;
        private const double DecreasePerTick = 0.000001;

        readonly IState _hungerState = new State(1.0, 0, 1.0);
        readonly IState _happinessState = new State(1.0, 0, 1.0);

        public GameObject[] foodAssets; 
        
        // Start is called before the first frame update
        void Start()
        {
            List<IStateDependency> healthStateDependencies = new List<IStateDependency>
            {
                new StateDependency(_hungerState, 0.5), 
                new StateDependency(_happinessState, 0.5)
            };
        
            IState healthState = new State(1.0, 0, 1.0, healthStateDependencies);

            _states = new List<IState> { _hungerState, _happinessState, healthState };
        }

        // Update is called once per frame
        void Update()
        {
            if (_states == null)
            {
                return;
            }
        
            foreach (var state in _states)
            {
                state.UpdateStateValue();
            }
        }
    
        private void OnApplicationFocus(bool hasFocus)
        {
            if (hasFocus)
            {
                HandleGameReturn();
                return;
            }
        
            HandleGameQuit();
        }

        private static void HandleGameQuit()
        {
            Timestamp.Save();
        }

        private void HandleGameReturn()
        {
            _minutesPassedSinceLastPlayed = Timestamp.GetDifferenceInMinutes();

            if (_states == null)
            {
                return;
            }
        
            foreach (var state in _states)
            {
                state.Value -= CalculateStateValueDecrease(_minutesPassedSinceLastPlayed);
            }
        }

        private static double CalculateStateValueDecrease(int minutes)
        {
            return minutes * 60 * 60 * DecreasePerTick;
        }

        public void FeedTamagotchi()
        {
            _hungerState.Value += 0.1;
            Debug.Log("Tamagotchi fed.");

            int index = Random.Range(0, foodAssets.Length);
            GameObject foodAsset = foodAssets[index];

            foodAsset = Instantiate(foodAsset, foodAsset.transform.position, foodAsset.transform.rotation);
            Vector3 cameraForward = Camera.main!.transform.forward;

            Sequence foodAnimation = foodAsset.transform.DOJump(
                cameraForward, 
                0.08f, 
                Random.Range(1, 3), 
                Random.Range(0.5f, 0.7f));

            foodAnimation.OnComplete(() => {
                Destroy(foodAsset);
            });
        }
    }
}
