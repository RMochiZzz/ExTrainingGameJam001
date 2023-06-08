using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace StageCtrl
{
    public class StageControl : MonoBehaviour
    {
        public GameObject gameOverObj;

        private bool doGameOver = false;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (GManager.instance.isGameOver && !doGameOver)
            {
                gameOverObj.SetActive(true);
                doGameOver = true;
            }
        }
    }

}
