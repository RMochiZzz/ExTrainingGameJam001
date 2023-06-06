using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Combat.PlayerAttackMotion
{
    public class PlayerAttack : MonoBehaviour
    {
        public GameObject PlayerBulletPrefab;
        [SerializeField] private float AttackInterval;

        private float timer = 0.0f;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if(timer > AttackInterval)
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
            GameObject bullet = Instantiate(PlayerBulletPrefab, transform.position, transform.rotation);
        }
    }

}
