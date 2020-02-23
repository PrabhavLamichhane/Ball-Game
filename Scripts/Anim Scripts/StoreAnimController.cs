using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LukasScripts
{
    public class StoreAnimController : MonoBehaviour
    {
        private Animator _anim;

        [SerializeField]
        private float timer = 1.5f;

        [SerializeField]
        private float uITimer = 1.1f;

        [SerializeField]
        private GameObject titleTxt;

        private void Awake()
        {
            _anim = GetComponent<Animator>();
        }

        public void PlayStoreAnim(GameObject shopPanel)
        {
            StartCoroutine(PlayAnim(timer,uITimer,shopPanel));
        }

        private IEnumerator PlayAnim(float t,float ui_T, GameObject shopPanel)
        {
            yield return new WaitForSeconds(t);
            _anim.Play(TagManager.Store_Anim);
            titleTxt.SetActive(false);
            yield return new WaitForSeconds(ui_T);
            shopPanel.SetActive(true);
        }

        public void CloseStore(float t, GameObject shopPanel)
        {
            StartCoroutine(CloseStoreAnim(t, shopPanel));
        }

        private IEnumerator CloseStoreAnim(float t, GameObject shopPanel)
        {
            yield return new WaitForSeconds(t);
            shopPanel.SetActive(false);
            _anim.Play(TagManager.Close_Anim);
            yield return new WaitForSeconds(1);
            titleTxt.SetActive(true);
        }

    }

}