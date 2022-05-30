using DG.Tweening;
using UnityEditor;
using UnityEngine;

namespace Game.MiniGames.Scripts
{
    public class MovingPlates : MonoBehaviour
    {
        public GameObject[] groundPlanes;
        public float spawnSpeed = 2.0f;
        public float moveSpeed = 0.15f;
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
            foreach (var t in groundPlanes)
            {
                if (t.transform.position.x < -7.0f)
                {
                    t.transform.position = RandomPosition();
                }
            }
        }
        // return a random position to spawn plate at 
        private Vector3 RandomPosition()
        {
            return new Vector3(Random.Range(7.0f, 8.0f), 0, 0);
        }

        private void MovePlates()
        {
            // use for smoother transisiton
            groundPlanes[0].transform.Translate(Vector3.left * (moveSpeed * Time.deltaTime));
            groundPlanes[1].transform.Translate(Vector3.left * (moveSpeed * Time.deltaTime));
            groundPlanes[2].transform.Translate(Vector3.left * (moveSpeed * Time.deltaTime));
            groundPlanes[3].transform.Translate(Vector3.left * (moveSpeed * Time.deltaTime));
            groundPlanes[4].transform.Translate(Vector3.left * (moveSpeed * Time.deltaTime));
            
            // this is somehow 10 times faster??
            // foreach (var gp in groundPlanes)
            // {
            //     gp.transform.Translate(Vector3.left * (moveSpeed + Time.deltaTime));
            // }
            
        }

        private void SpawnPlates()
        {
            foreach (var gp in groundPlanes)
            {
                gp.transform.DOMove(new Vector3(gp.transform.position.x, 0, 0), spawnSpeed);
            }
        }
    }
}
