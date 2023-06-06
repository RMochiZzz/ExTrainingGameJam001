using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerStatusList
{
    public class PlayerStatus : MonoBehaviour
    {
        private int maxHP = 3;
        private int currentHP;
        private int Power;

        private void Start()
        {
            currentHP = maxHP;
            Power = 1;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("EnemyBulletTag") || collision.gameObject.CompareTag("EnemyTag"))
            {
                currentHP -= 1;
                Debug.Log("残りHP: " + currentHP);

                if (currentHP <= 0)
                {
                    // HPが0以下になった場合の処理（ゲームオーバーなど）
                    // ここに適切な処理を記述する

                }
            }
        }
    }
}
