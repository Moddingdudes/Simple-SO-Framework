using CyberneticStudios.SOFramework;
using UnityEngine;

namespace CyberneticStudios
{
    public class GameObjectRuntimeSetTriggerAdder : RuntimeSetTriggerAdder<GameObject>
    {
        protected override void OnTriggerEnter(Collider collider)
        {
            //Override to run native gameObject call

            if (ColliderIsValid(collider))
            {
                runtimeSet.Add(collider.gameObject);
            }
        }

        protected override void OnTriggerExit(Collider collider)
        {
            //Override to run native gameObject call

            runtimeSet.Remove(collider.gameObject);
        }
    }
}