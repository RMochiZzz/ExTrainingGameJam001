using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerMoveSystem
{
    public class PlayerMove : MonoBehaviour
    {
        private SpriteRenderer spriteRenderer;
        public Sprite playerDefaultSprite;
        public Sprite playerLeftSprite;
        public Sprite playerRightSprite;

        [SerializeField] private float speed = 5.0f;

        // Start is called before the first frame update
        void Start()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }

        // Update is called once per frame
        public void MoveStance(float moveX, float moveY)
        {
            if (GManager.instance.isGameClear) return;

            Vector2 movement = new Vector2(moveX, moveY);
            movement.Normalize();
            Vector3 newPosition = transform.position + new Vector3(movement.x, movement.y, 0f) * speed * Time.deltaTime;

            if (moveX > 0)
            {
                spriteRenderer.sprite = playerRightSprite;
            }
            else if (moveX < 0)
            {
                spriteRenderer.sprite = playerLeftSprite;
            }
            else
            {
                spriteRenderer.sprite = playerDefaultSprite;
            }

            Vector4 screenBounds = GetScreenBounds();
            newPosition.x = Mathf.Clamp(newPosition.x, screenBounds.x, screenBounds.y);
            newPosition.y = Mathf.Clamp(newPosition.y, screenBounds.z, screenBounds.w);

            transform.position = newPosition;
        }

        private Vector4 GetScreenBounds()
        {
            float screenAspect = (float)Screen.width / (float)Screen.height;
            float cameraHeight = Camera.main.orthographicSize;
            float cameraWidth = cameraHeight * screenAspect;

            float minX = -cameraWidth + transform.localScale.x / 2f;
            float maxX = cameraWidth - transform.localScale.x / 2f;
            float minY = -cameraHeight + transform.localScale.y / 2f;
            float maxY = cameraHeight - transform.localScale.y / 2f;

            return new Vector4(minX, maxX, minY,maxY);
        }
    }

}
