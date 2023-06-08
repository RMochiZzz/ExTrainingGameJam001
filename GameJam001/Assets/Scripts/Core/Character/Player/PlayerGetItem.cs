using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGetItem : MonoBehaviour
{
    [SerializeField] private AudioClip playergetitemSE;
    [SerializeField] private float getitemseVolum;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("LevelUpItem"))
        {
            GManager.instance.AddLevelNum();
            PlayPlayergetitemSE(getitemseVolum);

        }
    }
    private void PlayPlayergetitemSE(float volumeScale)
    {
        audioSource.PlayOneShot(playergetitemSE, volumeScale);
    }
}
