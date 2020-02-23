using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LukasScripts
{
    public class PlatformSpawner : MonoBehaviour
    {
        [SerializeField]
        private GameObject[] platformPrefabs;
        [SerializeField]
        [Header("The Dist between platforms on Z axis")]
        private float _distanceZ = 2.55f;
        [SerializeField]
        private int platformAmmount = 5;

        private GameObject _newPlatform = null;
        private Transform _playerPos;
        [Tooltip("this  num will help us to calculate the dist between cur platform and spawned platform to create gap ")]
        [SerializeField]
        private float _tileLength = 5f;
        private List<GameObject> _platformPool = new List<GameObject>();

        [HideInInspector]
        public bool _hasSpawnedFirstPlatforms = false;


        public delegate void EnableSpikesCoins();
        public static event EnableSpikesCoins enablePlatformScript;


        private void Awake()
        {
            GeneratePool();
        }

        private void Start()
        {
            _playerPos = GameObject.FindGameObjectWithTag(TagManager.Player).transform;
          
            //CreatePlatforms(platformAmmount);
        }

        private void Update()
        {
           
            if (_playerPos.transform.position.z > (_distanceZ - (platformAmmount * _tileLength)))
            {
                GameObject p = RecyclePlatforms();
                p.transform.parent = transform;
            }
          
        }

        #region Testing Without Obj Pooling
        void CreatePlatforms(int index = -1)
        {
            _newPlatform = Instantiate(platformPrefabs[1] as GameObject);
            _newPlatform.transform.parent = transform;
            _newPlatform.transform.position = Vector3.forward * _distanceZ;
            _distanceZ += 2.8f;
            _newPlatform.SetActive(true);

            _platformPool.Add(_newPlatform);
            _hasSpawnedFirstPlatforms = true;

        }

        #endregion

        private void GeneratePool()
        {
            _platformPool = GeneratePlatforms(platformAmmount);
            _hasSpawnedFirstPlatforms = true;
        }

        private List<GameObject> GeneratePlatforms(int index)
        {

            for (int i = 0; i < index; i++)
            {
                _newPlatform = Instantiate(platformPrefabs[0]);
                _newPlatform.transform.parent = transform;
                _newPlatform.SetActive(true);
                _newPlatform.transform.position = Vector3.forward * _distanceZ;
                _distanceZ += _tileLength;
            }

          
            return _platformPool;
        }

        public GameObject RecyclePlatforms()
        {
            foreach (GameObject p in _platformPool)
            {
                if (p.activeInHierarchy == false)
                {

                    p.SetActive(true);
                    p.transform.position = Vector3.forward * _distanceZ;
                    _distanceZ += _tileLength;
                    return p;
                }
            }

            // if we need additional platform in case we ran out of platforms form recycling 
            // then spawn new one and addit to the list 
            GameObject additionalP = Instantiate(platformPrefabs[0]);
            additionalP.transform.parent = transform;
            additionalP.transform.position = Vector3.forward * _distanceZ;
            _distanceZ += _tileLength;
            _platformPool.Add(additionalP);

            return additionalP;
        }



    }

}