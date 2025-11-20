using CyberneticStudios.SOFramework;
using UnityEngine;

namespace CyberneticStudios.SOFramework
{
    /// <summary>
    /// Sets a scriptable object variable upon awake to local component of type T
    /// </summary>
    /// <typeparam name="T">Type of component to set the variable to</typeparam>
    [DefaultExecutionOrder(-100)]
    public class VariableAwakeSetter<T> : MonoBehaviour where T : Object
    {
        [SerializeField] private Variable<T> variableToSet;

        private void Awake()
        {
            variableToSet.Value = GetComponent<T>();
        }
    }
}