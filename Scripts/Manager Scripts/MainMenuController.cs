using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


namespace LukasScripts
{
    public class MainMenuController : MonoBehaviour
    {
        public Camera cam;

        public Button playBtn;
        public Button soundBtn;
        private Button quitBtn;
        public Button shopBtn;
        public Image sound;
        public Sprite volumeOffSpr;
        public Sprite volueOnSpr;

        [SerializeField]
        private GameObject shopPanel;

        [SerializeField]
        private StoreAnimController storeAnim; 

    
        
        private SoundManager _soundManager;

        [SerializeField]
        private Button facebookBtn;

        [SerializeField]
        private Button twitterBtn;

        private void Awake()
        {
            if (cam == null)
                cam = Camera.main;

            _soundManager = SoundManager.instance;
        }

        private void Start()
        {
            cam.backgroundColor = new Color(Random.value, Random.value, Random.value);

            if (_soundManager == null)
                _soundManager = FindObjectOfType<SoundManager>();

          
        
            shopBtn.onClick.AddListener(() => EnableShopPanel());
            playBtn.onClick.AddListener(() => LoadaSyncLevel(TagManager.Level_1));
            soundBtn.onClick.AddListener(() => MuteSound());

            facebookBtn.onClick.AddListener(() => FacebookButton());
            twitterBtn.onClick.AddListener(() => TwitterButton());


        }

        private void LoadaSyncLevel(string lvl)
        {
            StartCoroutine(LoadSceneASycn(lvl));
        }

        private void MuteSound()
        { 
            _soundManager.IsMute = !_soundManager.IsMute;

            _soundManager.SoundPreferences();

            if (_soundManager.IsMute)
                sound.sprite = volumeOffSpr;  
            
            else if (!_soundManager.IsMute)
                  sound.sprite = volueOnSpr;
            
        }

        private IEnumerator LoadSceneASycn(string lvl)
        {
            yield return SceneManager.LoadSceneAsync(lvl, LoadSceneMode.Single);
        }

        private void EnableShopPanel()=> storeAnim.PlayStoreAnim(shopPanel);
           
        private void ApplicationQuit()=> Application.Quit();

        private void FacebookButton() => Application.OpenURL("https://www.facebook.com/SilentThieves/");

        private void TwitterButton() => Application.OpenURL("https://twitter.com/lukassking");
        
        
    }

}