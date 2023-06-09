using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DeadVideo;

namespace Combat.PlayerDamage
{
    public class PlayerTakenDamage : MonoBehaviour
    {
        private bool isInvincible = false;
        private int blinkCount = 0;

        [SerializeField] private AudioClip playerHittedSE;
        [SerializeField] private AudioClip playerDeadSE;
        private AudioSource audioSource;
        [SerializeField] private float HitseVolum;
        [SerializeField] private float DeadseVolum;

        private SpriteRenderer spriteRenderer;
        private Explosion explosion;
        private bool doDead;


        // Start is called before the first frame update
        void Start()
        {
            audioSource = GetComponent<AudioSource>();
            spriteRenderer = GetComponent<SpriteRenderer>();
            explosion = GetComponent<Explosion>();
            doDead = false;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (doDead) return;
            string tag = collision.gameObject.tag;
            if (tag == "EnemyBullet" || tag == "Enemy" || tag == "Obstacle")
            {
                if (isInvincible) return;

                GManager.instance.SubHeartNum();

                if(!GManager.instance.isGameOver)
                {
                    PlayPlayerHittedSE(HitseVolum);
                    StartInvincibleState();
                }
                else
                {
                    doDead = true;
                    PlayPlayerDeadSE(DeadseVolum);
                    explosion.PlayExplosion(transform.position);
                }
            }
        }
        
        private void OnTriggerStay2D(Collider2D collision)
        {
            if (doDead) return;
            string tag = collision.gameObject.tag;
            if (tag == "EnemyBullet" || tag == "Enemy" || tag == "Obstacle")
            {
                if (isInvincible) return;

                GManager.instance.SubHeartNum();

                if (!GManager.instance.isGameOver)
                {
                    PlayPlayerHittedSE(HitseVolum);
                    StartInvincibleState();
                }
                else
                {
                    doDead = true;
                    PlayPlayerDeadSE(DeadseVolum);
                    explosion.PlayExplosion(transform.position);
                }
            }
        }

        private void StartInvincibleState()
        {
            isInvincible = true;
            blinkCount = 0;
            StartCoroutine(InvincibleBlink());
        }

        private IEnumerator InvincibleBlink()
        {
            float blinkInterval = 0.3f;
            int totalBlinkCount = 6;

            while (blinkCount < totalBlinkCount)
            {
                GetComponent<Renderer>().enabled = !GetComponent<Renderer>().enabled;
                blinkCount++;

                yield return new WaitForSeconds(blinkInterval);
            }

            isInvincible = false;
            GetComponent<Renderer>().enabled = true;
            if (GManager.instance.isGameOver) Destroy(gameObject);
        }

        private void PlayPlayerHittedSE(float volumeScale)
        {
            audioSource.PlayOneShot(playerHittedSE, volumeScale);
        }

        private void PlayPlayerDeadSE(float volumeScale)
        {
            audioSource.PlayOneShot(playerDeadSE, volumeScale);
        }

        private void ChangeSprite(Sprite sprite)
        {
            spriteRenderer.sprite = sprite;
        }
    }
}
