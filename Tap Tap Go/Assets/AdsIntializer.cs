using UnityEngine;
using UnityEngine.Advertisements;
using TMPro;

public class AdsIntializer : MonoBehaviour, IUnityAdsInitializationListener, IUnityAdsLoadListener, IUnityAdsShowListener
{
    string gGameId;
    [SerializeField]
    string gAndroidGameId;
    [SerializeField]
    string gIosId;
    [SerializeField]
    bool gTestMode = true;
    

    string gUnitId;
    string gBannerUnitId;

    bool AdLoaded;

    public bool ADLoaded { get => AdLoaded; private set => AdLoaded = value; }



    public static AdsIntializer Instance;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        Application.targetFrameRate = 60;
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
        AdLoaded = false;
        gGameId = (Application.platform == RuntimePlatform.IPhonePlayer) ? gIosId : gAndroidGameId;
        
        if (!Advertisement.isInitialized)
        {
            IntializeAds();
        }
        else
        {
            if (!Advertisement.Banner.isLoaded)
            {
                LoadBannerAds();
            }
        }
        
    }
    public void IntializeAds()
    {
        Advertisement.Initialize(gGameId, gTestMode, this);
        
    }

    public void LoadInterstitialAds()
    {
        print("Loading Ad...");
        string lUnitIdAndroid = "Interstitial_Android";
        string lUnitIdIos = "Interstitial_iOS";
        string lUnitId = (Application.platform == RuntimePlatform.IPhonePlayer) ? lUnitIdIos : lUnitIdAndroid;
        gUnitId = lUnitId;
        Advertisement.Load(lUnitId, this);
    }

    public void ShowInterstitialAd()
    {
        ADLoaded = false;
        print("Showing Ad");
        Advertisement.Show(gUnitId, this);
    }

    public void LoadBannerAds()
    {
        
        Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
        string lUnitIdAndroid = "Banner_Android", lUnitIdIos = "Banner_iOS";
        gBannerUnitId = (Application.platform == RuntimePlatform.IPhonePlayer) ? lUnitIdIos : lUnitIdAndroid;
        if (gBannerUnitId != null)
        {
            Advertisement.Banner.Load(gUnitId, new BannerLoadOptions
            {
                loadCallback = onBannerLoad,
                errorCallback = OnBannerError
            });
        }
        
    }
    public void HideBannerAd()
    {
        Advertisement.Banner.Hide();
    }

    private void onBannerLoad()
    {
        

    }
    public void ShowBanner()
    {
        
        if (Advertisement.Banner.isLoaded)
        {
            Advertisement.Banner.Show(gBannerUnitId);
        }
 
    }

    private void OnBannerError(string message)
    {
        Debug.Log("Error on loading ads");
    }

    #region AdCallBacks
    public void OnInitializationComplete()
    {
        print("Ads Intiliazed");
      
        LoadBannerAds();
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        print("Ad intializing Failed");
      
    }

    public void OnUnityAdsAdLoaded(string placementId)
    {
        print("AdLoadedNow executing ShowAd");
        ADLoaded = true;
    }

    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
    {
        print("Failed to load Ad");
    }

    public void OnUnityAdsShowClick(string placementId)
    {

    }

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {

    }

    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {

    }

    public void OnUnityAdsShowStart(string placementId)
    {

    }
    #endregion
}
