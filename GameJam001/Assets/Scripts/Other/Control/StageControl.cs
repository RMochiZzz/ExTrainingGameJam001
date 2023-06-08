using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace StageCtrl
{
    public class StageControl : MonoBehaviour
    {
        [SerializeField] private AudioClip fieldbgm;
        [SerializeField] private float getitemseVolum;
        private AudioSource audioSource;

        public GameObject gameOverObj;
        public GameObject gameClearObj;
        private bool doGameOver = false;
        private bool doGameClear = false;

        public string menuSceneName = "MenuScene";

        // Start is called before the first frame update
        void Start()
        {
            audioSource = GetComponent<AudioSource>();
            audioSource.PlayOneShot(fieldbgm, getitemseVolum);
        }

        // Update is called once per frame
        void Update()
        {

            if (GManager.instance.isGameOver && !doGameOver)
            {
                gameOverObj.SetActive(true);
                doGameOver = true;
            }

            if (GManager.instance.isGameClear && !doGameClear)
            {
                gameClearObj.SetActive(true);
                doGameClear = true;
            }

            if (GManager.instance.isGameOver && Input.GetKeyDown(KeyCode.Return))
            {
                SwitchToMenuScene();
            }
        }

        public void SwitchToMenuScene()
        {
            SceneManager.LoadScene(menuSceneName);
        }
    }

}
