using System;
using UnityEngine;
using GoogleMobileAds.Api;

public class AdssManager : MonoBehaviour
{


#if UNITY_EDITOR
    string adUnitId = "ca-app-pub-7216743424948383/4317969368";
#elif UNITY_ANDROID
    string adUnitId = "unexpected_platform";
#elif UNITY_IPHONE
        string adUnitId = "unexpected_platform";
#else
    string adUnitId = "unexpected_platform";
#endif
        private InterstitialAd interstitial;
            private int nowLoses;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);

        DestroyAndStartNew(true);
    }

    private void Update()
    {
        if (interstitial.IsLoaded() && GameController.countLoses % 3 == 0 && GameController.countLoses != 0 && GameController.countLoses != nowLoses)
        {
            nowLoses = GameController.countLoses;
            interstitial.Show();
        }
    }

    public void HandleOnAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        DestroyAndStartNew();
    }

    public void HandleOnAdClosed(object sender, EventArgs args)
    {
        DestroyAndStartNew();
    }

    public void HandleOnAdLeavingApplication(object sender, EventArgs args)
    {
        DestroyAndStartNew();
    }

    void DestroyAndStartNew(bool isFirst = false)
    {
        if (!isFirst)
            interstitial.Destroy();

        interstitial = new InterstitialAd(adUnitId);
        // Called when an ad request failed to load.
        this.interstitial.OnAdFailedToLoad += HandleOnAdFailedToLoad;
        // Called when the ad is closed.
        this.interstitial.OnAdClosed += HandleOnAdClosed;
        // Called when the ad click caused the user to leave the application.
        //this.interstitial.OnAdLeavingApplication += HandleOnAdLeavingApplication;
        AdRequest request = new AdRequest.Builder().Build();
        // Load the interstitial with the request.
        this.interstitial.LoadAd(request);
    }
}