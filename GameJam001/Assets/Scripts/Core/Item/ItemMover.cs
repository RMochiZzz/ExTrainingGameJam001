using UnityEngine;

namespace Core.Item
{
    public class ItemMover : MonoBehaviour
    {

        public float moveSpeed = 1f;

        private void Update()
        {
            Vector2 direction = -transform.up;

            Vector2 move = direction * moveSpeed * Time.deltaTime;

            transform.position += new Vector3(move.x, move.y, 0f);
        }
    }
}
