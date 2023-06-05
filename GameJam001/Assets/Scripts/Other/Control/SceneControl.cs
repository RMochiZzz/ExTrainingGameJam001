using UnityEngine;
using UnityEngine.SceneManagement;

namespace Other.Control
{
    public class SceneControl : MonoBehaviour
    {
        public GameObject dialog;

        public static void SwitchMenu() 
        {
            SceneManager.LoadScene("MenuScene");
        }

        public static void SwichBattle()
        {
            SceneManager.LoadScene("BattleScene");
        }

        public static void ExitGame()
        {
            #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
            #endif
        }
    }

}
