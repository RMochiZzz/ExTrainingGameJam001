using System.Collections;
using UnityEngine;

namespace Core.Control.WaveControl
{
    public class WaveFour : MonoBehaviour
    {
        private float offsetYTop = 0f;
        private float offsetYSide = 0f;
        private float offsetXTop = 0f;
        private float offsetXSide = 0f;
        private float cameraHeight;
        private float cameraWidth;
        private int counter;
        private float rotation;
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
