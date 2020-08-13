using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;           // Creating Singleton instance of UIManager

    public GameObject startPanel;
    public GameObject gameOverPanel;
    public GameObject tapText;
    public TextMeshProUGUI score;
    public TextMeshProUGUI highScore1;
    public TextMeshProUGUI highScore2;


    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // Setting highScore in Start Panel
        highScore1.text = "High Score: " + PlayerPrefs.GetInt("highScore");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameStart()
    {
        tapText.SetActive(false);
        startPanel.GetComponent<Animator>().Play("PanelUp");
    }

    public void GameOver()
    {
        score.text = PlayerPrefs.GetInt("score").ToString();            // Setting current score in GameOver Panel
        highScore2.text = PlayerPrefs.GetInt("highScore").ToString();           // Setting highScore in GameOver Panel

        gameOverPanel.SetActive(true);
    }

    public void Retry()
    {
        SceneManager.LoadScene(0);
    }
}
