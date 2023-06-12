using UnityEngine;

namespace Core.Control.WaveControl
{
    public class WaveFourObstacle : MonoBehaviour
    {
        private float offsetYTop = 1f;
        private float offsetYObstacle = 1f;
        private float offsetXTop = 1f;
        private float offsetXObstacle = 0f;
        private float sign = 1f;
        private float cameraHeightHalf;
        private float cameraWidthHalf;
        private int counter;
        private float rotation;

        public void SpawnManager(GameObject obstaclePrefab)
        {
            Reset();
            SpawnPosition(obstaclePrefab);
            Reset();
        }

        public void SpawnPosition (GameObject obstaclePrefab)
        {
            offsetYObstacle = cameraHeightHalf * 0.6f;

            for (int i = 0; 18 > i; i++)
            {

                if (counter == 3)
                {
                    offsetXTop = 0.3f;
                    offsetYTop += 0.2f;
                    counter = 0;
                }

                if (i == 9)
                {
                    sign = -1;
                    offsetYTop = 1f;
                }

                SpawnObstacle(obstaclePrefab);
                offsetXTop += 0.2f;
                counter++;

            }

            Reset();
            offsetYObstacle = cameraHeightHalf * 2.8f;

            for (int i = 0; 8 > i; i++)
            {
                if (i == 3)
                {
                    offsetXTop -= 0.1f;
                }
                else if (i == 7)
                {
                    offsetXTop += 0.1f;
                }

                if (i == 4)
                {
                    Reset();
                    sign = -1;
                }

                if (i <= 3)
                {
                    SpawnObstacle(obstaclePrefab);
                    offsetXTop += 0.1f;
                    offsetYTop += 0.25f;
                }
                else if (i >= 4)
                {
                    SpawnObstacle(obstaclePrefab);
                    offsetXTop -= 0.1f;
                    offsetYTop += 0.25f;
                }


            }

            /*
            Reset();
            offsetYObstacle = cameraHeightHalf * 4.5f;
            offsetXTop = 0.25f;

            for (int i = 0; 16 > i; i++)
            {
                if (counter == 2)
                {
                    offsetXTop = 0.25f;
                    offsetYTop += 0.25f;
                    offsetXObstacle -= 0.5f;
                    counter = 0;
                }

                if (i == 8)
                {
                    sign = -1;
                    offsetYTop = 1f;
                }

                SpawnObstacle(obstaclePrefab);
                offsetXTop += 0.5f;
                counter++;
            }

            Reset();
            offsetYObstacle = cameraHeightHalf * 8f;

            offsetXTop = -0.9f;
            offsetYTop = 0.8f;
            for (int i = 0; i < 7; i++)
            {
                SpawnObstacle(obstaclePrefab);
                offsetXTop += 0.1f;
            }

            offsetXTop = -0.7f;
            offsetYTop = 0.2f;
            for (int i = 0; i < 2; i++)
            {
                SpawnObstacle(obstaclePrefab);
                offsetXTop += 0.1f;
            }

            offsetXTop = 0.3f;
            offsetYTop = 0.2f;
            for (int i = 0; i < 8; i++)
            {
                SpawnObstacle(obstaclePrefab);
                offsetXTop += 0.1f;
            }

            offsetXTop = -0.7f;
            offsetYTop = 0.0f;
            for (int i = 0; i < 2; i++)
            {
                SpawnObstacle(obstaclePrefab);
                offsetXTop += 0.1f;
            }

            offsetXTop = -0.5f;
            offsetYTop = -0.7f;
            for (int i = 0; i < 2; i++)
            {
                SpawnObstacle(obstaclePrefab);
                offsetXTop += 0.1f;
            }

            offsetXTop = -0.5f;
            offsetYTop = -0.9f;
            for (int i = 0; i < 2; i++)
            {
                SpawnObstacle(obstaclePrefab);
                offsetXTop += 0.1f;
            }
            */

        }

        public void SpawnObstacle(GameObject obstaclePrefab)
        {
            Vector3 spawnPosition = new Vector3(cameraWidthHalf * sign * offsetXTop + offsetXObstacle, cameraHeightHalf * offsetYTop + offsetYObstacle, 0f);
            GameObject obj = Instantiate(obstaclePrefab, spawnPosition, Quaternion.Euler(0f, 0f, 180f));
            obj.AddComponent<WaveFourMoverObstacle>();
        }

  

        public void Reset()
        {
            offsetYTop = 1f;
            offsetXTop = 0.3f;
            offsetXObstacle = 0f;
            sign = 1;
            rotation = 180f;
            counter = 0;
            cameraHeightHalf = Camera.main.orthographicSize;
            cameraWidthHalf = cameraHeightHalf * Camera.main.aspect;
        }
    }
}
