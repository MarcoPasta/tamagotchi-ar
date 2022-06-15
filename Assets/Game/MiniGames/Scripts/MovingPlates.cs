using DG.Tweening;
using UnityEngine;

namespace Game.MiniGames.Scripts
{
    public class MovingPlates : MonoBehaviour
    {
        public GameObject[] groundPlanes;
        public float spawnSpeed = 1.0f;
        public float moveSpeed = 0.25f;
        private float _endValue;
        public float leftEnd = -0.5f;
        public float randomRightEndStart = -0.9f;
        public float randomRightEnd = -0.11f;
        private void Start()
        {
            getEndValues();
            SpawnPlates();
        }

        private void getEndValues()
        {
            _endValue = groundPlanes[0].transform.position.y + 0.5f;
        }

        private void Update()
        {
            if (groundPlanes[0].transform.position.y != _endValue) return;
            MovePlates();
            CheckPosition();
            moveSpeed += 0.000001f;
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
            return new Vector3(Random.Range(randomRightEndStart, randomRightEnd), _endValue, pos.z);
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
                plane.transform.DOMove(new Vector3(pos.x, _endValue, pos.z), spawnSpeed);
            }
        }
    }
}
