using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerStatusList
{
    public class PlayerStatus : MonoBehaviour
    {
        [HideInInspector] public int Level;

        private void Start()
        {
            Level = 1;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("LevelUpItem"))
            {
                Level += 1;
                Debug.Log("åªç›ÉåÉxÉã: " + Level);
            }
        }
    }
}