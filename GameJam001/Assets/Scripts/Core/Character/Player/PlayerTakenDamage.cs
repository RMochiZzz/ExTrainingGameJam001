using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Combat.PlayerDamage
{
    public class PlayerTakenDamage : MonoBehaviour
    {
        private bool isInvincible = false;
        private int blinkCount = 0;

        [SerializeField] private Sprite DeadSprite;
        [SerializeField] private AudioClip playerHittedSE;
        [SerializeField] private AudioClip playerDeadSE;
        private AudioSource audioSource;
        [SerializeField] private float HitseVolum;
        [SerializeField] private float DeadseVolum;

        private SpriteRenderer spriteRenderer;

        private void Awake()
        {
        }

        // Start is called before the first frame update
        void Start()
        {
            audioSource = GetComponent<AudioSource>();
            spriteRenderer = GetComponent<SpriteRenderer>();
        }

        // Update is called once per frame
        private void Update()
        {

        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("EnemyBullet") || collision.gameObject.CompareTag("Enemy"))
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
                    ChangeSprite(DeadSprite);
                    PlayPlayerDeadSE(DeadseVolum);
                    StartInvincibleState();
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
