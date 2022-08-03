using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HealthBar : MonoBehaviour
{
    [SerializeField] private Health _health;
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

    public void UpdateHealthValue()
    {
        _target = _health.CurrentHealth;

        if (_changeHealthValue != null)
            StopCoroutine(_changeHealthValue);

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