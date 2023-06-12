using UnityEngine;
using System.Collections;

namespace Core.Control.WaveControl
{
    public class WaveManager : MonoBehaviour
    {
        public GameObject enemyPrefab;
        public GameObject obstaclePrefab;
        public GameObject bossPrefab;
        public GameObject ItemPrefab;
        private int waveCounter = 1;
        private WaveOne waveOne;
        private WaveFour waveFour;
        private WaveBoss waveBoss;
        private ItemInstance itemInstance;

        void Start()
        {
            GameObject waveOneobj = new GameObject("WaveOne");
            waveOne = waveOneobj.AddComponent<WaveOne>();
            GameObject waveFourobj = new GameObject("WaveFour");
            waveFour = waveFourobj.AddComponent<WaveFour>();
            GameObject waveBossobj = new GameObject("WaveBoss");
            waveBoss = waveBossobj.AddComponent<WaveBoss>();
            GameObject itemInstanceobj = new GameObject("ItemInstance");
            itemInstance = itemInstanceobj.AddComponent<ItemInstance>();

            itemInstance.SpawnManager(ItemPrefab);

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
                yield return new WaitForSeconds(50);
            }
            else if (waveCounter == 3)
            {
                waveOne.SpawnEnemy(enemyPrefab);
                yield return new WaitForSeconds(20);
            }
            else if (waveCounter == 4)
            {
                waveFour.SpawnEnemy(enemyPrefab, obstaclePrefab);
                yield return new WaitForSeconds(50);
            }
            else if (waveCounter == 5)
            {
                waveBoss.SpawnBoss(bossPrefab);
                yield break;
            }

            waveCounter++;
            StartNextWave();
        }
    }
}
