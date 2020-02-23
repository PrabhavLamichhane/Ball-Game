using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LukasScripts
{
    [CreateAssetMenu(menuName ="Events")]
    public class GameEvents : ScriptableObject
    {
        private List<GameEventListener> listeners = new List<GameEventListener>();

        public void Resgister(GameEventListener listener)=>listeners.Add(listener);
       
        public void Unregister(GameEventListener listener)=> listeners.Remove(listener);
       
        public void Raise()
        {
            for (int i = 0; i < listeners.Count; i++)
            {
                listeners[i].Response();
            }
        }
    }

}