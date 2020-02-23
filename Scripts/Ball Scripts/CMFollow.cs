using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

namespace LukasScripts
{

    public class CMFollow : MonoBehaviour
    {
        private CinemachineVirtualCamera _virtualCamera;
        private Transform _target;

        private void Awake()=> _virtualCamera = GetComponent<CinemachineVirtualCamera>();
        
        private void Start()
        {
            _target = GameObject.FindGameObjectWithTag(TagManager.Player).transform;
            _virtualCamera.Follow = _target;
        }
    }

}