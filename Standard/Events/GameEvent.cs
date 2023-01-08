using UnityEngine;

namespace CyberneticStudios.SOFramework
{
    /// <summary>
    /// Base class of all Event Channels. Event channels are scriptable objects that raise events and can be listened
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class GameEvent<T> : ScriptableObject
    {

#if UNITY_EDITOR
        [Multiline]
        public string DeveloperDescription = "";
#endif

        public System.Action<T> OnGameEventRaised;
        [SerializeField] DebugInformation debugInformation;

        public void RaiseEvent(T value)
        {
            OnGameEventRaised?.Invoke(value);

            if (debugInformation.debugEnabled)
            {
                //Debug information

                string debugMessage = debugInformation.debugMessage;

                if (debugInformation.includeData)
                    debugMessage += value;

                switch (debugInformation.debugLevel)
                {
                    case DebugInformation.DebugLevel.INFO:
                        Debug.Log(debugMessage);
                        break;
                    case DebugInformation.DebugLevel.WARNING:
                        Debug.LogWarning(debugMessage);
                        break;
                    case DebugInformation.DebugLevel.ERROR:
                        Debug.LogError(debugMessage);
                        break;
                }
            }
        }
    }
}