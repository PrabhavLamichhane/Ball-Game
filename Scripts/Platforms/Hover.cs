using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LukasScripts
{
    public class Hover : MonoBehaviour
    {
        [SerializeField]
        private float speed = 2;
        private float _startY;



        private void Start()
        {
            _startY = transform.position.y;
        }
        private void Update()
        {
            Vector3 position = transform.position;
            position = new Vector3(position.x, _startY + Mathf.Sin(Time.time * speed) * 0.5f, position.z);

            transform.position = position;
        }
    }

}