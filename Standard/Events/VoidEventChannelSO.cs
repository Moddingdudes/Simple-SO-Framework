using UnityEngine;

namespace CyberneticStudios.SOFramework
{
    [CreateAssetMenu(menuName = AssetMenu.Events + "Void Event Channel")]
    public class VoidEventChannelSO : ScriptableObject
    {

#if UNITY_EDITOR
        [Multiline]
        public string DeveloperDescription = "";
#endif

        public System.Action OnEventRaised;
        [SerializeField] private DebugInformation debugInformation;

        public void RaiseEvent()
        {
            OnEventRaised?.Invoke();

            if (debugInformation.debugEnabled)
            {
                //Debug information

                string debugMessage = debugInformation.debugMessage;

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