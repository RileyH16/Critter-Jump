using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public Text scoreText;
    public Text highscoreText;

    int score = 0;
    public int highscore = 0;

    private void Awake()
    {
        instance = this; 
    }

    // Start is called before the first frame update
    void Start()
    {
        highscore = PlayerPrefs.GetInt("highscore", 0);
        scoreText.text = "SCORE: " + score.ToString();
        
        LoadPlayer();
        highscoreText.text = "HIGHSCORE: " + highscore.ToString();
    }

    public void AddPoint()
    {
        score += 1;
        scoreText.text = "SCORE: " + score.ToString();
        if (highscore < score)
        {
            highscore = score;
            PlayerPrefs.SetInt("highscore", score);

        }

    }

    public void SavePlayer()
    {
        SaveSystem.SavePlayer(this);
    }

    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        if(data != null)
        {
            highscore = data.highscore;

        }
        else { highscore = 0; }

    }

    private void OnApplicationQuit()
    {
        SavePlayer();
    }

    private void OnApplicationFocus(bool focus)
    {
        SavePlayer();
    }
}
