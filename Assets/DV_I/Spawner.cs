using UnityEngine;

namespace Simulacro
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] private Enemy enemyPrefab;
        [SerializeField] private Transform[] spawnPoints;

        private float spawnTime = 2f;
        private float timer;
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            timer = spawnTime;
        }

        // Update is called once per frame
        void Update()
        {
            UpdateSpawnTime();

            SpawnEnemies();

        }
        private void UpdateSpawnTime()
        {
            spawnTime -= 0.05f * Time.deltaTime;
            if (spawnTime < 0.5f)
            {
                spawnTime = 0.5f;
            }
        }
        private void SpawnEnemies()
        {
            timer -= Time.deltaTime;

            if (timer <= 0)
            {
                Instantiate(enemyPrefab, spawnPoints[Random.Range(0, spawnPoints.Length)].position, Quaternion.identity);
                timer = spawnTime;
            }
        }

        
    }
}

