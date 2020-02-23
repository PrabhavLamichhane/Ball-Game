using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LukasScripts
{
    [CreateAssetMenu(menuName ="Player Refs")]
    public class PlayerReferences : ScriptableObject
    {
        [Header("UI")]
        public IntVar curCoinCount;
        public StringVar id;
        public bool boughtBall2;
        public bool boughtBall3;
        public bool boughtBall4;
        public bool boughtBall5;
        public BoolVar onIntroPlayed;
        public GameEvents e_Update_UI;

        public void Init()=>curCoinCount.value = 0;
        
    }


}