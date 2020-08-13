using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;            // Creating Singleton instance of ScoreManager

    public int score;
    public int highScore;

    private void Awake()            // For making ScoreManager as Singleton
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        PlayerPrefs.SetInt("score", score);         // key "score" to store the value in machine
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void IncrementScore()           // Increment score by 1
    {
        score += 1;
    }

    public void StartScore()            // Repeatedly calls IncrementScore
    {
        InvokeRepeating("IncrementScore", 0.1f, 0.5f);
    }

    public void StopScore()         // Cancels repeatedly calling IncrementScore
    {
        CancelInvoke("IncrementScore");

        PlayerPrefs.SetInt("score", score);         // Saves the  current score

        if(PlayerPrefs.HasKey("highScore"))         // Checking for previous highScore
        {
            if(score > PlayerPrefs.GetInt("highScore"))         // Checking if current score is higher than highScore
            {
                PlayerPrefs.SetInt("highScore", score);
            }
        }
        else
        {
            PlayerPrefs.SetInt("highScore", score);
        }
    }
}
