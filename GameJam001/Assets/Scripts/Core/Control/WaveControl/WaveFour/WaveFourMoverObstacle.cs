using System.Collections;
using UnityEngine;

namespace Core.Control.WaveControl
{
    public class WaveFourMoverObstacle : MonoBehaviour
    {
        private float time;
        private bool isMoving;

        private void Start()
        {
            time = Time.time;
            isMoving = true;
        }

        private void Update()
        {
            if (isMoving)
            {
                Move();
                if (Time.time - time >= 10f)
                {
                    StopMoving();
                }
            }
            else
            {
                if (Time.time - time >= 10f)
                {
                    ResumeMoving();
                }
            }
        }

        private void Move()
        {
            Vector2 forwardDirection = transform.up;
            Vector2 move = forwardDirection * WaveAttribute.obstacleMoveSpeed * Time.deltaTime;
            transform.position += new Vector3(move.x, move.y, 0f);
        }

        private void StopMoving()
        {
            isMoving = false;
            time = Time.time;
        }

        private void ResumeMoving()
        {
            isMoving = true;
            time = Time.time;
        }
    }
}
