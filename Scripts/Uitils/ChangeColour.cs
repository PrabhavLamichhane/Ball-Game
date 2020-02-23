using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LukasScripts.Utils
{
    [RequireComponent(typeof(MeshRenderer))]
    public class ChangeColour : MonoBehaviour
    {
        public bool hasOneRenderer;


        private MeshRenderer[] _mesh;
        private MeshRenderer _meshRenderer;

        void Start()
        {

            if (hasOneRenderer)
            {
                _meshRenderer = GetComponent<MeshRenderer>();
                _meshRenderer.material.color = new Color(Random.value, Random.value, Random.value);
            }
            else
            {
                _mesh = GetComponentsInChildren<MeshRenderer>();

                foreach (MeshRenderer renderer in _mesh)
                    renderer.material.color = new Color(Random.value, Random.value, Random.value);
            }
        }

       
    }

}