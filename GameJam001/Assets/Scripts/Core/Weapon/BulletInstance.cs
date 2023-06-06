using UnityEngine;

namespace Core.Weapon
{
    public class BulletInstantiateSystem : MonoBehaviour
    {
        public GameObject prefab;
        private float lastSpownTime = 0;
        private float offset = 0.01f;

        void Update()
        {

            if (IsInCameraView()) return;
            if (Time.time - lastSpownTime <= BulletAttribute.fireInterval) return;
            Vector3 spawnPointPosition = gameObject.transform.position ;
            Quaternion spawnPointRotation = gameObject.transform.rotation;

            Instantiate(prefab, spawnPointPosition, spawnPointRotation);

            lastSpownTime = Time.time;

        }


        private bool IsInCameraView()
        {
            Vector3 viewPosition = Camera.main.WorldToViewportPoint(transform.position);

            if (viewPosition.x <= 0 - offset) return true;
            if (viewPosition.x >= 1 + offset) return true;
            if (viewPosition.y <= 0 - offset) return true;
            if (viewPosition.y >= 1 + offset) return true;
            return false;

        }
    }
}