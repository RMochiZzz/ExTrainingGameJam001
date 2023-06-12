using UnityEngine;

public class BulletDestroy : MonoBehaviour
{
    public float offset = 0.1f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Player"))return;
        Destroy(gameObject);
    }

    private void Update()
    {
        if (!IsInCameraView()) return;
        Destroy(gameObject);
    }

    private bool IsInCameraView()
    {
        Vector3 viewPosition = Camera.main.WorldToViewportPoint(transform.position);

        if (viewPosition.y >= 1.1) return true;
        if (viewPosition.y <= -2f) return true;
        if (viewPosition.x >= 2f) return true;
        if (viewPosition.x <= -2f) return true;

        return false;
    }

}
