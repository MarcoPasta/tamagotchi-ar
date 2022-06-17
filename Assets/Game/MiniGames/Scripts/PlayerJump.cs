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

        private void Start()
        {
            _maxJumpHeight = transform.position.y + jumpFloats;
            _singlePlanePos = planeContainer[0];
        }

        void Update()
        {
            CheckForGameEnd();
            keepOnZ2();
            if (Input.touchCount > 0 && _canJump)
            {
                transform.DOLocalJump(new Vector3(0, _maxJumpHeight, _singlePlanePos.position.z), jumpForce, 1, jumpDuration);
                _canJump = false;
            }

            // for debugging
            if (Input.GetKeyDown(KeyCode.Space) && _canJump)
            {
                transform.DOLocalJump(new Vector3(0, _maxJumpHeight, _singlePlanePos.position.z), jumpForce, 1, jumpDuration);
                _canJump = false;
            }
        }

        private void keepOnZ2()
        {
            var transform1 = transform;
            var position = transform1.position;
            position = new Vector3(position.x, position.y, 2);
            transform1.position = position;
        }

        private void CheckForGameEnd()
        {
            if (transform.position.y < _singlePlanePos.position.y)
            {
                _canJump = false;
                ScoreCount.counter = 0;

                // TODO: check for character to hit a plane then load mainscene again
                // TODO: Confirm Endgame and increase happiness for the amount of meters the gotchis has ran
            }
        }
    }
}
