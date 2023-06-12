using UnityEngine;

public class ObstacleDestroy : MonoBehaviour
{

    private void Update()
    {
        if (!IsInCameraView()) return;
        Destroy(gameObject);
    }

    private bool IsInCameraView()
    {
        Vector3 viewPosition = Camera.main.WorldToViewportPoint(transform.position);
        if (viewPosition.y <= -2f) return true;
        if (viewPosition.x >= 2f) return true;
        if (viewPosition.x <= -2f) return true;

        return false;
    }

}
