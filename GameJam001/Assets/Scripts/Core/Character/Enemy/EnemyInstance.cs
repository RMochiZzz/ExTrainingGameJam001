using UnityEngine;

namespace Core.Enemy
{
    public class EnemyInstance : MonoBehaviour
    {
        public GameObject prefab;
        public float offsetY = 0.7f;
        public float offsetX = 0.1f;
        public float lastInstanceTime;

        private void Start()
        {
            lastInstanceTime = Time.time;
        }

        private void Update()
        {
            if (!GManager.instance.isBossBattle) return;
            if (GManager.instance.isGameClear) return;
            if (GManager.instance.isGameOver) return;
            if (Time.time - lastInstanceTime <= EnemyAttribute.spawnInterbal) return;
            Vector3 cameraPosition = Camera.main.transform.position;
            float cameraHeight = 2f * Camera.main.orthographicSize;
            float cameraWidth = cameraHeight * Camera.main.aspect;

            float spawnX;
            spawnX = Random.Range(cameraPosition.x - cameraWidth / 2f + offsetX, cameraPosition.x + cameraWidth / 2f - offsetX);

            Vector3 spawnPosition = new Vector3(spawnX, cameraHeight * offsetY, 0f);

            Instantiate(prefab, spawnPosition, Quaternion.Euler(0f, 0f, 180f));


            lastInstanceTime = Time.time;
            EnemyAttribute.enemyInstanceCounter++;
        }
    }
}