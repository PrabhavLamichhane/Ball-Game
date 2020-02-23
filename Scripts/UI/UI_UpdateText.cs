using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace LukasScripts.UI
{
    public class UI_UpdateText : MonoBehaviour
    {
        public Text target;

        public StringVar stringVar;
        public IntVar intVar;

        private void OnEnable()
        {
            if (target == null)
                target = target = GetComponentInChildren<Text>();
        }


        public void UpdateTextFromString(string s)
        {
            target.text = s;
        }

        public void UpdateIntFromVariable()
        {
            target.text = intVar.value.ToString();
        }

        public void UpdateFromInt(int v)
        {
            target.text = v.ToString();
        }
    }

}