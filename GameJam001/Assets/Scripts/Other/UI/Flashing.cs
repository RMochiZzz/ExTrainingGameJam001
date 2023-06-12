using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashing : MonoBehaviour
{
    public float interval;
    public int blinkCount;
    private new Renderer renderer;

    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<Renderer>();
        renderer.enabled = true;
        StartCoroutine(BlinkObject());
    }


    IEnumerator BlinkObject()
    {
        bool isVisible = true;

        for (int i = 0; i < blinkCount; i++)
        {
            isVisible = !isVisible;
            renderer.enabled = isVisible;
            yield return new WaitForSeconds(interval);
        }

        renderer.enabled = true;
    }
}