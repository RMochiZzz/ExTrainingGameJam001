using UnityEngine;
using System.Collections;

namespace Core.Control.WaveControl
{
    public class WaveManager : MonoBehaviour
    {
        public GameObject enemyPrefab;
        public GameObject obstaclePrefab;
        private int waveCounter = 1;
        private WaveOne waveOne;
        private WaveFour waveFour;

        void Start()
        {

            GameObject waveOneobj = new GameObject("WaveOne");
            waveOne = waveOneobj.AddComponent<WaveOne>();
            GameObject waveFourobj = new GameObject("WaveFour");
            waveFour = waveFourobj.AddComponent<WaveFour>();

            StartNextWave();
        }

        void StartNextWave()
        {
            StartCoroutine(SpawnWave());
        }

        private IEnumerator SpawnWave()
        {
            if (waveCounter == 1)
            {
                waveOne.SpawnEnemy(enemyPrefab);
                yield return new WaitForSeconds(20);
            }
            else if (waveCounter == 2)
            {
                waveFour.SpawnEnemy(enemyPrefab, obstaclePrefab);
                yield return new WaitForSeconds(60);
            }
            else if (waveCounter == 3)
            {
                waveOne.SpawnEnemy(enemyPrefab);
                yield return new WaitForSeconds(20);
            }
            else if (waveCounter == 4)
            {
                waveFour.SpawnEnemy(enemyPrefab, obstaclePrefab);
                yield return new WaitForSeconds(60);
            }
            else if (waveCounter == 5)
            {
                waveOne.SpawnEnemy(enemyPrefab);
                yield break;
            }

            waveCounter++;
            StartNextWave();
        }
    }
}
