using UnityEngine;
using UnityEngine.Events;

namespace CyberneticStudios.SOFramework
{
    /// <summary>
    /// Base class of all Event Listeners. Event listeners listen in on Event Channels for editor responses
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class EventListener<T> : MonoBehaviour
    {
        [System.Serializable]
        public class Event : UnityEvent<T>
        {
        }
        public EventChannelSO<T> GameEvent;
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

        public void Respond(T value)
        {
            if (OnEventRaised == null)
            {
                return;
            }
            OnEventRaised.Invoke(value);
        }
    }
}