using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace LukasScripts
{
    public class GameEventListener : MonoBehaviour
    {
        public GameEvents gameEvent;
        public UnityEvent response;

        private void OnEnable()=>gameEvent.Resgister(this);
        
        private void OnDisable()=> gameEvent.Unregister(this);
        
        public void Response()=> response.Invoke();
        
    }

}