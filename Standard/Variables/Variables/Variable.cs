using UnityEngine;

namespace CyberneticStudios.SOFramework
{
    public abstract class Variable<T> : ScriptableObject
    {

#if UNITY_EDITOR
        [Multiline]
        public string DeveloperDescription = "";
#endif

        public System.Action<T> OnChanged;

        [SerializeField] private T value;
        [SerializeField] private bool resetBeforePlay = false;
        [SerializeField] private DebugInformation debugInformation;

        private void OnEnable()
        {
            if (resetBeforePlay)
                ResetVariable();
        }

        public void ResetVariable()
        {
            value = default(T);
        }

        public T Value
        {
            get => value;
            set
            {
                this.value = value;

                OnChanged?.Invoke(value);

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
}