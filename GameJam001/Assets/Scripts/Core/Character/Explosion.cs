using UnityEngine;
using UnityEngine.Video;

namespace DeadVideo
{
    public class Explosion : MonoBehaviour
    {
        public VideoClip explosionClip;
        private VideoPlayer videoPlayer;

        void Start()
        {
            videoPlayer = GetComponent<VideoPlayer>();
            videoPlayer.playOnAwake = false;

            videoPlayer.loopPointReached += OnVideoEnd;
        }

        public void PlayExplosion(Vector3 position)
        {
            transform.position = position;
            videoPlayer.clip = explosionClip;

            if (videoPlayer != null && explosionClip != null)
            {
                videoPlayer.Stop();
                videoPlayer.Play();
            }
            
        }

        void OnVideoEnd(VideoPlayer vp)
        {
            vp.Stop();
            Destroy(gameObject);
        }
    }
}
