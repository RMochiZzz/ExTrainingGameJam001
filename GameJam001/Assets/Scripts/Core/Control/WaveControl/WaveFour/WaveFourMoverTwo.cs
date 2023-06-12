 using UnityEngine;

namespace Core.Control.WaveControl
{
    public class WaveFourMoverTwo : MonoBehaviour
    {

        private void Update()
        {

            Vector2 forwardDirection = -transform.right;

            Vector2 move = forwardDirection * WaveAttribute.moveSpeed * Time.deltaTime;

            transform.position += new Vector3(move.x, move.y, 0f);

        }
    }
}
