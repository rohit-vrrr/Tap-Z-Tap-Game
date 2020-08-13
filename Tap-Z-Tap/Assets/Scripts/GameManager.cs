using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;         // Creating Singleton instance of GameManager

    public bool gameOver;
    private bool hasAdBeenShown = false;

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
        gameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void  StartGame()           // Starting the Game by calling UIManager and ScoreManager
    {
        UIManager.instance.GameStart();
        ScoreManager.instance.StartScore();

        // Finding PlatformSpawner from our scene, Getting the Component and calling the StartSpawn func
        GameObject.Find("PlatformSpawner").GetComponent<PlatformSpawner>().StartSpawn();
    }

    public void GameOver()         // Ending the Game
    {
        UIManager.instance.GameOver();
        ScoreManager.instance.StopScore();
        GameObject.Find("BackGroundAudio").GetComponent<AudioSource>().Stop();

        gameOver = true;

        if(!hasAdBeenShown)         // Showing InterstitialAd
        {
            UnityAdManager.instance.PlayInterstitialAd();
            hasAdBeenShown = true;
        }
    }
}
