using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//DEVELOPER : LUKAS TOMASEK

//ALL RIGHTS RESERVED


namespace LukasScripts{


    [System.Serializable]
	public class PlayerData
	{
        public int cointCount;
        public bool boughBall2;
        public bool boughBall3;
        public bool boughBall4;
        public bool boughBall5;
        public bool playedFirstTime;


        public PlayerData(SaveManager manager)
        {
            cointCount = manager.playerReferences.curCoinCount.value;
            boughBall2 = manager.playerReferences.boughtBall2;
            boughBall3 = manager.playerReferences.boughtBall3;
            boughBall4 = manager.playerReferences.boughtBall4;
            boughBall5 = manager.playerReferences.boughtBall5;
            playedFirstTime = manager.playerReferences.onIntroPlayed;
        }


    }

}