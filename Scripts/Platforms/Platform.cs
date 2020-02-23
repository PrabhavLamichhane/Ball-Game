using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LukasScripts
{

    public class Platform : MonoBehaviour
    {
        private MeshRenderer _renderer;

        [SerializeField]
        private GameObject spikePrefab;

        [SerializeField]
        private GameObject coinPrefab;

        private int _spikeChance;
        private int _coinChance;

        private PlatformSpawner _spawner;
        private SoundManager _sound;

        [SerializeField]
        private ParticleSystem[] effects;

        private void Awake()
        {
            _sound = SoundManager.instance;
            _spawner = FindObjectOfType<PlatformSpawner>();
            // if this doesn't work put it back to on enable
            _renderer = GetComponent<MeshRenderer>();
        }

        private void OnEnable()
        {
                       
            // _renderer.material.color = Random.ColorHSV();
            _renderer.material.color = new Color(Random.value,Random.value,Random.value);

            if (!_spawner._hasSpawnedFirstPlatforms)
                return;

            _spikeChance = Random.Range(0, 50);
            _coinChance = Random.Range(0, 100);

            if (_spikeChance > 35)
            {
                spikePrefab.SetActive(true);
                spikePrefab.transform.position =
                    new Vector3(Random.Range(-0.35f, 0.35f), spikePrefab.transform.position.y, spikePrefab.transform.position.z);
            }

            if (_coinChance > 70)
            {
                coinPrefab.SetActive(true);
                coinPrefab.transform.position =
                   new Vector3(Random.Range(-0.35f, 0.35f), coinPrefab.transform.position.y, coinPrefab.transform.position.z);
            }

            // in case if spike and coin are both active then active only one 
            if (spikePrefab.activeInHierarchy && coinPrefab.activeInHierarchy)
            {
                int rand = Random.Range(0, 1);

                if (rand == 0)
                {
                    spikePrefab.SetActive(true);
                    coinPrefab.SetActive(false);
                }
                else if (rand == 1)
                {
                    coinPrefab.SetActive(true);
                    spikePrefab.SetActive(false);
                }
            }

           
        }

    

       
        private void OnCollisionExit(Collision collision)
        {
            if (collision.gameObject.CompareTag(TagManager.Player))
            {
                effects[1].Play();

                StartCoroutine(WaitBeforeDestroy());
            }
        }

        private IEnumerator WaitBeforeDestroy()
        {
            if (_sound == null)
                _sound = FindObjectOfType<SoundManager>();

            _sound.PlayLandedSound();

            yield return new WaitForSeconds(1.1f);
           
            gameObject.SetActive(false);
        }
       
    }

}