using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerStatusList
{
    public class PlayerStatus : MonoBehaviour
    {
        private int maxHP = 3;
        [HideInInspector] public int currentHP;
        [HideInInspector] public int Level;

        private void Start()
        {
            currentHP = maxHP;
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
