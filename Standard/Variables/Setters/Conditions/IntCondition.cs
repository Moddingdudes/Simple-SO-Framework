using System;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.Events;

namespace CyberneticStudios.SOFramework
{
    /// <summary>
    /// A condition for an integer, which invokes a unity event when the condition is true upon the set variable changing
    /// </summary>
    public class IntCondition : MonoBehaviour
    {
        private enum ComparisonTypes
        {
            LESS_THAN,
            LESS_THAN_OR_EQUAL,
            EQUAL_TO,
            GREATER_THAN_OR_EQUAL,
            GREATHER_THAN,
            NOT_EQUAL
        }

        [SerializeField] private IntVariable listeningInt;
        [SerializeField] private ComparisonTypes comparisonType;
        [SerializeField] private IntReference comparerInt;
        [SerializeField] private int comparerIntOffset; //Offsets the numerical value by this amount
        [SerializeField] private UnityEvent<int> OnValueChangedAndConditionMet;
        [SerializeField] private UnityEvent<int> OnValueChangedAndConditionNotMet;

        private void Start()
        {
            listeningInt.OnChanged += OnListeningIntChanged;
        }

        private void OnDestroy()
        {
            listeningInt.OnChanged -= OnListeningIntChanged;
        }

        private void OnListeningIntChanged(int newValue)
        {
            switch (comparisonType)
            {
                case ComparisonTypes.LESS_THAN:
                    if (newValue < comparerInt.Value + comparerIntOffset)
                    {
                        OnValueChangedAndConditionMet?.Invoke(newValue);
                    }
                    else
                    {
                        OnValueChangedAndConditionNotMet?.Invoke(newValue);
                    }
                    break;
                case ComparisonTypes.LESS_THAN_OR_EQUAL:
                    if (newValue <= comparerInt.Value + comparerIntOffset)
                    {
                        OnValueChangedAndConditionMet?.Invoke(newValue);
                    }
                    else
                    {
                        OnValueChangedAndConditionNotMet?.Invoke(newValue);
                    }
                    break;
                case ComparisonTypes.EQUAL_TO:
                    if (newValue == comparerInt.Value + comparerIntOffset)
                    {
                        OnValueChangedAndConditionMet?.Invoke(newValue);
                    }
                    else
                    {
                        OnValueChangedAndConditionNotMet?.Invoke(newValue);
                    }
                    break;
                case ComparisonTypes.GREATHER_THAN:
                    if (newValue > comparerInt.Value + comparerIntOffset)
                    {
                        OnValueChangedAndConditionMet?.Invoke(newValue);
                    }
                    else
                    {
                        OnValueChangedAndConditionNotMet?.Invoke(newValue);
                    }
                    break;
                case ComparisonTypes.GREATER_THAN_OR_EQUAL:
                    if (newValue >= comparerInt.Value + comparerIntOffset)
                    {
                        OnValueChangedAndConditionMet?.Invoke(newValue);
                    }
                    else
                    {
                        OnValueChangedAndConditionNotMet?.Invoke(newValue);
                    }
                    break;
                case ComparisonTypes.NOT_EQUAL:
                    if (newValue != comparerInt.Value + comparerIntOffset)
                    {
                        OnValueChangedAndConditionMet?.Invoke(newValue);
                    }
                    else
                    {
                        OnValueChangedAndConditionNotMet?.Invoke(newValue);
                    }
                    break;
            }
        }
    }
}