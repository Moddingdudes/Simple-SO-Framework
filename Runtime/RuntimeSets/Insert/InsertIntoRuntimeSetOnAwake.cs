using CyberneticStudios.SOFramework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Inserts type T off of self object into runtime set on awake.
/// </summary>
public class InsertIntoRuntimeSetOnAwake<T> : MonoBehaviour where T : Object
{

    [SerializeField] private RuntimeSet<T> _runtimeSet;

    private void Awake()
    {
        _runtimeSet.Add(GetComponent<T>());
    }
}