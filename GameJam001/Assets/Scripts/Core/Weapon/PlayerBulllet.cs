using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Combat.PlayerBulletMotion
{
    public class PlayerBulllet : MonoBehaviour
    {
        [SerializeField] private float Bulletspeed;
        [SerializeField] private float maxDistance;
        public float offset = 0.1f;

        private Rigidbody2D rb;

        // Start is called before the first frame update
        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        // Update is called once per frame
        void Update()
        {
            rb.MovePosition(transform.position += transform.up * Time.deltaTime * Bulletspeed);
            if (!IsInCameraView()) return;
            Destroy(gameObject);

        }

        private bool IsInCameraView()
        {
            Vector3 viewPosition = Camera.main.WorldToViewportPoint(transform.position);

            if (viewPosition.x <= 0 - offset) return true;
            if (viewPosition.x >= 1 + offset) return true;
            if (viewPosition.y <= 0 - offset) return true;
            if (viewPosition.y >= 1 + offset) return true;
            return false;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                Destroy(this.gameObject);
            }
        }
    }
}