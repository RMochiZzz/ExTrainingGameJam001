using System.Collections;
using UnityEngine;

namespace Core.Control.WaveControl
{
    public class WaveOneMoverTwo : MonoBehaviour
    {
        private float time;
        private void Start()
        {
            time = Time.time;
        }

        private void Update()
        {
            if (Time.time - time <= 3f)
            {
                Vector2 forwardDirection = transform.up;

                Vector2 move = forwardDirection * WaveAttribute.moveSpeed * Time.deltaTime;

                transform.position += new Vector3(move.x, move.y, 0f);
            }
            else if (Time.time - time >= 15)
            {
                Vector2 forwardDirection = transform.right;

                Vector2 move = forwardDirection * WaveAttribute.moveSpeed * Time.deltaTime;

                transform.position += new Vector3(move.x, move.y, 0f);
            }
        }

        private IEnumerator WaitTime()
        {
            yield return new WaitForSeconds(10);
        }
    }
}
