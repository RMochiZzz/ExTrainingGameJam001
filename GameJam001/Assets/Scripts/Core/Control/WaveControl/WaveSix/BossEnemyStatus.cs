using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BossEnemy
{
    public class BossEnemyStatus : MonoBehaviour
    {
        public int defaultHP;
        public int HP;
        public bool bossDead;
        public bool Appearing;

        private void Start()
        {
            HP = defaultHP;
            bossDead = false;
            Appearing = true;
        }

        private void Update()
        {
            if (HP <= 0) bossDead = true;
        }
    }
}