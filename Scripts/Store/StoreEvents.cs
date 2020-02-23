using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//DEVELOPER : LUKAS TOMASEK

//ALL RIGHTS RESERVED


namespace LukasScripts{


	public class StoreEvents : MonoBehaviour
	{
        [SerializeField]
        private GameEvents _buyEvent_1;
        [SerializeField]
        private GameEvents _buyEvent_2;
        [SerializeField]
        private GameEvents _buyEvent_3;
        [SerializeField]
        private GameEvents _buyEvent_4;

        [SerializeField][Header("Deafault = 1")]
        private float raiseDuration = 1f;
    
        public void RaiseBuyEvent2()
        {
            Invoke("WaitBeforeEvent1", raiseDuration);
        }

        private void WaitBeforeEvent1()
        {
            _buyEvent_1.Raise();
        }

        public void RaiseBuyEvent3()
        {
            Invoke("WaitBeforeEvent2", raiseDuration);
        }

        private void WaitBeforeEvent2()
        {
            _buyEvent_2.Raise();
        }

        public void RaiseBuyEvent4()
        {
            Invoke("WaitBeforeEvent3", raiseDuration);
        }

        private void WaitBeforeEvent3()
        {
            _buyEvent_3.Raise();
        }

        public void RaiseBuyEvent5()
        {
            Invoke("WaitBeforeEvent4", raiseDuration);
        }

        private void WaitBeforeEvent4()
        {
            _buyEvent_4.Raise();
        }
    }






}