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

        private PlayerStatus playerStatus;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        private void Update()
        {
            if (isGameOver && Input.GetKeyDown(KeyCode.Return))
            {
                SceneManager.LoadScene("MenuScene");
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("EnemyBullet") || collision.gameObject.CompareTag("Enemy"))
            {
                if (isInvincible) return;

                GManager.instance.SubHeartNum();

                if(GManager.instance.HeartNum <= 0)
                {
                    GameOver();
                }
                else
                {
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
        }

        private void GameOver()
        {
//           Destroy(gameObject); // プレイヤーオブジェクトを破棄
//           Time.timeScale = 0f; // ゲーム内の全ての処理を停止
            isGameOver = true;
            Debug.Log("ゲームオーバー");
        }
    }
}
