using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Combat.PlayerAttackMotion
{
    public class PlayerBulllet : MonoBehaviour
    {
        [SerializeField] private float Bulletspeed;
        [SerializeField] private float maxDistance;

        private Rigidbody2D rb;
        private Vector3 defaultPos;

        // Start is called before the first frame update
        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            defaultPos = transform.position;
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            float d = Vector3.Distance(transform.position, defaultPos);

            //最大移動距離を超えている
            if (d > maxDistance)
            {
                Destroy(this.gameObject);
            }
            else
            {
                rb.MovePosition(transform.position += transform.up * Time.deltaTime * Bulletspeed);
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("EnemyTag"))
            {
                Destroy(this.gameObject);
                // ここに追加の処理を記述する
            }
        }
    }
}
