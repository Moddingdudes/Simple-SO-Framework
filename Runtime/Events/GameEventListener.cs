using UnityEngine;
using UnityEngine.Events;

namespace CyberneticStudios.SOFramework
{
    /// <summary>
    /// Base class of all Event Listeners. Event listeners listen in on Event Channels for editor responses
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class GameEventListener<T> : MonoBehaviour
    {
        // Generic Unity Event
        [System.Serializable] public class UnityGameEvent : UnityEvent<T> { }

        [SerializeField] GameEvent<T> GameEvent;
        [SerializeField] UnityGameEvent Response;

        private void OnEnable()
        {
            //Check if the event exists to avoid errors
            _ = GameEvent ?? throw new MissingReferenceException();

            GameEvent.OnGameEventRaised += OnResponseEventRaised;
        }

        private void OnDisable()
        {
            _ = GameEvent ?? throw new MissingReferenceException();

            GameEvent.OnGameEventRaised -= OnResponseEventRaised;
        }

        public void OnResponseEventRaised(T value)
        {
            //TODO: This doesn't appear to be thrown when the UnityEvent isn't set in the inspector and the event is fired
            _ = Response ?? throw new MissingReferenceException();

            Response.Invoke(value);
        }
    }

    /// <summary>
    /// Base class of all Event Listeners. Event listeners listen in on Event Channels for editor responses
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class GameEventListener<T1, T2> : MonoBehaviour
    {
        // Generic Unity Event
        [System.Serializable] public class UnityGameEvent : UnityEvent<T1, T2> { }

        [SerializeField] GameEvent<T1, T2> GameEvent;
        [SerializeField] UnityGameEvent Response;

        private void OnEnable()
        {
            //Check if the event exists to avoid errors
            _ = GameEvent ?? throw new MissingReferenceException();

            GameEvent.OnGameEventRaised += OnResponseEventRaised;
        }

        private void OnDisable()
        {
            _ = GameEvent ?? throw new MissingReferenceException();

            GameEvent.OnGameEventRaised -= OnResponseEventRaised;
        }

        public void OnResponseEventRaised(T1 valueOne, T2 valueTwo)
        {
            //TODO: This doesn't appear to be thrown when the UnityEvent isn't set in the inspector and the event is fired
            _ = Response ?? throw new MissingReferenceException();

            Response.Invoke(valueOne, valueTwo);
        }
    }
}