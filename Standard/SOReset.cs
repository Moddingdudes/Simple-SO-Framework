using UnityEngine;

namespace CyberneticStudios.SOFramework
{
    /// <summary>
    /// A utility to reset Scriptable Object data utilizing MonoBehaviour callbacks
    /// </summary>
    public class SOReset : MonoBehaviour
    {
        //This setup is far from ideal considering it adds a GameObject dependency in-scene, though it is the only solution as of right now.
        public static System.Action OnStart;

        void Start()
        {
            OnStart?.Invoke();
        }
    }
}