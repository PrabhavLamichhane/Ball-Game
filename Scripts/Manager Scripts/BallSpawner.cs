using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LukasScripts
{
    public class BallSpawner : MonoBehaviour
    {
        [SerializeField]
        private GameObject[] balls;

        [SerializeField]
        private BallSelector ballSelector;

        private Vector3 _spawnPos = new Vector3(0f, 0.997128f,2.1f);

        private void Awake()
        {
            SelectBallFromStore();
        }

        private void SelectBallFromStore()
        {
            if(ballSelector.selector == 0)
            {
                GameObject go = balls[0];
                Instantiate(go, _spawnPos,Quaternion.identity);
            }
            else if(ballSelector.selector == 1)
            {
                GameObject go = balls[1];
                Instantiate(go, _spawnPos, Quaternion.identity);
            }
            else if(ballSelector.selector == 2)
            {
                GameObject go = balls[2];
                Instantiate(go, _spawnPos, Quaternion.identity);
            }
            else if(ballSelector.selector == 3)
            {
                GameObject go = balls[3];
                Instantiate(go, _spawnPos, Quaternion.identity);
            }
            else if(ballSelector.selector == 4)
            {
                GameObject go = balls[4];
                Instantiate(go, _spawnPos, Quaternion.identity);
            }
            else
            {
                GameObject go = balls[0];
                Instantiate(go, _spawnPos, Quaternion.identity);
            }
        }


    }

}
