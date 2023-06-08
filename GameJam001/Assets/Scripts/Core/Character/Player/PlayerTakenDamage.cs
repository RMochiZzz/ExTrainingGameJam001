using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using PlayerStatusList;

namespace Combat.PlayerDamage
{
    public class PlayerTakenDamage : MonoBehaviour
    {
        private bool isInvincible = false;
        private int blinkCount = 0;
        private bool isGameOver = false;

        public Sprite DeadSprite;
        public AudioClip playerHittedSE;
        public AudioClip playerDeadSE;
        private AudioSource audioSource;

        private SpriteRenderer spriteRenderer;
        private PlayerStatus playerStatus;

        private void Awake()
        {
            audioSource = GetComponent<AudioSource>();
            spriteRenderer = GetComponent<SpriteRenderer>();
        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        private void Update()
        {
/*            if (isGameOver && Input.GetKeyDown(KeyCode.Return))
            {
                SceneManager.LoadScene("MenuScene");
            }*/
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("EnemyBullet") || collision.gameObject.CompareTag("Enemy"))
            {
                if (isInvincible) return;

                GManager.instance.SubHeartNum();

                if(!GManager.instance.isGameOver)
                {
                    PlayPlayerHittedSE();
                    StartInvincibleState();
                }
                else
                {
                    isGameOver = true;
                    ChangeSprite(DeadSprite);
                    PlayPlayerDeadSE();
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
            if (isGameOver) Destroy(gameObject);
        }

        private void PlayPlayerHittedSE()
        {
            audioSource.PlayOneShot(playerHittedSE);
        }

        private void PlayPlayerDeadSE()
        {
            audioSource.PlayOneShot(playerDeadSE);
        }

        private void ChangeSprite(Sprite sprite)
        {
            spriteRenderer.sprite = sprite;
        }
    }
}
