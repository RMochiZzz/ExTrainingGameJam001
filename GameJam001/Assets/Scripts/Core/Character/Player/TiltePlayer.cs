using UnityEngine;

public class TitlePlayer : MonoBehaviour
{
    [SerializeField] private float shakeAmount;
    [SerializeField] private float shakeSpeed;
    private Vector3 originalPosition;

    private void Start()
    {
        originalPosition = transform.position;
    }

    private void Update()
    {
        float shakeOffset = Mathf.Sin(Time.time * shakeSpeed) * shakeAmount;

        transform.position = originalPosition + new Vector3(shakeOffset, 0f, 0f);
    }
}