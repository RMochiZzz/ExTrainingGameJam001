using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonSE : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler
{
    public AudioClip hoverSound;   // ホバー時に再生する効果音
    public AudioClip clickSound;   // クリック時に再生する効果音

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        audioSource.PlayOneShot(hoverSound);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        audioSource.PlayOneShot(clickSound);
    }
}