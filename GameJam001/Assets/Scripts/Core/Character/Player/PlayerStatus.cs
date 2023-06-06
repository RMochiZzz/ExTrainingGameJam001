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
                Debug.Log("�c��HP: " + currentHP);

                if (currentHP <= 0)
                {
                    // HP��0�ȉ��ɂȂ����ꍇ�̏����i�Q�[���I�[�o�[�Ȃǁj
                    // �����ɓK�؂ȏ������L�q����
                    Debug.Log("���S");
                }
            }

            if (collision.gameObject.CompareTag("LevelUpItem"))
            {
                Level += 1;
                Debug.Log("���݃��x��: " + Level);
            }
        }
    }
}
