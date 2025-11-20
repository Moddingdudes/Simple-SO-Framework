using CyberneticStudios.SOFramework;
using UnityEngine;

namespace CyberneticStudios.SOFramework
{
    [DefaultExecutionOrder(-100)]
    public class SetGameObjectVariableOnStart : MonoBehaviour
    {
        [SerializeField] private GameObjectVariable _variableToSet;

        private void Start()
        {
            _variableToSet.Value = gameObject;
        }
    }
}