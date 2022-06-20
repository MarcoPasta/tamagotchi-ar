using System;
using DG.Tweening;
using Game.Feeding.Scripts;
using Modules.State;
using UnityEngine;
namespace Game.MiniGames.Scripts
{
    public class PlayerJump : MonoBehaviour
    {
        public Transform[] planeContainer;
        private Transform _singlePlanePos;
        public float jumpFloats = 0.0010f;
        public float jumpDuration = 0.4f;
        public float jumpForce = 0.001f;
        private float _maxJumpHeight;
        private float _minJumpHeight;
        private bool _canJump = true;
        public Animator playerAnimator;
        public float moveSpeed;
        public float jumpForward;
        private bool _gameStart;
        public static bool GameEnd = false;

        [SerializeField]
        private StateValues stateValues;
        
        private void Start()
        {
            _maxJumpHeight = transform.position.y + jumpFloats;
            _singlePlanePos = planeContainer[0];
            playerAnimator.Play("minigame_jump_1");
            _gameStart = true;
            GameEnd = false;
            ScoreCount.counter = 0;
        }

        void Update()
        {
            if (_singlePlanePos.position.y != MovingPlates.EndValue)
            {
                return;
            }
            CheckForGameEnd();
            CheckForInput();
        }

        private void CheckForInput()
        {
            if (Input.touchCount > 0 && _canJump)
            {
                transform.DOLocalJump(
                    new Vector3(0, _maxJumpHeight, 0),
                    jumpForce, 1, jumpDuration);
                playerAnimator.Play("minigame_jump_1");
                _canJump = false;
            }

            // for debugging
            if (Input.GetKeyDown(KeyCode.Space) && _canJump)
            {
                transform.DOLocalJump( // transform.position.x + 0.4f
                    new Vector3(0, _maxJumpHeight, 0),
                    jumpForce,
                    1,
                    jumpDuration);
                playerAnimator.Play("minigame_jump_1");
                _canJump = false;
            }
        }

        private void CheckForGameEnd()
        {
            if (transform.position.y < _singlePlanePos.position.y - 2.30f)
            {
                _canJump = false;
                GameEnd = true;

                double newHappinessValue = stateValues.happiness + (double) ScoreCount.counter / 1000;
                
                StateSerializer.SaveStateByName("Happiness", newHappinessValue);
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("plane") && !_gameStart)
            {
                playerAnimator.Play("walking");
                _canJump = true;
            }
            else
            {
                _canJump = true;
                _gameStart = true;
            }
        }

        private void OnCollisionStay(Collision collision)
        {
            if (collision.gameObject.CompareTag("plane") && _singlePlanePos.position.y == MovingPlates.EndValue)
            {
                playerAnimator.Play("walking");
                var playerTransform = transform;
                var position = playerTransform.position;
                
                position = new Vector3(
                    position.x - (moveSpeed * Time.deltaTime),
                    position.y, 
                    position.z);
                
                playerTransform.position = position;
            }
        }
    }
}
