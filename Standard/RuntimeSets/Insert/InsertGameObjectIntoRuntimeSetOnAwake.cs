using CyberneticStudios.SOFramework;
using UnityEngine;

namespace CyberneticStudios.SOFramework
{
    public class InsertGameObjectIntoRuntimeSetOnAwake : MonoBehaviour
    {
        [SerializeField] private GameObjectRuntimeSet _runtimeSet;

        private void Awake()
        {
            _runtimeSet.Add(gameObject);
        }
    }
}