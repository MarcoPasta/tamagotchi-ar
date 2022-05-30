using DG.Tweening;
using UnityEngine;

namespace Game.MiniGames.Scripts
{
    public class MovingPlates : MonoBehaviour
    {
        public GameObject[] groundPlanes;
        public float spawnSpeed = 2.0f;
        public float moveSpeed = 0.25f;
       // [SerializeField] private bool spawned = false;
        private void Start()
        {
            SpawnPlates();
        }

        private void Update()
        {
            if (groundPlanes[0].transform.position.y != 0) return;
            MovePlates();
            CheckPosition();
            // moveSpeed += 0.000001f;
        }

        private void CheckPosition()
        {
            foreach (var plane in groundPlanes)
            {
                if (plane.transform.position.x < -7.0f)
                {
                    plane.transform.position = GetRandomPosition();
                }
            }
        }
        // return a random position to spawn plate at 
        private Vector3 GetRandomPosition()
        {
            return new Vector3(Random.Range(7.0f, 8.0f), 0, 0);
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
                plane.transform.DOMove(new Vector3(plane.transform.position.x, 0, 0), spawnSpeed);
            }
        }
    }
}
