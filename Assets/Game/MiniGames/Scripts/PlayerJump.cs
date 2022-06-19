using System;
using DG.Tweening;
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

        private void Start()
        {
            _maxJumpHeight = transform.position.y + jumpFloats;
            _singlePlanePos = planeContainer[0];
            playerAnimator.Play("minigame_jump_1");
            _gameStart = true;
        }

        void Update()
        {
            if (_singlePlanePos.position.y != MovingPlates.endValue)
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
                ScoreCount.counter = 0;
                // if (SpawnObjectOnPlane.spawnedObject == null)
                // {
                //     // Debug.Log("very fuck you");
                // }
                // var anchorYPos = SpawnObjectOnPlane.spawnedObject.transform.position.y;
                // if (transform.position.y >= anchorYPos)
                // {
                //     Debug.Log("GameOver!!!");
                // }

                // TODO: check for character to hit a plane then load mainscene again
                // TODO: Confirm Endgame and increase happiness for the amount of meters the gotchis has ran
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
            if (collision.gameObject.CompareTag("plane") && _singlePlanePos.position.y == MovingPlates.endValue)
            {
                playerAnimator.Play("walking");
                transform.position = new Vector3(transform.position.x - (moveSpeed * Time.deltaTime),
                    transform.position.y, transform.position.z);
            }
        }
    }
}
