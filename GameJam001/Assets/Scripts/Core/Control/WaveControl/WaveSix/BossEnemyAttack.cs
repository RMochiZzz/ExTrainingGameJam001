using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BossEnemy;

namespace BossEnemy
{
    public class BossEnemyAttack : MonoBehaviour
    {
        public GameObject BulletPrefab;
        [SerializeField] private float AttackInterval;
        private BossEnemyStatus bossEnemyStatus;

        private float timer = 0.0f;

        // Start is called before the first frame update
        void Start()
        {
            bossEnemyStatus = GetComponent<BossEnemyStatus>();
            timer = 0.0f;
        }

        // Update is called once per frame
        void Update()
        {
            if (GManager.instance.isGameOver) return;
            if (bossEnemyStatus.Appearing) return;
            if (bossEnemyStatus.bossDead) return;

            if (timer > AttackInterval)
            {
                Attack();
                timer = 0.0f;
            }
            else
            {
                timer += Time.deltaTime;
            }
        }

        public void Attack()
        {
            /*switch (GManager.instance.LevelNum)
                        {
                            case 1:
                                fiveway();
                                break;

                            case 2:
                                Instantiate(BulletPrefab, transform.position + new Vector3(0.25f, 0f, 0f), transform.rotation);
                                Instantiate(BulletPrefab, transform.position + new Vector3(-0.25f, 0f, 0f), transform.rotation);
                                break;
                        }*/
            fiveway();
        }

        public void fiveway()
        {
            GameObject bullet = Instantiate(BulletPrefab, transform.position, transform.rotation);
            Instantiate(BulletPrefab, transform.position + new Vector3(0.5f, 0f, 0f), Quaternion.Euler(0f, 0f, 30f));
            Instantiate(BulletPrefab, transform.position + new Vector3(1f, 0f, 0f), Quaternion.Euler(0f, 0f, 60f));
            Instantiate(BulletPrefab, transform.position + new Vector3(-0.5f, 0f, 0f), Quaternion.Euler(0f, 0f, -30f));
            Instantiate(BulletPrefab, transform.position + new Vector3(-1f, 0f, 0f), Quaternion.Euler(0f, 0f, -60f));

        }
    }
}
