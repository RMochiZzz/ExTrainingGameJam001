using UnityEngine;

namespace Core.Item
{
    public class ItemDestroy : MonoBehaviour
    {

        public float offset = 0.1f;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (!collision.gameObject.CompareTag("Player")) return;
            Destroy(gameObject);
        }

        private void Update()
        {
            if (!IsInCameraView()) return;
            Destroy(gameObject);
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

