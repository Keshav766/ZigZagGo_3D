using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public int score = 0;
    public int highScore = 0;
    public int diamonds = 0;

    void Awake()
    {
        //PlayerPrefs.DeleteAll();
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        score = 0;
        PlayerPrefs.SetInt("score", score);
    }

    void Update()
    {

    }

    public void StartScore()
    {
        InvokeRepeating("IncrementScore", 0.1f, 0.5f);
    }

    void IncrementScore()
    {

        score += 1;

    }


    public void StopScore()
    {

        CancelInvoke("IncrementScore");
        PlayerPrefs.SetInt("score", score);

        //   for implemienting score and hignscore
        if (PlayerPrefs.HasKey("highScore"))
        {
            if (score > PlayerPrefs.GetInt("highScore"))
            {
                PlayerPrefs.SetInt("highScore", score);
            }
        }
        else
        {
            PlayerPrefs.SetInt("highScore", score);
        }

        //       for implementing diamond score
        if (PlayerPrefs.HasKey("diamondScore"))
        {
            if (diamonds > PlayerPrefs.GetInt("diamondScore"))
            {
                PlayerPrefs.SetInt("diamondScore", diamonds);
            }
        }
        else
        {
            PlayerPrefs.SetInt("diamondScore", diamonds);
        }
        PlayerPrefs.Save();
    }

    public void UpdateDiamondCount()
    {
        diamonds += 1;
    }
}
