using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

namespace LukasScripts.Utils
{
    public class ShakeCamera : MonoBehaviour
    {
        [SerializeField]
        private CinemachineVirtualCamera virtualCamera;
        private CinemachineBasicMultiChannelPerlin _channelPerlin;


        private void Awake()
        {
            if (virtualCamera == null)
                virtualCamera = GameObject.Find("Virtual Camera").GetComponent<CinemachineVirtualCamera>();

            _channelPerlin = virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();   
        }

        private void OnEnable()
        {
            Spike.OnCameraShake += ShakeCam;
        }

        private void OnDisable()
        {
            Spike.OnCameraShake -= ShakeCam;
        }


        public void ShakeCam()
        {
            
            StartCoroutine(Shake(0.15f));
        }


        private IEnumerator Shake(float shakeTimer)
        {
            _channelPerlin.m_AmplitudeGain = 10f;
            _channelPerlin.m_FrequencyGain = 5f;

            yield return new WaitForEndOfFrame();

            _channelPerlin.m_AmplitudeGain = 0;
            _channelPerlin.m_FrequencyGain = 0;
        }

    }

}