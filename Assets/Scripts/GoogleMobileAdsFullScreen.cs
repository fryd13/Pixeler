using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using System;

public class GoogleMobileAdsFullScreen : MonoBehaviour
{
    public static GoogleMobileAdsFullScreen instance;
    private InterstitialAd interstitial;
    public void Start()
    {
        instance = this;
        RequestInterstitial();
    }

    public void StartAd(){
        if (interstitial.IsLoaded()){
            interstitial.Show(); 
        }
    }
    public void RequestInterstitial()
    {
#if UNITY_ANDROID
        string adUnitId = "ca-app-pub-8410862201323558/3241632662";
#endif

        // Initialize an InterstitialAd.
        this.interstitial = new InterstitialAd(adUnitId);
    
        // Called when the ad is closed.
        this.interstitial.OnAdClosed += HandleOnAdClosed;

        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the interstitial with the request.
        this.interstitial.LoadAd(request);
    }

    public void HandleOnAdClosed(object sender, EventArgs args)
    {
        RequestInterstitial();
    }
}
