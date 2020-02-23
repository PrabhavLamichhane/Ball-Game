using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//DEVELOPER : LUKAS TOMASEK

//ALL RIGHTS RESERVED


namespace LukasScripts.Utils{

	public class KeyboardSwipe : MonoBehaviour
	{
        private BallMovement _ball;

        [SerializeField]
        private bool testMode = true;

        private void Awake()
        {
            _ball = GetComponent<BallMovement>();
        }


        private void Update()
        {
            if (!testMode)
                return;

            if (Input.GetKey(KeyCode.LeftArrow))
                _ball.LeftTap();

            if (Input.GetKey(KeyCode.RightArrow))
                _ball.RightTap();
        }
    }

}