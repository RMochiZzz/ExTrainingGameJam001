using UnityEngine;

namespace Core.Control.WaveControl
{
    public class WaveOne : MonoBehaviour
    {
        public float offsetY = 0.7f;
        public float offsetX = 0.1f;
        private float cameraHeight;
        private float cameraWidth;
        private float spawnxBase;
        private int counter;

        public void SpawnEnemy(GameObject enemyPrefab)
        {
            cameraHeight = 2f * Camera.main.orthographicSize;
            cameraWidth = cameraHeight * Camera.main.aspect;

            spawnxBase = cameraWidth / -2;         

            for (int i = 0; WaveAttribute.WaveOneNum > i; i++)
            {
                if (i == 0)
                {
                    counter = 1;
                    offsetY = 0.7f;
                }
                else if (i == 5 || i == 9)
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

        public void RowOneThree(GameObject enemyPrefab)
        {
            float e = cameraWidth / 6;

            float spawnX = spawnxBase + e * counter;

            Vector3 spawnPosition = new Vector3(spawnX, cameraHeight * offsetY, 0f);
            GameObject obj = Instantiate(enemyPrefab, spawnPosition, Quaternion.Euler(0f, 0f, 180f));
            obj.AddComponent<WaveOneMoverOneThree>();

            counter += 1;
        }

        public void RowTwo(GameObject enemyPrefab)
        {
            float e = cameraWidth / 5;

            float spawn = spawnxBase + e * counter;

            Vector3 spawnPosition = new Vector3(spawn, cameraHeight * offsetY, 0f);
            GameObject obj = Instantiate(enemyPrefab, spawnPosition, Quaternion.Euler(0f, 0f, 180f));
            obj.AddComponent<WaveOneMoverTwo>();

            counter += 1;
        }
    }
}
