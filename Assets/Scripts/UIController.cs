using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    // UIController controls and holds references of all UI elements of the game except main menu
    public static UIController Instance;

    [SerializeField] GameObject introPanel;
    [SerializeField] GameObject gameOverPanel;
    [SerializeField] Text scoreText;
    [SerializeField] Text gameOverScoreText;
    [SerializeField] Text highScoreText;
    [SerializeField] Text gameOverHighScoreText;
    [SerializeField] Button restartButton;
    [SerializeField] Button mainMenuButton;

    private int score;
    private int highScore;

    private void Awake() 
    {
        Instance = this;    
    }

    private void Start() 
    {
        score = 0;
        highScore = PlayerPrefs.GetInt("highScore", highScore); 
        highScoreText.text = "HighScore: " + highScore;   
    }

    private void Update() 
    {
        GameManager.manager._playerView.OnGameStart += GameStart;
        GameManager.manager._playerView.OnDead += GameOver;
    }
    

    private void GameStart()
    {
        introPanel.SetActive(false);
    }

    public void ScoreUpdate()
    {
        score++;
        if(score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("highScore", highScore);
        }
        scoreText.text = "" + score;
        gameOverScoreText.text = "" + score;
        highScoreText.text = "HighScore: " + highScore;
        gameOverHighScoreText.text = "HighScore: " + highScore;
    }

    private void GameOver()
    {
        gameOverPanel.SetActive(true);
    }

    public void RestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene(0);
    }
    

}
