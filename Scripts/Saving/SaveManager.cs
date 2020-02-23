using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//DEVELOPER : LUKAS TOMASEK

//ALL RIGHTS RESERVED


namespace LukasScripts{



	public class SaveManager : MonoBehaviour
	{
        public static SaveManager instance;

        public PlayerReferences playerReferences;


        private void Awake()
        {
            if(instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void Start()
        {
             LoadData();
           
        }

    
        public void SaveData()
        {
            SaveSystem.SaveData(this);
        }

        public void LoadData()
        {
            PlayerData data = SaveSystem.LoadData();
            playerReferences.curCoinCount.value = data.cointCount;
            playerReferences.boughtBall2 = data.boughBall2;
            playerReferences.boughtBall3 = data.boughBall3;
            playerReferences.boughtBall4 = data.boughBall4;
            playerReferences.boughtBall5 = data.boughBall5;
            playerReferences.onIntroPlayed.value = data.playedFirstTime;

        }

    }

}