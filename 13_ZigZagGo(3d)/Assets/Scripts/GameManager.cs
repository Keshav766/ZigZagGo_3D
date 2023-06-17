using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public bool gameOver;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        gameOver = false;
    }

    void Update()
    {

    }

    public void GameStart()
    {
        UIManager.instance.GameStart ();
        ScoreManager.instance.StartScore ();
    }

    public void GameOver()
    {
        gameOver = true;
        UIManager.instance.GameOver();
        ScoreManager.instance.StopScore();
    }
}
