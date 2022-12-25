using System.Collections.Generic;
using UnityEngine;

namespace CyberneticStudios.SOFramework
{
    /// <summary>
    /// Dynamic set of data that can be set during editor-time and accessible by any script or prefab
    /// </summary>
    /// <typeparam name="T">The type the set is</typeparam>
    public abstract class RuntimeSet<T> : ScriptableObject
    {
        public List<T> Items = new List<T>();

        public void Add(T item)
        {
            if (!Items.Contains(item)) Items.Add(item);
        }

        public void Remove(T item)
        {
            if (Items.Contains(item)) Items.Remove(item);
        }
    }
}