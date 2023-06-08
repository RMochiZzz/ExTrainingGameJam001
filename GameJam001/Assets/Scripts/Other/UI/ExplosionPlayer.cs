using UnityEngine;
using UnityEngine.Video;

public class ExplosionPlayer : MonoBehaviour
{
    public VideoClip explosionClip;
    private VideoPlayer videoPlayer;

    void Start()
    {
        videoPlayer = gameObject.AddComponent<VideoPlayer>();
        videoPlayer.clip = explosionClip;
        videoPlayer.playOnAwake = false;

        videoPlayer.loopPointReached += OnVideoEnd;
    }

    public void PlayExplosion(Vector3 position)
    {
        transform.position = position;
        if (videoPlayer != null && explosionClip != null)
        {
            videoPlayer.Stop();
            videoPlayer.Play();
        }
    }

    void OnVideoEnd(VideoPlayer vp)
    {
        vp.Stop();
    }
}