using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LukasScripts
{
    public class SoundManager : MonoBehaviour
    {

        public static SoundManager instance;


        [SerializeField]
        private AudioSource soundTrackAudio;

        [SerializeField]
        private AudioSource playerAudio;

        [SerializeField]
        private AudioSource gemAudio;

        [SerializeField]
        private AudioSource landAudio;

        [SerializeField]
        private AudioSource _audio;

        [SerializeField]
        private AudioClip impactClip;

        [SerializeField]
        private AudioClip gameOverClip;

        [SerializeField]
        private AudioClip[] coinPickUpClips;

        [SerializeField]
        private AudioClip jumpClip;

        [SerializeField]
        private AudioClip landedClip;

        [SerializeField]
        private AudioClip[] bgClips;

        private bool _isMute = false;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(this.gameObject);
            }
            else
            {
                Destroy(this.gameObject);
               
            }

            
        }

        private void Start()
        {
            if(_audio == null)
            _audio = GetComponent<AudioSource>();


            PlayRandomSoundTrack();
        }


        public void SoundPreferences()
        {
            // prevously this function was called in update

            if (_isMute)
            {
                playerAudio.volume = 0;
                gemAudio.volume = 0;
                landAudio.volume = 0;
                _audio.volume = 0;
                soundTrackAudio.volume = 0;

            }
            else if (!_isMute)
            {
                playerAudio.volume = 1;
                gemAudio.volume = 1;
                landAudio.volume = 1;
                _audio.volume = 0.5f;
                soundTrackAudio.volume = 0.2f;
            }
        }


        public void PlayJumpSound()
        {
            playerAudio.clip = jumpClip;
            playerAudio.Play();
        }

        public void PlayImpactSound()
        {
            _audio.clip = impactClip;
            _audio.Play();
        }

        public void PlayLandedSound()
        {
            landAudio.clip = landedClip;
            landAudio.Play();
        }

        public void PlayGameOverClip()
        {
            gemAudio.clip = gameOverClip;
            gemAudio.Play();
        }

        public void PlayCoinPickUpSound()
        {
            _audio.clip = coinPickUpClips[Random.Range(0, coinPickUpClips.Length)];
            _audio.Play();
        }

        private void PlayRandomSoundTrack()
        {
            soundTrackAudio.clip = bgClips[Random.Range(0, bgClips.Length)];
            soundTrackAudio.Play();
        }


        public bool IsMute
        {
            get { return _isMute; }
            set { _isMute = value; }
        }


        private void OnDisable()
        {
            instance = null;
        }

    }

}