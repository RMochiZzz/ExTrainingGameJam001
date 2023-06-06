using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerStatusList
{
    public class PlayerStatus : MonoBehaviour
    {
        private int maxHP = 3;
        private int currentHP;
        private int Level;

        private void Start()
        {
            currentHP = maxHP;
            Level = 1;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("EnemyBullet") || collision.gameObject.CompareTag("Enemy"))
            {
                currentHP -= 1;
                Debug.Log("残りHP: " + currentHP);

                if (currentHP <= 0)
                {
                    // HPが0以下になった場合の処理（ゲームオーバーなど）
                    // ここに適切な処理を記述する
                    Debug.Log("死亡");
                }
            }

            if (collision.gameObject.CompareTag("LevelUpItem"))
            {
                Level += 1;
                Debug.Log("現在レベル: " + Level);
            }
        }
    }
}
