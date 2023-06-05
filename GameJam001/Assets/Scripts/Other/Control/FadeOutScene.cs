using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

namespace Other.Control
{
    public class FadeOutScene : MonoBehaviour
    {
        public Image fadeImage;
        public float fadeDuration = 1.0f;
        public string scene;

        private void Start()
        {
            fadeImage.gameObject.SetActive(false);
        }

        public void OnButtonClick()
        {
            StartCoroutine(TransitionSeq());
        }

        private IEnumerator TransitionSeq()
        {
            yield return StartCoroutine(FadeOut());
            SceneManager.LoadScene(scene);
        }

        private IEnumerator FadeOut()
        {
            fadeImage.gameObject.SetActive(true);

            float t = 0f;
            Color startColor = Color.clear;
            Color endColor = Color.black;

            while (t < 1f)
            {
                t += Time.deltaTime / fadeDuration;
                fadeImage.color = Color.Lerp(startColor, endColor, t);
                yield return null;
            }
        }
    }
}