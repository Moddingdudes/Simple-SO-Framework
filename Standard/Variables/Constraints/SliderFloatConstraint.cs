using CyberneticStudios.SOFramework;
using System;
using UnityEngine;
using UnityEngine.UI;

public class SliderFloatConstraint : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private FloatReference _value;
    [SerializeField] private FloatReference _mininum;
    [SerializeField] private FloatReference _maximum;

    private void Start()
    {
        _slider.minValue = _mininum.Value;
        _slider.maxValue = _maximum.Value;
        _slider.value = _value.Value;

        if (_value.Variable != null)
            _value.Variable.OnChanged += OnValueChanged;

        if (_mininum.Variable != null)
            _mininum.Variable.OnChanged += OnMinimumChanged;

        if (_maximum.Variable != null)
            _maximum.Variable.OnChanged += OnMaximumChanged;
    }

    private void OnDestroy()
    {
        if (_value.Variable != null)
            _value.Variable.OnChanged -= OnValueChanged;

        if (_mininum.Variable != null)
            _mininum.Variable.OnChanged -= OnMinimumChanged;

        if (_maximum.Variable != null)
            _maximum.Variable.OnChanged -= OnMaximumChanged;
    }

    private void OnValueChanged(float newValue)
    {
        _slider.value = newValue;
    }

    private void OnMinimumChanged(float newMinimum)
    {
        _slider.minValue = newMinimum;
    }

    private void OnMaximumChanged(float newMaximum)
    {
        _slider.maxValue = newMaximum;
    }
}
