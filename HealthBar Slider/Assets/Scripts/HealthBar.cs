using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HealthBar : MonoBehaviour
{
    [SerializeField] private float _damageValue = 10;
    [SerializeField] private float _changeSpeed = 10;

    private Slider _healthSlider;
    private Coroutine _changeHealthValue;

    private float _target;
    private float _currentVelocity = 0;

    private void Start()
    {
        _healthSlider = GetComponent<Slider>();
 
        _target = _healthSlider.value;
    }

    public void ReduceHealth()
    {
        if(_changeHealthValue != null)
            StopCoroutine(_changeHealthValue);

        _target = _healthSlider.value - _damageValue;
        _changeHealthValue = StartCoroutine(ChangeHealth());
    }

    public void IncreaseHealth()
    {
        if (_changeHealthValue != null)
            StopCoroutine(_changeHealthValue);

        _target = _healthSlider.value + _damageValue;
        _changeHealthValue = StartCoroutine(ChangeHealth());
    }

    private IEnumerator ChangeHealth()
    {
        while(_healthSlider.value != _target)
        {
            float currentValue = Mathf.SmoothDamp(_healthSlider.value, _target, ref _currentVelocity, _changeSpeed * Time.deltaTime);
            _healthSlider.value = currentValue;

            yield return new WaitForFixedUpdate();
        }
    }
}