using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int _maxHealth;
    [SerializeField] private int _changeHealthValue = 10;

    private int _minHealth = 0;
    public int CurrentHealth { get; private set; }

    private void Start()
    {
        CurrentHealth = _maxHealth;
    }

    public void TakeDamage()
    {
        if(CurrentHealth != _minHealth)
            CurrentHealth -= _changeHealthValue;         
    }

    public void Recover()
    {
        if (CurrentHealth != _maxHealth)
            CurrentHealth += _changeHealthValue;
    }
}