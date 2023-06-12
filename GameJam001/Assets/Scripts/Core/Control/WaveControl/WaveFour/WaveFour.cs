using System.Collections;
using UnityEngine;

namespace Core.Control.WaveControl
{
    public class WaveFour : MonoBehaviour
    {
        private WaveFourObstacle waveFourObstacle;
        private WaveFourEnemy WaveFourEnemy;

        public void SpawnEnemy(GameObject enemyPrefab, GameObject obstaclePrefab)
        {
            GameObject waveFourObstacleobj = new GameObject("WaveFourObstacle");
            waveFourObstacle = waveFourObstacleobj.AddComponent<WaveFourObstacle>();
            waveFourObstacle.SpawnManager(obstaclePrefab);

            GameObject WaveFourEnemyobj = new GameObject("WaveFourEnemy");
            WaveFourEnemy = waveFourObstacleobj.AddComponent<WaveFourEnemy>();
            WaveFourEnemy.SpawnManager(enemyPrefab);


            StartCoroutine(WaitCoroutine(enemyPrefab));
        }

        private IEnumerator WaitCoroutine(GameObject enemyPrefab)
        {
            yield return new WaitForSeconds(6);
        }
    }
}
