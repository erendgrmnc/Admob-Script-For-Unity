using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using UnityEngine.SceneManagement;

public class AdManager : MonoBehaviour
{

    private InterstitialAd interstitial_Ad;
    private RewardedAd rewardedAd;
    private BannerView bannerAd;

    private bool isBannerLoaded = false;
    private string bannerAdID;
    private string interstitial_Ad_ID;
    private string rewardedAd_ID;

    void Start()
    {
        bannerAdID = ""; // Banner Ad ID Of Your App.
        interstitial_Ad_ID = ""; //Interstitial Ad ID Of Your App.
        rewardedAd_ID = "";// Rewarded Ad ID Of Your App.

        MobileAds.Initialize(initStatus => { });

        RequestBanner();
        RequestInterstitial();
        RequestRewardedVideo();


    }

    private void RequestBanner()
    {
        bannerAd = new BannerView(bannerAdID, AdSize.SmartBanner, AdPosition.Bottom);
        bannerAd.OnAdLoaded += HandleOnAdLoaded;
        AdRequest request = new AdRequest.Builder().Build();
        bannerAd.OnAdClosed += HandleBannerAdClose;
        bannerAd.LoadAd(request);
    }

    private void RequestInterstitial()
    {
        interstitial_Ad = new InterstitialAd(interstitial_Ad_ID);
        interstitial_Ad.OnAdLoaded += HandleOnAdLoaded;
        AdRequest request = new AdRequest.Builder().Build();
        interstitial_Ad.OnAdClosed += HandleRewardedAdClosed;
        interstitial_Ad.LoadAd(request);
    }

    private void RequestRewardedVideo()
    {
        rewardedAd = new RewardedAd(rewardedAd_ID);
        rewardedAd.OnUserEarnedReward += HandleUserEarnedReward;
        rewardedAd.OnAdClosed += HandleRewardedAdClosed;
        rewardedAd.OnAdFailedToShow += HandleRewardedAdFailedToShow;
        AdRequest request = new AdRequest.Builder().Build();
        rewardedAd.LoadAd(request);
    }

    public void ShowInterstitial()
    {
        if (interstitial_Ad.IsLoaded())
        {
            interstitial_Ad.Show();
            RequestInterstitial();
        }

    }

    public void ShowRewardedVideo()
    {
        if (rewardedAd.IsLoaded())
        {
            rewardedAd.Show();
        }
    }

    public void ShowBanner()
    {

        if (isBannerLoaded)
        {
            bannerAd.Show();
        }
    }

    public void CloseBanner()
    {
    }

    public void HandleOnAdLoaded(object sender, EventArgs args)
    {
        if (sender.GetType() == typeof(BannerView))
        {
            isBannerLoaded = true;
        }
    }

    public void HandleRewardedAdFailedToShow(object sender, AdErrorEventArgs args)
    {
        RequestRewardedVideo();
    }

    public void HandleRewardedAdClosed(object sender, EventArgs args)
    {

    }

    public void HandleUserEarnedReward(object sender, Reward args)
    {
    }

    public void HandleBannerAdClose(object sender, EventArgs args)
    {

        isBannerLoaded = false;
    }
}