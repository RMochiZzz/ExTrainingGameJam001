using UnityEngine;
using System.Collections;

namespace Core.Control.WaveManager
{
    public class WaveManager : MonoBehaviour
    {
        private float time;
        public GameObject enemyPrefab;


        void Start()
        {
            time = 0f;
            StartNextWave();
        }

        void StartNextWave()
        {
            StartCoroutine(SpawnWave());
        }

        private IEnumerator SpawnWave()
        {
            if (Time.time - time >= 0)
            {
                WaveOne.SpawnEnemy(enemyPrefab);
            }
            else if (Time.time - time >= 40)
            {
                WaveOne.SpawnEnemy(enemyPrefab);
            }
            else if (Time.time - time >= 60)
            {
                WaveOne.SpawnEnemy(enemyPrefab);
            }
            else if (Time.time - time >= 80)
            {
                WaveOne.SpawnEnemy(enemyPrefab);
            }
            else if (Time.time - time >= 100)
            {
                WaveOne.SpawnEnemy(enemyPrefab);
            }
            else if (Time.time - time >= 120)
            {
                WaveOne.SpawnEnemy(enemyPrefab);
                yield break;
            }

            yield return new WaitForSeconds(WaveAttribute.spawnInterval);
            StartNextWave();
        }
    }
}
