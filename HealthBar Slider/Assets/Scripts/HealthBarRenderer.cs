using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HealthBarRenderer : MonoBehaviour
{
    [SerializeField] private float _damageValue = 10;
    [SerializeField] private float _changeSpeed = 10;

    private Slider _healthSlider;

    private float _target;
    private float _currentVelocity = 0;

    private void Start()
    {
        _healthSlider = GetComponent<Slider>();
 
        _target = _healthSlider.value;
    }

    private void FixedUpdate()
    {
        RenderHealth();
    }

    public void ReduceHealthRenderer()
    {
        _target = _healthSlider.value - _damageValue;
    }

    public void IncreaseHealthRenderer()
    {
        _target = _healthSlider.value + _damageValue;
    }

    private void RenderHealth()
    {
        float currentValue = Mathf.SmoothDamp(_healthSlider.value, _target, ref _currentVelocity, _changeSpeed * Time.deltaTime);
        _healthSlider.value = currentValue;
    }
}