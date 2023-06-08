using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GManager : MonoBehaviour
{
    public static GManager instance = null;
    public int defaultHeartNum;
    public int HeartNum;
    public int defaultLevelNum;
    public int LevelNum;
    [HideInInspector] public bool isGameOver = false;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void SubHeartNum()
    {
        if (HeartNum > 0)
        {
            --HeartNum;
        }
        else
        {
            isGameOver = true;
        }
        
        Debug.Log("Žc‚èHP: " + HeartNum);
    }

    public void AddLevelNum()
    {
        ++LevelNum;

        Debug.Log("Level: " + LevelNum);
    }

    public void StartGame()
    {
        isGameOver = false;
        HeartNum = defaultHeartNum;
        LevelNum = defaultLevelNum;

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
