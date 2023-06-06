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

            //ç≈ëÂà⁄ìÆãóó£Çí¥Ç¶ÇƒÇ¢ÇÈ
            if (d > maxDistance)
            {
                Destroy(this.gameObject);
            }
            else
            {
                rb.MovePosition(transform.position += transform.up * Time.deltaTime * Bulletspeed);
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                Destroy(this.gameObject);
                // Ç±Ç±Ç…í«â¡ÇÃèàóùÇãLèqÇ∑ÇÈ
            }
        }
    }
}
