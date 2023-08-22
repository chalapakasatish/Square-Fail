using SimpleSolitaire.Controller;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public enum GameState
{
    NONE,
    PLAYING,
    FAILED
}
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
   public GameState gameState;
    public Text scoreTextDisplay,currentScoreDisplay,highScoreDisplayTitle, highScoreDisplayFailed;
    private int score;
    public GameObject player;
    public GameObject platform;
    public GameObject scoreBoard;
    public GameObject touchButtonsPanel;
    public bool isGameContinue;
    public Text rightText, leftText;
    public GameObject rightArrow, leftArrow;
    public int Score
    {
        get { return score; }
        set { score = value; }
    }

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    private void Start()
    {
        gameState = GameState.NONE;
        PlayerPrefs.GetInt("HighScore");
        highScoreDisplayTitle.text = "HIGH SCORE: " + PlayerPrefs.GetInt("HighScore");
        highScoreDisplayFailed.text = "HIGH SCORE: " + PlayerPrefs.GetInt("HighScore");
    }
    private void Update()
    {
        switch(gameState)
        {
            case GameState.PLAYING:
                if (Time.timeScale == 1)
                {
                    touchButtonsPanel.SetActive(true);
                    score++;
                    scoreTextDisplay.text = "" + score;
                    ScoreUpdate();
                }
                break;
            case GameState.FAILED:
                UIPopupManager.Instance.Hide("CoinsPanel");
                UIPopupManager.Instance.Hide("PotionPanel");
                UIPopupManager.Instance.Hide("GameContinueWithPotion");
                touchButtonsPanel.SetActive(false);
                break;
        }
    }

    public void PlayButton()
    {
        rightText.gameObject.SetActive(true);
        leftText.gameObject.SetActive(true);
        //rightArrow.gameObject.SetActive(true);
        //leftArrow.gameObject.SetActive(true);
        Time.timeScale = 1;
        score = 0;
        scoreTextDisplay.text = "" + score;
        gameState = GameState.PLAYING;
        ScreenManager.Instance.Show("GameScreen");
        ScreenManager.Instance.Hide("MenuScreen");
        Instantiate(player, new Vector2(0, -2.45f),Quaternion.identity);
        Instantiate(platform, new Vector2(0, -2.8f), Quaternion.identity);
        Instantiate(platform, new Vector2(1, -6f), Quaternion.identity);
        scoreBoard.SetActive(true);
    }
    public void ReplayButton()
    {
        rightText.gameObject.SetActive(true);
        leftText.gameObject.SetActive(true);
        //rightArrow.gameObject.SetActive(true);
        //leftArrow.gameObject.SetActive(true);
        Time.timeScale = 1;
        gameState = GameState.PLAYING;
        score = 0;
        scoreTextDisplay.text = "" + score;
        ScreenManager.Instance.Show("GameScreen");
        ScreenManager.Instance.Hide("FailedScreen");
        Instantiate(player, new Vector2(0, -2.45f), Quaternion.identity);
        Instantiate(platform, new Vector2(0, -2.8f), Quaternion.identity);
        Instantiate(platform, new Vector2(1, -6f), Quaternion.identity);
        scoreBoard.SetActive(true);
    }
    public void GameFailed()
    {
        rightText.gameObject.SetActive(false);
        leftText.gameObject.SetActive(false);
        //rightArrow.gameObject.SetActive(false);
        //leftArrow.gameObject.SetActive(false);
        Destroy(GameObject.FindGameObjectWithTag("Player"));
        if (PlayerPrefs.GetInt("PotionBalance",CurrencyManager.instance.potions) >= 1)
        {
            UIPopupManager.Instance.Show("GameContinueWithPotion");
        }
        else
        {
            if (CurrencyManager.instance.Coins >= 50)
            {
                UIPopupManager.Instance.Show("PotionPanel");
            }
            else
            {

                gameState = GameState.FAILED;
                //AdManager.instance.ShowInterstitialAdAtLoose();
                currentScoreDisplay.text = "SCORE: " + score;
                ScreenManager.Instance.Show("FailedScreen");
                ScreenManager.Instance.Hide("GameScreen");
                scoreBoard.SetActive(false);
                Destroy(GameObject.FindGameObjectWithTag("Player"));
                if (GameObject.FindGameObjectWithTag("Platform").activeInHierarchy)
                {
                    Destroy(GameObject.FindGameObjectWithTag("Platform"));
                }
            }
        }
    }
    public void GameContinueButton()
    {
        if (PlayerPrefs.GetInt("PotionBalance") >= 1 )
        {
            GameContinue();
        }
        else
        {
            currentScoreDisplay.text = "SCORE: " + score;
            ScreenManager.Instance.Show("FailedScreen");
            ScreenManager.Instance.Hide("GameScreen");
            scoreBoard.SetActive(false);
            Destroy(GameObject.FindGameObjectWithTag("Player"));
            if (GameObject.FindGameObjectWithTag("Platform").activeInHierarchy)
            {
                Destroy(GameObject.FindGameObjectWithTag("Platform"));
            }
        }
    }
    public void GameContinue()
    {
        Time.timeScale = 1;
        gameState = GameState.FAILED;
        StartCoroutine(DelayPlatformDestroy());
    }
    public IEnumerator DelayPlatformDestroy()
    {
        yield return new WaitForSeconds(0.1f);
        gameState = GameState.PLAYING;
        ScreenManager.Instance.Show("GameScreen");
        UIPopupManager.Instance.Hide("GameContinueWithPotion");
        Instantiate(player, new Vector2(0, -2.45f), Quaternion.identity);
        Instantiate(platform, new Vector2(0, -2.8f), Quaternion.identity);
        Instantiate(platform, new Vector2(1, -6f), Quaternion.identity);
    }
    public void ScoreUpdate()
    {
        if (score > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", score);
            highScoreDisplayTitle.text = "HIGH SCORE: " + PlayerPrefs.GetInt("HighScore");
            highScoreDisplayFailed.text = "HIGH SCORE: " + PlayerPrefs.GetInt("HighScore");
        }
    }
    public void IsPotionAvailable()
    {
        if(gameState == GameState.PLAYING)
        {
            UIPopupManager.Instance.Show("GameContinueWithPotion");
        }
        else
        {
            
        }
    }
    public void YesButton()
    {
        Application.Quit();
    }
    public void NoButton()
    {
        UIPopupManager.Instance.Hide("QuitPanel");
    }
    public void ResumeButton()
    {
        Time.timeScale = 1;
    }
    public void HomeButton()
    {
        ScreenManager.Instance.Show("MenuScreen");
        ScreenManager.Instance.Hide("GameScreen");
        ScreenManager.Instance.Hide("FailedScreen");
        UIPopupManager.Instance.Hide("PausePanel");
        gameState = GameState.NONE;
        Destroy(GameObject.FindGameObjectWithTag("Player"));
        GameObject[] nobjects = GameObject.FindGameObjectsWithTag("Platform");
        foreach (var item in nobjects)
        {
            Destroy(item);
        }
    }
    public void GameFinish()
    {
        if (GameManager.instance.gameState == GameState.PLAYING)
        {
            //AdManager.instance.ShowInterstitialAdAtLoose();
            gameState = GameState.FAILED;
            currentScoreDisplay.text = "SCORE: " + score;
            ScreenManager.Instance.Show("FailedScreen");
            ScreenManager.Instance.Hide("GameScreen");
            scoreBoard.SetActive(false);
            Destroy(GameObject.FindGameObjectWithTag("Player"));
        }
        
    }
    public void DeletePlatforms()
    {
        PlatformScript.instance.DestroyPlatforms();
    }
}
