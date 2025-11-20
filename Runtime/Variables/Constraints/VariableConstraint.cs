using UnityEngine;
using UnityEngine.Events;

namespace CyberneticStudios.SOFramework
{
    public class VariableConstraint<T> : MonoBehaviour
    {
        [SerializeField] private Variable<T> variable;
        [SerializeField] private UnityEvent<T> onValueSet;

        private void Start()
        {
            variable.OnChanged += OnValueChanged;

            OnValueChanged(variable.Value);
        }

        private void OnDestroy()
        {
            variable.OnChanged -= OnValueChanged;
        }

        private void OnValueChanged(T value)
        {
            onValueSet?.Invoke(value);
        }
    }
}