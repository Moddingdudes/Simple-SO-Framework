using UnityEngine;
using UnityEngine.Events;

namespace CyberneticStudios.SOFramework
{
    public class VoidEventListener : MonoBehaviour
    {
        [System.Serializable]
        public class Event : UnityEvent
        {
        }
        public VoidEventChannelSO GameEvent;
        public Event OnEventRaised;

        private void OnEnable()
        {
            //Check if the event exists to avoid errors
            if (GameEvent == null)
            {
                return;
            }
            GameEvent.OnEventRaised += Respond;
        }

        private void OnDisable()
        {
            if (GameEvent == null)
            {
                return;
            }
            GameEvent.OnEventRaised -= Respond;
        }

        public void Respond()
        {
            if (OnEventRaised == null)
            {
                return;
            }
            OnEventRaised.Invoke();
        }
    }
}