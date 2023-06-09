using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BossEnemy
{
    public class BossEnemyMove : MonoBehaviour
    {
        [SerializeField] private float moveySpeed;
        [SerializeField] private float movexSpeed;
        [SerializeField] private float moveDistance; 
        [SerializeField] private float stopDuration;
        [SerializeField] private float initialYPosition; 

        private bool Appearing = true;
        private float stopTimer = 0f;
        private float initialXPosition;
        private float offsetX = 0f;

        private void Start()
        {
            initialXPosition = transform.position.x;
        }

        private void Update()
        {
            Appearance();
            if (Appearing) return;

            offsetX = Mathf.PingPong(Time.time * movexSpeed, moveDistance * 2) - moveDistance;
            float moveX = initialXPosition + offsetX;
            Vector3 newPosition = new Vector3(moveX, transform.position.y, transform.position.z);
            transform.position = Vector3.MoveTowards(transform.position, newPosition, movexSpeed * Time.deltaTime);
        }

        private void Appearance()
        {
            if (transform.position.y >= initialYPosition)
            {
                Vector2 move = -transform.up * moveySpeed * Time.deltaTime;
                transform.position += new Vector3(move.x, move.y, 0);
            }
            stopTimer += Time.deltaTime;

            if (stopTimer >= stopDuration) Appearing = false;
        }
    }
}
