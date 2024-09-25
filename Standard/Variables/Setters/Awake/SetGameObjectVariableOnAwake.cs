using CyberneticStudios.SOFramework;
using UnityEngine;

namespace CyberneticStudios.SOFramework
{
    [DefaultExecutionOrder(-100)]
    public class SetGameObjectVariableOnAwake : MonoBehaviour
    {
        [SerializeField] private GameObjectVariable _variableToSet;

        private void Awake()
        {
            _variableToSet.Value = gameObject;
        }
    }
}