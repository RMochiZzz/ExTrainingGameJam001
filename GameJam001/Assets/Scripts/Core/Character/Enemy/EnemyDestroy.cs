using Core.Enemy;
using UnityEngine;

namespace Core.Character.Enemy
{
    public class EnemyDestroy : MonoBehaviour
    {
        public float offset = 0.1f;
        private int hitCounter = 0;

        [SerializeField] private AudioClip DeadSE;
        private AudioSource audioSource;
        [SerializeField] private float DeadseVolum;

        private void Start()
        {
            audioSource = GetComponent<AudioSource>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (!collision.gameObject.CompareTag("PlayerBullet")) return;
            hitCounter++;

            if (hitCounter < EnemyAttribute.eraseValue) return;
            PlayDeadSE(DeadseVolum);
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

            if (viewPosition.y <= 0 - offset) return true;
            return false;
        }

        private void PlayDeadSE(float volumeScale)
        {
            audioSource.PlayOneShot(DeadSE, volumeScale);
        }

    }
}
