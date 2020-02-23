using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace LukasScripts
{
    public class Spike : MonoBehaviour
    {
        public delegate void onRestart();
        public static event onRestart restartEvent;

        public GameObject explosionFX;
        private SoundManager _sound;
        private SaveManager saveManager;
      

        public delegate void OnCMShake();
        public static event OnCMShake OnCameraShake;

        private void Start()
        {
            saveManager = SaveManager.instance;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(TagManager.Player))
            {
                StartCoroutine(WaitBeforeDestroy(other));
            }
        }


        private IEnumerator WaitBeforeDestroy(Collider c)
        {
            OnCameraShake?.Invoke();
            explosionFX.SetActive(true);
            c.gameObject.SetActive(false);
            yield return new WaitForSeconds(0.6f);

            if (saveManager == null)
                saveManager = SaveManager.instance;

            saveManager.SaveData();


            if (SoundManager.instance == null)
            {
                _sound = FindObjectOfType<SoundManager>();
                _sound.PlayImpactSound();
            }
            else
                SoundManager.instance.PlayImpactSound();


            restartEvent?.Invoke();

            gameObject.SetActive(false);

          
         //   GameManager.instance.ReloadGame();
        }

      
    }

}