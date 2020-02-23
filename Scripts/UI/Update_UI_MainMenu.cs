using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace LukasScripts.UI {


    public class Update_UI_MainMenu : MonoBehaviour
    {
        public PlayerReferences UI_references;

        [HideInInspector]
        public bool updateUI;

        private void Update()
        {
            UI_references.e_Update_UI.Raise();
        }

    }




}
