using System.Collections;
using System.Collections.Generic;
using AppsFlyerSDK;
using TMPro;
using UnityEngine;
using Utilities;

namespace Template
{
    public class AppsFlyerTest : MonoBehaviour
    {
        [SerializeField] private TMP_Text _dataView;

        [Header("Apps Flyer Settings")]
        public string devKey;
        [HideInInspector]
        public string appID;
        [HideInInspector]
        public string UWPAppID;
        [HideInInspector]
        public string macOSAppID;
        public bool isDebug = false;
        public bool getConversionData = true;

        public System.Action<string> OnConversionRecieved;

        private string _conversionData;

        private void OnEnable()
        {
            OnConversionRecieved += onConversionRecieved;
        }

        private void OnDisable()
        {
            OnConversionRecieved -= onConversionRecieved;
        }

        private void Awake()
        {
            AppsFlyer.setIsDebug(isDebug);
#if UNITY_WSA_10_0 && !UNITY_EDITOR
        AppsFlyer.initSDK(devKey, UWPAppID, getConversionData ? this : null);
#elif UNITY_STANDALONE_OSX && !UNITY_EDITOR
    AppsFlyer.initSDK(devKey, macOSAppID, getConversionData ? this : null);
#else
            AppsFlyer.initSDK(devKey, appID, getConversionData ? this : null);
#endif

            AppsFlyer.startSDK();

            DontDestroyOnLoad(this);
        }

        private void Start()
        {
            StartCoroutine(WaitForConversionData());
        }

        public void onConversionDataSuccess(string conversionData)
        {
            AppsFlyer.AFLog("didReceiveConversionData", conversionData);
            Dictionary<string, object> conversionDataDictionary = AppsFlyer.CallbackStringToDictionary(conversionData);

            OnConversionRecieved?.Invoke(conversionData);
        }

        public void onConversionDataFail(string error)
        {
            AppsFlyer.AFLog("didReceiveConversionDataWithError", error);
        }

        private IEnumerator WaitForConversionData()
        {
            while (_conversionData == null)
            {
                yield return null;
            }

            _dataView.text = _conversionData.ToString();
            Debug.Log("<color=green>Sucsess: </color> " + _conversionData);
            yield return new WaitForSeconds(3f);
            SceneLoader.LoadSceneByBuildIndex(1);
        }

        private void onConversionRecieved(string conversionData)
        {
            _conversionData = conversionData;
        }
    }
}
