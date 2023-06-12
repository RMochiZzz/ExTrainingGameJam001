using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BossEnemy;

namespace BossEnemy
{
    public class BossEnemyTakenDamage : MonoBehaviour
    {
        private BossEnemyStatus bossEnemyStatus;

        // Start is called before the first frame update
        void Start()
        {
            bossEnemyStatus = GetComponent<BossEnemyStatus>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (bossEnemyStatus.Appearing) return;
            if (bossEnemyStatus.bossDead) return;

            if (collision.gameObject.CompareTag("PlayerBullet"))
            {
                --bossEnemyStatus.HP;
            }
        }


    }
}
