using UnityEngine;

namespace Core.Weapon
{
    public class BulletMove : MonoBehaviour
    {
        void FixedUpdate()
        {

            Vector2 forwardDirection = -transform.up;

            Vector2 move = forwardDirection * BulletAttribute.bulletSpeed * Time.deltaTime;

            transform.position += new Vector3(move.x, move.y, 0f);

        }
    }
}
