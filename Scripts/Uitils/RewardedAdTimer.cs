using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//DEVELOPER : LUKAS TOMASEK

//ALL RIGHTS RESERVED


namespace LukasScripts.Utils{

	public class RewardedAdTimer : MonoBehaviour
	{
        [SerializeField]
        [Range(2,10)]
        private float timerBeforeDisablingBtn =10 ;

        [SerializeField]
        private Image indicator;

        private RectTransform rect;

        [SerializeField]
        private GameManager gameManager;

        public bool canStartTimer { get; set; }

        private void Awake()
        {
            if (gameManager == null)
                gameManager = FindObjectOfType<GameManager>();

            if(indicator.enabled)
                indicator.enabled = false;
        }

        private void Update()
        {
            if (canStartTimer)
            {
                StartTimer();
               
            }
            
        }

        private void StartTimer()
        {
            indicator.enabled = true;
            timerBeforeDisablingBtn -= Time.deltaTime;
            indicator.fillAmount = timerBeforeDisablingBtn;

            if (timerBeforeDisablingBtn <= 0)
            {
                indicator.enabled = false;
                canStartTimer = false;
                timerBeforeDisablingBtn = 0;
                gameManager.TimerForRewardedAdFinished();
            }

        }

      

    }

}