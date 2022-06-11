using System;
using DG.Tweening;
using UnityEngine;

namespace Game.MiniGames.Scripts
{
    public class PlayerJump : MonoBehaviour
    {
        public Transform plane;
        private float _maxJumpHeight;
        private float _minJumpHeight;
        private bool _touchedLastFrame = false;


        private void Start()
        {
            _maxJumpHeight = transform.position.y + 0.015f;
        }

        void Update()
        {
            
            if (_touchedLastFrame && Input.touchCount == 0)
            {
                _touchedLastFrame = false;
            }
            else if (!_touchedLastFrame && Input.touchCount > 0)
            {
                transform.DOJump(new Vector3(0, _maxJumpHeight, plane.position.z), 0.02f, 1, 0.23f);
                _touchedLastFrame = true;
            }

            if (Input.GetTouch(0).phase == TouchPhase.Stationary)
            { 
                transform.DOJump(new Vector3(0, _maxJumpHeight, plane.position.z), 0.02f, 1, 0.23f);
            }
            
        }
    }
}
