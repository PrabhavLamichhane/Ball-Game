using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LukasScripts
{
    public class SwitchMainMenuBall : MonoBehaviour
    {
        public Store Store;
        public BallSelector ballSelector;

        [SerializeField]
        private GameObject[] balls;

        private GameObject _currentBall = null;

        private void Start()
        {
            SelectSavedBall();
        }

        private void SelectSavedBall()
        {


            if (ballSelector.selector == 0)
            {
                _currentBall = balls[0];
                _currentBall.SetActive(true);
            }
            else if (ballSelector.selector == 1)
            {
                _currentBall = balls[1];
                _currentBall.SetActive(true);
            }
            else if (ballSelector.selector == 2)
            {
                _currentBall = balls[2];
                _currentBall.SetActive(true);
            }
            else if(ballSelector.selector == 3)
            {
                _currentBall = balls[3];
                _currentBall.SetActive(true);
            }
            else if(ballSelector.selector == 4)
            {
                _currentBall = balls[4];
                _currentBall.SetActive(true);
            }
        }


        private void Update()
        {

            if (Store.hasSelected)
            {

                if (Store._ballCounter == 0)
                {
                    _currentBall.SetActive(false);
                    balls[0].SetActive(true);
                    _currentBall = balls[0];
                }
                else if (Store._ballCounter == 1)
                {
                    _currentBall.SetActive(false);
                    balls[1].SetActive(true);
                    _currentBall = balls[1];
                }
                else if (Store._ballCounter == 2)
                {
                    _currentBall.SetActive(false);
                    balls[2].SetActive(true);
                    _currentBall = balls[2];
                }
                else if(Store._ballCounter == 3)
                {
                    _currentBall.SetActive(false);
                    balls[3].SetActive(true);
                    _currentBall = balls[3];
                }
                else if(Store._ballCounter == 4)
                {
                    _currentBall.SetActive(false);
                    balls[4].SetActive(true);
                    _currentBall = balls[4];
                }
            }
        }


    }
 }

