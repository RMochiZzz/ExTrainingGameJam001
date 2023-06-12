using UnityEngine;

namespace Core.Control.WaveControl
{
    public class WaveBoss : MonoBehaviour
    {
        public void SpawnBoss(GameObject bossPrefab)
        {
            Vector3 spawnPosition = new Vector3(0f, 6f, 0f);
            Instantiate(bossPrefab, spawnPosition, Quaternion.Euler(0f, 0f, 0f));
        }
    }
}
