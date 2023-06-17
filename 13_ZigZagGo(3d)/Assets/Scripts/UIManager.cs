using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    // singleton pattern
    public static UIManager instance;

    [SerializeField] GameObject titleScreen;
    [SerializeField] GameObject tapText;
    [SerializeField] GameObject gameOverScreen;
    [SerializeField] TextMeshProUGUI score;
    [SerializeField] TextMeshProUGUI highScore_Title;
    [SerializeField] TextMeshProUGUI highScore_GameOver;
    [SerializeField] TextMeshProUGUI diamondText;
    [SerializeField] TextMeshProUGUI HighDiamondScoreText;
    [SerializeField] TextMeshProUGUI moreSpeedtext;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        highScore_Title.text = PlayerPrefs.GetInt("highScore").ToString();
    }

    void start()
    {

    }

    void Update()
    {
        UpdateDiamondText();
    }

    public void GameStart()
    {
        titleScreen.GetComponent<Animator>().Play("TitlePanelGoUp");
        tapText.GetComponent<Animator>().Play("TapToStartTextFalldown");
        diamondText.gameObject.SetActive(true);
    }

    public void GameOver()
    {
        score.text = PlayerPrefs.GetInt("score").ToString();
        highScore_GameOver.text = PlayerPrefs.GetInt("highScore").ToString();
        HighDiamondScoreText.text = PlayerPrefs.GetInt("diamondScore").ToString();
        gameOverScreen.SetActive(true);
    }

    public void Reset()
    {
        SceneManager.LoadScene(0);
    }

    public void UpdateDiamondText()
    {
        diamondText.text = "Diamonds : " + ScoreManager.instance.diamonds;
    }

    public void PlayMoreSpeedAnim()
    {
        moreSpeedtext.GetComponent<Animator>().Play("moreSpeedText");
    }
}
