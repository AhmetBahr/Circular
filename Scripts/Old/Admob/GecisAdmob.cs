using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using System;

public class GecisAdmob : MonoBehaviour
{
    private InterstitialAd interstitial;



    void Start()
    {
        #if UNITY_ANDROID
                string appId = "ca-app-pub-3433338749600523~2731465692";
        #elif UNITY_IPHONE
                string appId = "";
        #else
                string appId = "";
        #endif

    }
    

    public void ShowInterstitial()
    {
        RequestInterstitial();
    }

    public void RequestInterstitial()
    {
        #if UNITY_ANDROID
                string interstitialId = "ca-app-pub-3433338749600523/5090638360";
        #elif UNITY_IPHONE
                string interstitialId = "ca-app-pub-3940256099942544/2934735716";
        #else
                string interstitialId = "unexpected_platform";
        #endif

        if(interstitial != null)
        {
            interstitial.Destroy();
        }
        interstitial = new InterstitialAd(interstitialId);
        interstitial.OnAdLoaded += HandleOnAdLoaded;


        interstitial.LoadAd(CreateNewRequest());

    }


    public void HandleOnAdLoaded(object sender, EventArgs args)
    {
        if (interstitial.IsLoaded())
             interstitial.Show();
       
    }

    private AdRequest CreateNewRequest()
    {
        return new AdRequest.Builder().Build();
    }



}
