using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float _maxHealth;
    [SerializeField] private int _changeHealthValue = 10;

    private float _minHealth = 0;
    public float CurrentHealth { get; private set; }

    public event Action ChangedAmountOfHealth;

    private void Start()
    {
        CurrentHealth = _maxHealth;
    }

    public void TakeDamage()
    {
        CurrentHealth = Mathf.Clamp(CurrentHealth - _changeHealthValue, _minHealth, _maxHealth);

        ChangedAmountOfHealth?.Invoke();
    }

    public void Recover()
    {
        CurrentHealth = Mathf.Clamp(CurrentHealth + _changeHealthValue, _minHealth, _maxHealth);

        ChangedAmountOfHealth?.Invoke();
    }
}