using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LukasScripts
{
    public class Coin : MonoBehaviour
    {
        public GameObject pickUpFX;
        public PlayerReferences player;

        [SerializeField]
        [Header("Set The value to 10")]
        private int points = 10;

        private ParticleSystem[] _particles;
        

    
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(TagManager.Player))
                StartCoroutine(OnDisableCoin());
                    
        }


        private IEnumerator OnDisableCoin()
        {
            yield return new WaitForSeconds(0.01f);
            pickUpFX.SetActive(true);

            if (SoundManager.instance == null)
                SoundManager.instance = FindObjectOfType<SoundManager>();

            SoundManager.instance.PlayCoinPickUpSound();

            yield return new WaitForSeconds(0.6f);
            player.curCoinCount.value += points;
            // updating ui through event
            player.e_Update_UI.Raise();
            SaveManager.instance.SaveData();
            gameObject.SetActive(false);
        }

    
    }

}