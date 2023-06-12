using System.Collections;
using UnityEngine;

namespace Core.Control.WaveControl
{
    public class WaveFourEnemy : MonoBehaviour
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

        public void SpawnManager(GameObject enemyPrefab)
        {
            Reset();
            StartCoroutine(SpawnPosition(enemyPrefab));
        }

        private IEnumerator SpawnPosition(GameObject enemyPrefab)
        {
            Reset();
            yield return new WaitForSeconds(6);
            for (int i = 0; 10 > i; i++)
            {
                if (i == 5)
                {
                    offsetXSide = -1.3f;
                    offsetYSide -= 0.3f;
                }

                if (i <= 4)
                {
                    RowOne(enemyPrefab);

                    offsetXSide += 0.3f;
                }
                else if (i >= 5)
                {
                    RowTwo(enemyPrefab);
                    offsetXSide -= 0.3f;
                }
            }

            Reset();
            yield return new WaitForSeconds(16);
            for (int i = 0; 6 > i; i++)
            {
                offsetXTop = -0.6f;
                Rotation(enemyPrefab);

                yield return new WaitForSeconds(2);
            }

        }

        public void RowOne(GameObject enemyPrefab)
        {
            Vector3 spawnPosition = new Vector3(cameraWidth * offsetXSide, cameraHeight * offsetYSide, 0f);
            GameObject obj = Instantiate(enemyPrefab, spawnPosition, Quaternion.Euler(0f, 0f, rotation));
            obj.AddComponent<WaveFourMoverOne>();
        }

        public void RowTwo(GameObject enemyPrefab)
        {
            Vector3 spawnPosition = new Vector3(cameraWidth * offsetXSide, cameraHeight * offsetYSide, 0f);
            GameObject obj = Instantiate(enemyPrefab, spawnPosition, Quaternion.Euler(0f, 0f, rotation));
            obj.AddComponent<WaveFourMoverTwo>();
        }
        public void Rotation(GameObject enemyPrefab)
        {
            Vector3 spawnPosition = new Vector3(cameraWidth * offsetXTop, cameraHeight * offsetYTop, 0f);
            GameObject obj = Instantiate(enemyPrefab, spawnPosition, Quaternion.Euler(0f, 0f, rotation));
            obj.AddComponent<WaveFourMoverRotation>();
        }

        public void Reset()
        {
            offsetYTop = 1.3f;
            offsetYSide = 0.8f;
            offsetXTop = 0.6f;
            offsetXSide = 1.3f;
            rotation = 180f;
            counter = 0;
            cameraHeight = Camera.main.orthographicSize;
            cameraWidth = cameraHeight * Camera.main.aspect;
        }
    }
}
