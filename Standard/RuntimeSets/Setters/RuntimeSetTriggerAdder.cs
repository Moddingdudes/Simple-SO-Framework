using System;
using System.Collections.Generic;
using UnityEngine;

namespace CyberneticStudios.SOFramework
{
    /// <summary>
    /// Adds to runtime sets upon collider trigger enter
    /// </summary>
    /// <typeparam name="T">The type of runtime set</typeparam>
    public class RuntimeSetTriggerAdder<T> : MonoBehaviour
    {
        public enum TagFilterType { NO_FILTER, ALLOWED, DISALLOWED }
        [Header("References")]
        [SerializeField] protected RuntimeSet<T> runtimeSet;
        [SerializeField] protected List<IntVariable> countListeners = new List<IntVariable>(); //When an item is appended, each int variable in the array will be increased by one and vise versa for element removal
        [Header("Filters")]
        [SerializeField] protected LayerMask layerMask;
        [SerializeField] protected TagFilterType tagFilterType;
        [SerializeField] protected List<string> tagFilter;

        protected virtual void OnTriggerEnter(Collider collider)
        {
            if (ColliderIsValid(collider))
            {
                if (collider.TryGetComponent(out T type))
                {
                    //Only add it if the type exists
                    runtimeSet.Add(type);

                    foreach (IntVariable variable in countListeners)
                    {
                        variable.ApplyChange(1);
                    }
                }
            }
        }

        protected virtual void OnTriggerExit(Collider collider)
        {
            if (ColliderIsValid(collider))
            {
                runtimeSet.Remove(collider.GetComponent<T>());

                foreach (IntVariable variable in countListeners)
                {
                    variable.ApplyChange(-1);
                }
            }
        }

        protected virtual bool ColliderIsValid(Collider collider)
        {
            //Check layer
            //Bit-wise operation to make it easy
            //Given collider.gameObejct.layer = 2, 1 << 2 = 0100 and if withAnyLayer = 1110, then 0100 & 1110 = 0100 which == 0, therefore it is not permitted
            if (((1 << collider.gameObject.layer) & layerMask.value) == 0) return false;

            switch (tagFilterType)
            {
                case TagFilterType.NO_FILTER:
                    //It's unused, so just break
                    break;
                case TagFilterType.ALLOWED:
                    //Treat tag list as a whitelist

                    if (!tagFilter.Contains(collider.tag)) return false;
                    break;
                case TagFilterType.DISALLOWED:
                    //Treat tag list as a blacklist

                    if (tagFilter.Contains(collider.tag)) return false;
                    break;
            }

            return true;
        }
    }
}