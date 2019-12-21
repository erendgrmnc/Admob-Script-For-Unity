using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using System;

public class AdManager : MonoBehaviour
{
    private string APP_ID = "";//ADD APP ID HERE.

    private BannerView bannerAD;
    private InterstitialAd interstitialAD;
    private InterstitialVideoAd interstitialVideoAd;


    private void RequestBanner()

    {
        string banner_ID = "";//ID 
        bannerAD = new BannerView(banner_ID, AdSize.SmartBanner, AdPosition.Top);

        //FOR MARKET 
        //AdRequest adRequest = new AdRequest.Builder().Build();

        //TEST
        AdRequest adRequest = new AdRequest.Builder().AddTestDevice("33BE2250B43518CCDA7DE426D04EE231").Build();

        bannerAD.LoadAd(adRequest);

    }


    void RequestInterstitial()

    {
        string interstitial_ID = "";//ID
        interstitialAD = new InterstitialAd(interstitial_ID);

        //FOR MARKET 
        //AdRequest adRequest = new AdRequest.Builder().Build();

        //TEST
        AdRequest adRequest = new AdRequest.Builder().AddTestDevice("33BE2250B43518CCDA7DE426D04EE231").Build();

        interstitialAD.LoadAd(adRequest);

    }

    void RequestInterstitialVideo()

    {
        string interstitialVideo_ID = "";//ID
        interstitialVideoAD = new InterstitialVideoAd(interstitialVideo_ID);

        //FOR MARKET 
        //AdRequest adRequest = new AdRequest.Builder().Build();

        //TEST
        AdRequest adRequest = new AdRequest.Builder().AddTestDevice("33BE2250B43518CCDA7DE426D04EE231").Build();

        interstitialVideoAD.LoadAd(adRequest);

    }

    public void Display_Banner()
    {
        bannerAD.Show();
    }

    public void Display_InterstitialAD()
    {
        if (interstitialAD.IsLoaded())
        {
            interstitialAD.Show();
        }
    }

    public void Display_InterstitialVideoAD()
    {
        if (interstitialVideoAD.IsLoaded())
        {
            interstitiaVideolAD.Show();
        }
    }

    void Start()
    {
        RequestBanner();
        RequestInterstitial();
        RequestInterstitialVideo();
        MobileAds.Initialize(APP_ID);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void HandleOnAdLoaded(object sender, EventArgs args)
    {
        //ad is loaded, Show it.
        Display_Banner();
    }

    public void HandleOnAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        //ad failed to load , load it again.
        RequestBanner();
    }

    public void HandleOnAdOpened(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdOpened event received");
    }

    public void HandleOnAdClosed(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdClosed event received");
    }

    public void HandleOnAdLeavingApplication(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdLeavingApplication event received");
    }


    void HandleBannerAD_Events(bool subscribe)
    {

        if (subscribe)
        {
            // Called when an ad request has successfully loaded.
            bannerAD.OnAdLoaded += HandleOnAdLoaded;
            // Called when an ad request failed to load.
            bannerAD.OnAdFailedToLoad += HandleOnAdFailedToLoad;
            // Called when an ad is clicked.
            bannerAD.OnAdOpening += HandleOnAdOpened;
            // Called when the user returned from the app after an ad click.
            bannerAD.OnAdClosed += HandleOnAdClosed;
            // Called when the ad click caused the user to leave the application.
            bannerAD.OnAdLeavingApplication += HandleOnAdLeavingApplication;
        }

        else
        {
            // Called when an ad request has successfully loaded.
            bannerAD.OnAdLoaded -= HandleOnAdLoaded;
            // Called when an ad request failed to load.
            bannerAD.OnAdFailedToLoad -= HandleOnAdFailedToLoad;
            // Called when an ad is clicked.
            bannerAD.OnAdOpening -= HandleOnAdOpened;
            // Called when the user returned from the app after an ad click.
            bannerAD.OnAdClosed -= HandleOnAdClosed;
            // Called when the ad click caused the user to leave the application.
            bannerAD.OnAdLeavingApplication -= HandleOnAdLeavingApplication;
        }

        void onEnable()
        {
            HandleBannerAD_Events(true);
        }

        void onDisable()
        {
            HandleBannerAD_Events(false);
        }
    }
}
