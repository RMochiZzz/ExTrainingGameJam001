using Core.Enemy;
using UnityEngine;
using DeadVideo;


namespace Core.Character.Enemy
{
    public class EnemyDestroy : MonoBehaviour
    {
        public float offset = 0.1f;
        private int hitCounter = 0;

        [SerializeField] private AudioClip DeadSE;
        private AudioSource audioSource;
        [SerializeField] private float DeadseVolum;

        private Explosion explosion;
        public bool doDead;

        private void Start()
        {
            audioSource = GetComponent<AudioSource>();
            explosion = GetComponent<Explosion>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (doDead) return;
            if (!collision.gameObject.CompareTag("PlayerBullet")) return;
            hitCounter++;

            if (hitCounter < EnemyAttribute.eraseValue) return;
            doDead = true;
            gameObject.tag = "Untagged";
            GManager.instance.score += 10;
            PlayDeadSE(DeadseVolum);
            explosion.PlayExplosion(transform.position);
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

            if (viewPosition.y <= -2f) return true;
            if (viewPosition.x >= 2f) return true;
            if (viewPosition.x <= -2f) return true;
            return false;
        }

        private void PlayDeadSE(float volumeScale)
        {
            audioSource.PlayOneShot(DeadSE, volumeScale);
        }

    }
}
