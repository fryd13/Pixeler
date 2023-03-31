using GoogleMobileAds.Api;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoogleMobileAdsBanner : MonoBehaviour
{
    public static GoogleMobileAdsBanner instance;
    public BannerView bannerView;
    public string adUnitId;
    public void Start()
    {
        instance = this; 
        // Initialize the Google Mobile Ads SDK.
        MobileAds.Initialize(initStatus => { });

        this.RequestBanner();
    }

    private void RequestBanner()
    {
        // Create a 320x50 banner at the top of the screen.
        this.bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.Bottom);
        AdRequest request = new AdRequest.Builder().Build();


        this.bannerView.LoadAd(request);
        
    }
}
