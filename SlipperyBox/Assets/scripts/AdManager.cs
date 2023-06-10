using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;

public class AdManager : MonoBehaviour, IUnityAdsListener
{
    private string GooglePlayStoreID = "3782243";
    private string AppleAppStoreID = "3782242";

    private string interstitialAd = "video";
    private string rewardedVideoAd = "rewardedVideo";

    public bool isTargetPlaystore;      //  if it is true, ads towards the playstore otherwise the Appstore
    public bool isTestAd;               // if true, we are testing the ad, otherwise actual ads


    public AudioSource AudioSource;

    private void Start()
    {
        Advertisement.AddListener(this);

        InitializeAdvertisement();      // when starts at first, initialize the ads
    }

    private void InitializeAdvertisement()
    {
        // whether to deploy the app to the playstore or the appstore
        if (isTargetPlaystore) { Advertisement.Initialize(GooglePlayStoreID, isTestAd); return; }
        Advertisement.Initialize(AppleAppStoreID, isTestAd);
    }

    public void PlayInterstitialAd()
    {
        AudioSource.mute = true;
        if (!Advertisement.IsReady(interstitialAd)) { return; }
        Advertisement.Show(interstitialAd);
    }


    public void PlayRewardedVideo() 
    {
        if (!Advertisement.IsReady(rewardedVideoAd)) { return; }
        Advertisement.Show(rewardedVideoAd);
    }

    public void OnUnityAdsReady(string placementId)
    {
        //throw new System.NotImplementedException();
    }

    public void OnUnityAdsDidError(string message)
    {
        //throw new System.NotImplementedException();
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        //throw new System.NotImplementedException();
        
        // Mute the audio from game
        FindObjectOfType<AdManager>().AudioSource.mute = true;
        AudioListener.volume = 0f;
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        //throw new System.NotImplementedException();

        switch (showResult)        {

            case ShowResult.Failed:

                break;

            case ShowResult.Skipped:

                if (placementId == interstitialAd)
                {
                    if (SceneManager.GetActiveScene().name == "FreeMode")
                    {
                        FindObjectOfType<GameManager>().GotoMenu();
                    }
                    else if (SceneManager.GetActiveScene().name == "Guide")
                    {
                        FindObjectOfType<GameManager>().EndGame();
                    }
                    else
                    {
                        FindObjectOfType<GameManager>().completeLevelUI.SetActive(true);
                    }
                    AudioListener.volume = 1f;
                }
                break;

            case ShowResult.Finished:

               /* if(placementId == rewardedVideoAd)
                {
                    if (isEnd)
                    {
                        if (SceneManager.GetActiveScene().name == "FreeMode")
                        {
                            FindObjectOfType<GameManager>().GotoMenu();
                        }
                        else
                        {
                            FindObjectOfType<GameManager>().completeLevelUI.SetActive(true);
                        }
                        AudioListener.volume = 1f;

                    }

                    if (!isEnd)
                    {
                        FindObjectOfType<GameManager>().WatchAdButton.SetActive(false);
                        FindObjectOfType<GameManager>().RestartButton.SetActive(false);
                        FindObjectOfType<PlayerMoment>().EnableMovement();
                        FindObjectOfType<AdManager>().AudioSource.mute = false;
                        AudioListener.volume = 1f;
                    }
                }*/

                if(placementId == rewardedVideoAd)
                {
                    FindObjectOfType<GameManager>().WatchAdButton.SetActive(false);
                    FindObjectOfType<GameManager>().RestartButton.SetActive(false);
                    FindObjectOfType<PlayerMoment>().EnableMovement();
                    FindObjectOfType<AdManager>().AudioSource.mute = false;
                    AudioListener.volume = 1f;
                }

                if(placementId == interstitialAd)
                {
                    if (SceneManager.GetActiveScene().name == "FreeMode")
                    {
                        FindObjectOfType<GameManager>().GotoMenu();
                    }
                    else if (SceneManager.GetActiveScene().name == "Guide")
                    {
                        FindObjectOfType<GameManager>().EndGame();
                    }
                    else
                    {
                        FindObjectOfType<GameManager>().completeLevelUI.SetActive(true);
                    }
                    AudioListener.volume = 1f;
                }

                break;
        }

    }
}
