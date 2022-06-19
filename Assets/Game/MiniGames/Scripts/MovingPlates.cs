using DG.Tweening;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

namespace Game.MiniGames.Scripts
{
    public class MovingPlates : MonoBehaviour
    {
        public GameObject[] groundPlanes;
        public float spawnSpeed = 1.0f;
        public float moveSpeed = 0.25f;
        public static float endValue;
        public float leftEnd = -0.5f;
        public float randomRightEndStart = -0.9f;
        public float randomRightEnd = -0.11f;
        private float _counterHelper = 0;
        private void Start()
        {
            getEndValues();
            SpawnPlates();
        }

        private void getEndValues()
        {
            endValue = groundPlanes[0].transform.position.y + 1f;
        }

        private void Update()
        {
            if (groundPlanes[0].transform.position.y != endValue) return;
            MovePlates();
            CheckPosition();
            IncreaseScoreInMeters();
            moveSpeed += 0.000001f;
            
        }

        private void IncreaseScoreInMeters()
        {
            _counterHelper += 1 * Time.deltaTime;
            ScoreCount.counter = (int)_counterHelper;
        }
        
        private void CheckPosition()
        {
            foreach (var plane in groundPlanes)
            {
                if (plane.transform.position.x < leftEnd)
                {
                    plane.transform.position = GetRandomPosition();
                }
            }
        }
        // return a random position to spawn plate at 
        private Vector3 GetRandomPosition()
        {
            var pos = groundPlanes[0].transform.position;
            return new Vector3(Random.Range(randomRightEndStart, randomRightEnd), endValue, pos.z);
        }

        private void MovePlates()
        {
            foreach (var plane in groundPlanes)
            {
                plane.transform.Translate(Vector3.left * (moveSpeed * Time.deltaTime));
            }
        }

        private void SpawnPlates()
        {
            foreach (var plane in groundPlanes)
            {
                var pos = plane.transform.position;
                plane.transform.DOMove(new Vector3(pos.x, endValue, pos.z), spawnSpeed);
            }
        }
    }
}
