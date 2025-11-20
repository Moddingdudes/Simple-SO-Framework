using UnityEngine;
using UnityEngine.Events;

namespace CyberneticStudios.SOFramework
{
    public class VoidEventListener : MonoBehaviour
    {
        [System.Serializable] public class UnityGameEvent : UnityEvent { }

        [SerializeField] VoidEvent GameEvent;
        [SerializeField] UnityGameEvent Response;

        private void OnEnable()
        {
            //Check if the event exists to avoid errors
            _ = GameEvent ?? throw new MissingReferenceException();


            GameEvent.OnEventRaised += OnResponseEventRaised;
        }

        private void OnDisable()
        {
            _ = GameEvent ?? throw new MissingReferenceException();


            GameEvent.OnEventRaised -= OnResponseEventRaised;
        }

        public void OnResponseEventRaised()
        {
            _ = Response ?? throw new MissingReferenceException();

            Response.Invoke();
        }
    }
}