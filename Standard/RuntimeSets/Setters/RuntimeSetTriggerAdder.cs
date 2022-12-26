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
        [SerializeField] private RuntimeSet<T> runtimeSet;
        [Header("Filters")]
        [SerializeField] private LayerMask layerMask;
        [SerializeField] private TagFilterType tagFilterType;
        [SerializeField] private List<string> tagFilter;

        protected virtual void OnTriggerEnter(Collider collider)
        {
            if (ColliderIsValid(collider))
            {
                runtimeSet.Add(collider.GetComponent<T>());
            }
        }

        protected virtual void OnTriggerExit(Collider collider)
        {
            runtimeSet.Remove(collider.GetComponent<T>());
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