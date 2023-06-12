using UnityEngine;

namespace Core.Control.WaveControl
{
    public class ItemInstance : MonoBehaviour
    {
        
        private float offsetYItem = 1f;

        public void SpawnManager(GameObject ItemPrefab)
        {
            offsetYItem = 50f;
            SpawnItem(ItemPrefab);

            offsetYItem = 100f;
            SpawnItem(ItemPrefab);

            offsetYItem = 150f;
            SpawnItem(ItemPrefab);

            offsetYItem = 200f;
            SpawnItem(ItemPrefab);

            offsetYItem = 250f;
            SpawnItem(ItemPrefab);

        }

        public void SpawnItem(GameObject ItemPrefab)
        {
            Vector3 spawnPosition = new Vector3(0, offsetYItem, 0f);
            Instantiate(ItemPrefab, spawnPosition, Quaternion.Euler(0f, 0f, 180f));
        }
    }
}
