using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LukasScripts
{
    public class Rotate : MonoBehaviour
    {
        private int _speed = 1;
        private float angle;


        private void Update()
        {
            angle = (angle + _speed) % 360;
            transform.localRotation = Quaternion.Euler(0, 0, angle);
          
        }

    }

}