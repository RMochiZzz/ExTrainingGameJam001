using UnityEngine;

namespace Core.Control.WaveManager
{
    public class WaveBoss : MonoBehaviour
    {
        public static float offsetY = 0.7f;
        public static float offsetX = 0.1f;
        private static float spawnX;
        private static float spawn;
        private static float cameraHeight;
        private static float cameraWidth;
        private static float spawnxBase;
        private static int i = 1;

        public static void SpawnEnemy(GameObject enemyPrefab, int enemyCount)
        {
            cameraHeight = 2f * Camera.main.orthographicSize;
            cameraWidth = cameraHeight * Camera.main.aspect;

            spawnxBase = cameraWidth / -2;

            if (enemyCount <= 5 || enemyCount >= 10)
            {
                RowOneThree(enemyPrefab);
            }
            else 
            {
                RowTwo(enemyPrefab);
            }

            if (enemyCount == 5) i = 1;
            if (enemyCount == 9) i = 1;
            if (enemyCount == 14) i = 1;

        }

        public static void RowOneThree(GameObject enemyPrefab)
        {
            float e = cameraWidth / 6;

            spawnX = spawnxBase + e * i;
            Vector3 spawnPosition = new Vector3(spawnX, cameraHeight * offsetY, 0f);
            Instantiate(enemyPrefab, spawnPosition, Quaternion.Euler(0f, 0f, 180f));

            i++;

        }
        public static void RowTwo(GameObject enemyPrefab)
        {
            float e = cameraWidth / 5;

            spawn = spawnxBase + e * i;
            Vector3 spawnPosition = new Vector3(spawn, cameraHeight * offsetY, 0f);
            Instantiate(enemyPrefab, spawnPosition, Quaternion.Euler(0f, 0f, 180f));

            i++;
        }
    }
}
