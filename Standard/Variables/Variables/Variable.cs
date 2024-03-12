using System;
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
        [SerializeField] private T defaultValue;
        [SerializeField] private DebugInformation debugInformation;

        private void OnEnable()
        {
            SOCallback.OnAwakeCallback += OnAwakeCallback;
        }

        private void OnDisable()
        {
            SOCallback.OnAwakeCallback -= OnAwakeCallback;
        }

        private void OnAwakeCallback()
        {
            //Check if we should reset
            if (resetBeforePlay)
                ResetVariable();
        }

        public void ResetVariable()
        {
            value = defaultValue;
        }

        public T Value
        {
            get => value;
            set
            {
                SetValue(value);

                OnChanged?.Invoke(value);
            }
        }

        public void SetValueSilent(T value)
        {
            SetValue(value);
        }

        private void SetValue(T value)
        {
            this.value = value;

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
