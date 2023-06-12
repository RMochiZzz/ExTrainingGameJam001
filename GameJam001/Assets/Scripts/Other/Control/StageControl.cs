using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace StageCtrl
{
    public class StageControl : MonoBehaviour
    {
        [SerializeField] private AudioClip fieldbgm;
        [SerializeField] private AudioClip bossbgm01;
        [SerializeField] private AudioClip bossbgm02;
        [SerializeField] private float fieldbgmVolum;
        private AudioSource audioSource;
        private bool bossSpawned = false;

        public GameObject gameOverObj;
        public GameObject gameClearObj;
        private bool doGameOver;
        private bool doGameClear;

        [SerializeField]private float playerSpeed;
        private Camera mainCamera;
        private GameObject playerObject;

        public string menuSceneName = "MenuScene";

        // Start is called before the first frame update
        void Start()
        {
            playerObject = GameObject.FindGameObjectWithTag("Player");
            mainCamera = Camera.main;
            audioSource = GetComponent<AudioSource>();
            audioSource.PlayOneShot(fieldbgm, fieldbgmVolum);
            doGameOver = false;
            doGameClear = false;
        }

        // Update is called once per frame
        void Update()
        {
            GAMEOVERSystem();

            GAMECLEARSystem();

            ChangeBGM();
        }

        public void GAMEOVERSystem()
        {
            if (GManager.instance.isGameOver && !doGameOver)
            {
                gameOverObj.SetActive(true);
                doGameOver = true;
            }

            if (GManager.instance.isGameOver && Input.GetKeyDown(KeyCode.Return))
            {
                SwitchToMenuScene();
            }
        }

        public void GAMECLEARSystem()
        {
            if (GManager.instance.isGameClear && !doGameClear)
            {
                gameClearObj.SetActive(true);
                doGameClear = true;
            }

            if (GManager.instance.isGameClear && Input.GetKeyDown(KeyCode.Return))
            {
                StartCoroutine(MovePlayerAndSwitchScene());
            }

        }

        IEnumerator MovePlayerAndSwitchScene()
        {
            float targetYPosition = 8f;
            float waitTime = 1f;

            Vector3 targetPosition = new Vector3(playerObject.transform.position.x, targetYPosition, playerObject.transform.position.z);

            while (true)
            {
                playerObject.transform.position = Vector3.MoveTowards(playerObject.transform.position, targetPosition, playerSpeed * Time.deltaTime);

                if (playerObject.transform.position.y >= targetYPosition)
                {
                    yield return new WaitForSeconds(waitTime);
                    SwitchToMenuScene();
                    yield break;
                }

                yield return null;
            }
        }

        public void ChangeBGM() 
        {
            if (GManager.instance.isBossBattle && !bossSpawned)
            {
                bossSpawned = true;
                audioSource.Stop();
                audioSource.loop = false;
                audioSource.PlayOneShot(bossbgm01, fieldbgmVolum);
            }

            if (bossSpawned && !audioSource.isPlaying)
            {
                audioSource.loop = true;
                audioSource.PlayOneShot(bossbgm02, fieldbgmVolum);
            }
        }

        public void SwitchToMenuScene()
        {
            SceneManager.LoadScene(menuSceneName);
        }
    }

}
