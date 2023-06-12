using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLifeDisplay : MonoBehaviour
{
    public GameObject playerLifePrefab;
    private List<GameObject> playerLives = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {

        for (int i = 0; i < GManager.instance.HeartNum; i++)
        {
            // PlayerLifeプレファブを生成して位置を設定
            GameObject life = Instantiate(playerLifePrefab, Vector3.zero, Quaternion.identity);
            life.transform.SetParent(transform);
            life.transform.localPosition = new Vector3(0.5f * i, 0f, 0f);

            playerLives.Add(life);
        }
    }

    // Update is called once per frame
    void Update()
    {
        while (GManager.instance.HeartNum > playerLives.Count)
        {
            GameObject life = Instantiate(playerLifePrefab, Vector3.zero, Quaternion.identity);
            life.transform.SetParent(transform);
            life.transform.localPosition = new Vector3(0.5f * playerLives.Count, 0f, 0f);

            playerLives.Add(life);
        }

        while (GManager.instance.HeartNum < playerLives.Count)
        {
            GameObject life = playerLives[playerLives.Count - 1];
            playerLives.Remove(life);
            Destroy(life);
        }
    }
}