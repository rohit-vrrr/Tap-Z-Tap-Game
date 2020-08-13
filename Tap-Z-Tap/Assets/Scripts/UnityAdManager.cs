using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class UnityAdManager : MonoBehaviour
{
    public static UnityAdManager instance;

    private string playStoreID = "3726033";             // Unity Dashboard info
    // private string appStoreID = "3726032";

    private string interstitialAd = "video";
    private string rewardedVideoAd = "rewardedVideo";

    public bool isTargetPlayStore;
    public bool isTestAd = true;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);

        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    void Start()
    {
        Advertisement.Initialize(playStoreID, isTestAd);
    }

    public void PlayInterstitialAd()            // Playing Interstitial Ad
    {
        if (PlayerPrefs.HasKey("AdCount"))           // Checking for AdCount
        {
            PlayerPrefs.SetInt("AdCount",
                    PlayerPrefs.GetInt("AdCount") + 1);

            if (PlayerPrefs.GetInt("AdCount") == 3)          // if AdCount is 3 then show Ad
            {
                if (Advertisement.IsReady(interstitialAd))
                {
                    Advertisement.Show(interstitialAd);
                }
                else
                {
                    return;
                }

                PlayerPrefs.SetInt("AdCount", 0);           // Resetting AdCount to 0
            }
        }
        else
        {
            PlayerPrefs.SetInt("AdCount", 1);           // Initialising AdCount
        }
    }

    public void PlayRewardedVideoAd()           // Playing Rewarded Ad
    {
        if (!Advertisement.IsReady(rewardedVideoAd))
        {
            return;
        }
        Advertisement.Show(rewardedVideoAd);
    }
}
