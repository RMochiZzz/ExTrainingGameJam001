using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Combat.PlayerAttackMotion
{
    public class PlayerAttack : MonoBehaviour
    {
        [SerializeField] private GameObject attackObject;
        [SerializeField] private float AttackInterval;

        private float timer;

        // Start is called before the first frame update
        void Start()
        {
            timer = AttackInterval;
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
            GameObject g = Instantiate(attackObject);
            g.transform.SetParent(transform);
            g.transform.position = attackObject.transform.position;
            g.transform.rotation = attackObject.transform.rotation;
            g.SetActive(true);
        }
    }

}
