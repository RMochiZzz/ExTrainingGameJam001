using UnityEngine;
using UnityEngine.UI;

public class ScrollControl : MonoBehaviour
{
    private float maxLength = 1f;
    private string propName = "_MainTex";

    [SerializeField]
    private Vector2 offsetSpeed;
    private Material material;

    private void Start()
    {
        if (GetComponent<Image>() is Image i)
        {
            material = i.material;
        }
    }

    private void Update()
    {
        if (material)
        {
            var x = Mathf.Repeat(Time.time * offsetSpeed.x, maxLength);
            var y = Mathf.Repeat(Time.time * offsetSpeed.y, maxLength);
            var offset = new Vector2(x, y);
            material.SetTextureOffset(propName, offset);
        }
    }

    private void OnDestroy()
    {
        if (material)
        {
            material.SetTextureOffset(propName, Vector2.zero);
        }
    }
}