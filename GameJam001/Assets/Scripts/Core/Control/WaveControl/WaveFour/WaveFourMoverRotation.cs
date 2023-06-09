using UnityEngine;

namespace Core.Control.WaveControl
{
    public class WaveFourMoverRotation : MonoBehaviour
    {
        private Vector2 forwardDirection;
        private float time;

        void Start () 
        {
            time = Time.time;
        }
        private void Update()
        {
            if (Time.time - time <= 4.5)
            {
                forwardDirection = transform.up;
                Mover();
            }
            else if (Time.time - time >= 4.6 && Time.time - time <= 10)
            {
                forwardDirection = -transform.right;
                Mover();
            }
            else if (Time.time - time >= 11.1 && Time.time - time <= 14)
            {
                forwardDirection = -transform.up;
                Mover();
            }
            else if (Time.time - time >= 14.1)
            {
                forwardDirection = transform.right;
                Mover();
            }

        }


        private void Mover()
        {
            Vector2 move = forwardDirection * WaveAttribute.moveSpeed * Time.deltaTime;
            transform.position += new Vector3(move.x, move.y, 0f);
        }
    }
}
