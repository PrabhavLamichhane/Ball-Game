using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using LukasScripts.Utils;

namespace LukasScripts
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager instance;

        [SerializeField]
        private Camera _cam;

        #region Buttons
        public GameObject UI_Btns;

        [SerializeField]
        private Button restartBtn;

        [SerializeField]
        private Button homeBtn;

        [SerializeField]
        private Button soundBtn;

        [SerializeField]
        private Image volumeImg;

        [SerializeField]
        private Sprite muteSpr, volumeSpr;
     
        [SerializeField]
        private Button adBtn;

        #endregion

        [SerializeField]
        private float loadTimer = 2f;

        public PlatformCounter platformCounter;

        private SoundManager _soundManager;
        private ServiceManager service;

        [SerializeField]
        private RewardedAdTimer adTimer;

        private int _randNum;

        private void Awake()
        {
            if (instance == null)
                instance = this;        
        }

        private void Start()
        {
            
            if (_cam == null)
                _cam = Camera.main;

          //  _cam.backgroundColor = Random.ColorHSV();
            _cam.backgroundColor = new Color(Random.value, Random.value, Random.value);
            _soundManager = SoundManager.instance;
            service = ServiceManager.instance;

            if (adTimer == null)
                adTimer = FindObjectOfType<RewardedAdTimer>();
           
        }

        private void OnEnable()
        {
            BallMovement.onBallRestart += EnableRestartBtn;
            Spike.restartEvent += EnableAdButon;
            RewardedAds.onRewardedAd += FinishedWatchingRewaredAd;
        }

        private void OnDisable()
        {
            Spike.restartEvent -= EnableAdButon;
            BallMovement.onBallRestart -= EnableRestartBtn;
            RewardedAds.onRewardedAd -= FinishedWatchingRewaredAd;
        }
   
        public void ReloadGame() => StartCoroutine(ReloadAcitveLevel(loadTimer));

        public void LoadMainMenu() => StartCoroutine(LoadMainMenuASync(TagManager.MainMenu));

        public void EnableOrDisableSound()
        {
            _soundManager.IsMute = !_soundManager.IsMute;
            _soundManager.SoundPreferences();

            if (_soundManager.IsMute)
            {
                volumeImg.sprite = muteSpr;
            }
            else
            {
                volumeImg.sprite = volumeSpr;
            }
        }

        private void EnableAdButon()
        {
            adBtn.gameObject.SetActive(true);
            adTimer.canStartTimer = true;
        }

        private void EnableRestartBtn()
        {
            if (service == null)
                service = FindObjectOfType<ServiceManager>();

            _randNum = Random.Range(0, 5);

            if(_randNum >= 3)
            {
                service.nonRewarded.DisplayNonRewardedVideo();
                restartBtn.gameObject.SetActive(true);
            }
            else
            {
                restartBtn.gameObject.SetActive(true);
            }
          

            #region Initial Ads
            // ServiceManager.instance.nonRewarded.DisplayNonRewardedVideo();

            //if (ServiceManager.instance == null)
            //{
            //    ServiceManager service = FindObjectOfType<ServiceManager>();
            //    service.rewardedAds.DisplayRewardedVideo();
            //}
            //else
            //{
            //    ServiceManager.instance.rewardedAds.DisplayRewardedVideo();
            //}
            //restartBtn.gameObject.SetActive(true);
            //UI_Btns.SetActive(true);
            #endregion
        }

        public void DisplayRewardedAd()
        {
            if (service == null)
                service = FindObjectOfType<ServiceManager>();

            service.rewardedAds.DisplayRewardedVideo();
        }

        public void DisplayNonRewardedAd()
        {
            StartCoroutine(WaitBeforeDisplayingAD());
        }
        #region Courutines
        private IEnumerator WaitBeforeDisplayingAD()
        {
            yield return new WaitForSecondsRealtime(2);

            if (ServiceManager.instance == null)
            {
                ServiceManager service = FindObjectOfType<ServiceManager>();
                _randNum = Random.Range(0, 5);
                service.nonRewarded.DisplayNonRewardedVideo();
            }

          
         //   UI_Btns.SetActive(true);
        }
      
        private IEnumerator LoadMainMenuASync(string  lvl)
        {
            yield return SceneManager.LoadSceneAsync(lvl, LoadSceneMode.Single);
        }
        
        private IEnumerator ReloadAcitveLevel(float v)
        {      
            yield return new WaitForSeconds(v);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);   
        }

        #endregion

        private void FinishedWatchingRewaredAd()
        {
            adBtn.gameObject.SetActive(false);
            //text
            StartCoroutine(ReloadAcitveLevel(1.1f));
        }


        public void TimerForRewardedAdFinished()
        {
            adBtn.gameObject.SetActive(false);
            ServiceManager.instance.nonRewarded.DisplayNonRewardedVideo();
            restartBtn.gameObject.SetActive(true);

            if(!UI_Btns.activeInHierarchy)
            UI_Btns.SetActive(true);
        }
    }

}