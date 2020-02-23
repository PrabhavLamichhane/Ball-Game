using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LukasScripts
{
    public class BallInput : MonoBehaviour
    {
        private float _midPoint;
        private BallMovement _ball;

        public PlayerReferences playerReferences;
      

        private void Start()
        {
            _ball = FindObjectOfType<BallMovement>();
          //  playerReferences.Init();
            _midPoint = Screen.width / 2;
            UpdateUI();
        }

        private void Update()
        {
            if(Input.touchCount > 0)
            {
                if (Input.GetTouch(0).position.x < _midPoint)
                   _ball.LeftTap();
                else
                    _ball.RightTap();
            }

           // UpdateUI();
        }

        private void UpdateUI()
        { 
             playerReferences.e_Update_UI.Raise();
        }
    
    }

}