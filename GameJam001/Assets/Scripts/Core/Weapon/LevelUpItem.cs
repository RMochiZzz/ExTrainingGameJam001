using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Combat.Item
{
    public class PowerUpItem : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                Destroy(this.gameObject);
            }
        }
    }
}

