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
        if (CurrentHealth - _changeHealthValue >= _minHealth)
            CurrentHealth -= _changeHealthValue;
        else
            Debug.Log("YOU DIED");
    }

    public void Recover()
    {
        if (CurrentHealth + _changeHealthValue <= _maxHealth)
            CurrentHealth += _changeHealthValue;
        else
            Debug.Log("YOU HAVE FULL HP BAR");
    }
}