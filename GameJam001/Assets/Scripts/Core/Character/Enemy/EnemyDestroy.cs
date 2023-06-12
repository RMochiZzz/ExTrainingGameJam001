using Core.Enemy;
using UnityEngine;

namespace Core.Character.Enemy
{
    public class EnemyDestroy : MonoBehaviour
    {
        private int hitCounter = 0;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (!collision.gameObject.CompareTag("PlayerBullet")) return;
            //if (!collision.gameObject.CompareTag("Obstacle")) return;

            hitCounter++;

            if (hitCounter < EnemyAttribute.eraseValue) return;
            Destroy(gameObject);
            EnemyAttribute.enemyInstanceCounter--;
        }

        private void Update()
        {
            if (!IsInCameraView()) return;
            Destroy(gameObject);
        }

        private bool IsInCameraView()
        {
            Vector3 viewPosition = Camera.main.WorldToViewportPoint(transform.position);

            if (viewPosition.y <= -2) return true;
            if (viewPosition.y >= 2) return true;
            if (viewPosition.x <= -2) return true;
            if (viewPosition.x >= 2) return true;

            return false;
        }
    }
}
