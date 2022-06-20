using System;
using System.Collections.Generic;
using DG.Tweening;
using Modules.State;
using Modules.Timestamp;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Game.Feeding.Scripts
{
    public class StateController : MonoBehaviour
    {
        public Animator playerAnimator;
        private List<IState> _states;
        private int _minutesPassedSinceLastPlayed;
        private const double DecreasePerTick = 0.000001;

        [SerializeField] private StateValues stateValues;

        readonly IState _hungerState = new NonDependentState("Hunger", 1.0, 0, 1.0);
        readonly IState _happinessState = new NonDependentState("Happiness", 1.0, 0, 1.0);
        private IState _healthState;

        public GameObject[] foodAssets; 
        
        // Start is called before the first frame update
        void Start()
        {
            List<IStateDependency> healthStateDependencies = new List<IStateDependency>
            {
                new StateDependency(_hungerState, 0.5),
                new StateDependency(_happinessState, 0.5)
            };
        
            _healthState = new State("Health",1.0, 0, 1.0, healthStateDependencies);

            _states = new List<IState> { _hungerState, _happinessState, _healthState };

            foreach (var state in _states)
            {
                state.Value = StateSerializer.Load(state);
            }
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
                state.UpdateStateValue(DecreasePerTick);
            }

            stateValues.happiness = _happinessState.Value;
            stateValues.hunger = _hungerState.Value;
            stateValues.health = _healthState.Value;

            if (_hungerState.Value < 0.5)
            {
                playerAnimator.Play("hungry");
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

        private void OnDestroy()
        {
            HandleGameQuit();
        }

        private void HandleGameQuit()
        {
            Timestamp.Save();
            
            foreach (var state in _states)
            {
                StateSerializer.Save(state);
            }
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
                state.Value = CalculateStateValueDecrease(_minutesPassedSinceLastPlayed, state.Value);
            }
        }

        private static double CalculateStateValueDecrease(int minutes, double stateValue)
        {
            double valueToDecreaseBy = minutes * 60 * 60 * DecreasePerTick;
            return stateValue - valueToDecreaseBy;
        }

        public void FeedTamagotchi()
        {
            playerAnimator.Play("eating");
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
