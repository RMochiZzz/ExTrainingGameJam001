using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockObj : MonoBehaviour
{
    public float offset = 0.1f;

    private void Update()
    {
        if (!IsInCameraView()) return;
        Destroy(gameObject);
    }

    private bool IsInCameraView()
    {
        Vector3 viewPosition = Camera.main.WorldToViewportPoint(transform.position);

        if (viewPosition.y <= 0 - offset) return true;
        return false;
    }
}
