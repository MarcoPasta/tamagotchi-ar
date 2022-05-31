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
        private void Start()
        {
            getEndValues();
            SpawnPlates();
        }

        private void getEndValues()
        {
            _endValue = groundPlanes[0].transform.position.y + 0.6f;
        }

        private void Update()
        {
            // TODO: get a method to check without position 0
            if (groundPlanes[0].transform.position.y != _endValue) return;
            MovePlates();
            CheckPosition();
            // moveSpeed += 0.000001f;
        }

        private void CheckPosition()
        {
            foreach (var plane in groundPlanes)
            {
                if (plane.transform.position.x < -0.5f)
                {
                    plane.transform.position = GetRandomPosition();
                }
            }
        }
        // return a random position to spawn plate at 
        private Vector3 GetRandomPosition()
        {
            return new Vector3(Random.Range(0.5f, 0.6f), _endValue, 1);
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
