using CyberneticStudios.SOFramework;
using UnityEngine;

namespace CyberneticStudios
{
    /// <summary>
    /// Sets a scriptable object variable upon start to local component of type T
    /// </summary>
    /// <typeparam name="T">Type of component to set the variable to</typeparam>
    public class VariableStartSetter<T> : MonoBehaviour
    {
        [SerializeField] private Variable<T> variableToSet;

        private void Start()
        {
            variableToSet.Value = GetComponent<T>();
        }
    }
}