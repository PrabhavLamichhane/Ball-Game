using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//DEVELOPER : LUKAS TOMASEK

//ALL RIGHTS RESERVED


namespace LukasScripts{

	public class Intro : MonoBehaviour
   	{
        private Animator _anim;
        [SerializeField]
        private float timer = 0.5f;

        [SerializeField]
        private GameObject animObj;

        [SerializeField]
        private PlayerReferences playerReferences;

        private SaveManager saveManager;


        private void Awake()
        {
            _anim = GetComponentInChildren<Animator>();
        }

        private void Start()
        {
            saveManager = SaveManager.instance;

            if (playerReferences.onIntroPlayed.value == false)
                StartCoroutine(PlayIntro());
            
          
        }

        private IEnumerator PlayIntro()
        {
            yield return new WaitForSeconds(0.5f);
            animObj.SetActive(true);
            _anim.Play(TagManager.Intro_Anim);
            yield return new WaitForSeconds(timer);
            
            playerReferences.onIntroPlayed.value = true;
            saveManager.SaveData();
          

            animObj.SetActive(false);
            enabled = false;
        }

    }

}