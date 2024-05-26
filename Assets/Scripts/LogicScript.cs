using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public int highScore;
    public Text scoreText;
    public Text highScoreText;
    public GameObject gameOver;
    public string newGameScreen;
    public int level = 1;

    public int firstLvlEnd;
    public int secondLvlEnd;
    public int thirdLvlEnd;
    public int fourthLvlEnd;

    // Load the high score at the begining
    void Start() 
    {
        loadHighScore();    
        Debug.Log("You Entered Level 1!");
    }

    [ContextMenu("Increase Score")]
    public void addScore(int score)
    {
        playerScore = playerScore + score;
        scoreText.text = playerScore.ToString();
    }

    // To get the saved data and display with string
    public void loadHighScore()
    {
        highScore = PlayerPrefs.GetInt("highScore");
        highScoreText.text = "High Score: " + highScore.ToString();
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void toTitle()
    {
        SceneManager.LoadScene(newGameScreen);
    }

    public void gameOverScene()
    {
        gameOver.SetActive(true);

        // Set new high score if its greater
        if (playerScore > highScore)
        {
            highScore = playerScore;
            PlayerPrefs.SetInt("highScore", playerScore);
            highScoreText.text = "High Score: " + highScore.ToString();
        }
    }

    public void setLevel()
    {
        if (playerScore == firstLvlEnd)
        {
            level++;
            Debug.Log("You Entered Level 2!");
        }

        if (playerScore == secondLvlEnd)
        {
            level++;
            Debug.Log("You Entered Level 3!");
        }

        if (playerScore == thirdLvlEnd)
        {
            level++;
            Debug.Log("You Entered Level 4!");
        }

        if (playerScore == fourthLvlEnd)
        {
            level++;
            Debug.Log("You Entered Level 5!");
        }
    }
}
