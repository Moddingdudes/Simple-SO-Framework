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
#if UNITY_EDITOR
        [Multiline]
        public string DeveloperDescription = "";
#endif

        public List<T> Items = new List<T>();

        [SerializeField] private bool clearOnStart = false;

        private bool locked;

        public System.Action<T> OnItemAdded;
        public System.Action<T> OnItemRemoved;

        public bool Locked => locked;

        private void OnEnable()
        {
            SOCallback.OnStartCallback += OnStartCallback;
        }

        private void OnDisable()
        {
            SOCallback.OnStartCallback -= OnStartCallback;
        }

        private void OnStartCallback()
        {
            //Check if we should clear
            if (clearOnStart)
            {
                Clear();

                locked = false;
            }
        }

        public void Clear()
        {
            Items.Clear();
        }

        public void Lock()
        {
            locked = true;
        }

        public void Unlock()
        {
            locked = false;
        }

        public void Add(T item)
        {
            if (locked) return;

            if (!Items.Contains(item))
            {
                Items.Add(item);

                OnItemAdded?.Invoke(item);
            }
        }

        public void Remove(T item)
        {
            if (locked) return;

            if (Items.Contains(item))
            {
                Items.Remove(item);

                OnItemRemoved?.Invoke(item);
            }
        }
    }
}