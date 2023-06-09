using System.Collections;
using UnityEngine;

namespace Core.Control.WaveManager
{
    public class WaveOne : MonoBehaviour
    {
        public static float offsetY = 0.7f;
        public static float offsetX = 0.1f;
        private static float cameraHeight;
        private static float cameraWidth;
        private static float spawnxBase;
        private static int counter = 1;

        public static void SpawnEnemy(GameObject enemyPrefab)
        {
            cameraHeight = 2f * Camera.main.orthographicSize;
            cameraWidth = cameraHeight * Camera.main.aspect;

            spawnxBase = cameraWidth / -2;

            for (int i = 0; WaveAttribute.WaveOneNum > i; i++)
            {
                if (i == 0 || i == 5 || i == 9)
                {
                    counter = 1;
                    offsetY += 0.15f;
                }

                if (i <= 4 || i >= 9)
                {
                    RowOneThree(enemyPrefab);
                }
                else
                {
                    RowTwo(enemyPrefab);
                }
            }
        }

        public static void RowOneThree(GameObject enemyPrefab)
        {
            float e = cameraWidth / 6;

            float spawnX = spawnxBase + e * counter;

            Vector3 spawnPosition = new Vector3(spawnX, cameraHeight * offsetY, 0f);
            Instantiate(enemyPrefab, spawnPosition, Quaternion.Euler(0f, 0f, 180f));

            counter += 1;
        }

        public static void RowTwo(GameObject enemyPrefab)
        {
            float e = cameraWidth / 5;

            float spawn = spawnxBase + e * counter;

            Vector3 spawnPosition = new Vector3(spawn, cameraHeight * offsetY, 0f);
            Instantiate(enemyPrefab, spawnPosition, Quaternion.Euler(0f, 0f, 180f));

            counter += 1;

        }
    }
}
