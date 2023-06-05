using UnityEngine;

namespace Other.UI
{
    public class SelectDialog : MonoBehaviour
    {
        [SerializeField] public GameObject dialog;

        public void OnbuttonClick()
        {
            dialog.SetActive(!dialog.activeSelf);
        }
    }
}