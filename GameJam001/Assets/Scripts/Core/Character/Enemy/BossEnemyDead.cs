using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BossEnemy
{
    public class BossEnemyDead : MonoBehaviour
    {
        public float fadeDuration;
        public float shakeMagnitude;
        public float shakeSpeed;

        [SerializeField] private AudioClip DeadSE;
        private AudioSource audioSource;
        [SerializeField] private float DeadseVolum;
        private bool Deadseplay;


        private SpriteRenderer spriteRenderer;
        private float timer;
        private Vector3 startPosition;

        private BossEnemyStatus bossEnemyStatus;

        private void Start()
        {
            bossEnemyStatus = GetComponent<BossEnemyStatus>();
            spriteRenderer = GetComponent<SpriteRenderer>();
            audioSource = GetComponent<AudioSource>();
            startPosition = new Vector3(0f, 2f, 0f);
            Deadseplay = false;
        }

        public void Update()
        {
            if (!bossEnemyStatus.bossDead) return;
            if (!Deadseplay)
            {
                PlayDeadSE(DeadseVolum);
                RemoveBullets();
            }
            DeadFadeOut();
        }

        public void DeadFadeOut()
        {
            timer += Time.deltaTime;

            float alpha = 1f - Mathf.Clamp01(timer / fadeDuration);

            float shakeOffsetX = Mathf.Sin(timer * shakeSpeed) * shakeMagnitude;
            float shakeOffsetY = Mathf.Cos(timer * shakeSpeed) * shakeMagnitude;
            Vector3 shakeOffset = new Vector3(shakeOffsetX, shakeOffsetY, 0f);

            transform.position = startPosition + shakeOffset;
            spriteRenderer.color = new Color(1f, 1f, 1f, alpha);

            if (alpha <= 0f)
            {
                GManager.instance.isGameClear = true;
                Destroy(gameObject);
            }
        }

        private void PlayDeadSE(float volumeScale)
        {
            audioSource.PlayOneShot(DeadSE, volumeScale);
            Deadseplay = true;
        }

        private void RemoveBullets()
        {
            GameObject[] bullets = GameObject.FindGameObjectsWithTag("EnemyBullet");
            foreach (GameObject bullet in bullets)
            {
                Destroy(bullet);
            }
        }
    }
}