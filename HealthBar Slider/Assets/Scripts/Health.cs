using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int _maxHealth;
    [SerializeField] private int _changeHealthValue = 10;
    [SerializeField] private HealthBar _healthBar;
    [SerializeField] private HitButton _hitButton;
    [SerializeField] private HealButton _healButton;

    private int _currentHealth;

    private void Start()
    {
        _hitButton.Hitted += TakeDamage;
        _healButton.Healed += Recover;

        _currentHealth = _maxHealth;
    }

    private void OnDisable()
    {
        _hitButton.Hitted -= TakeDamage;
        _healButton.Healed -= Recover;
    }

    private void TakeDamage()
    {
        _healthBar.ReduceHealth();

        _currentHealth -= _changeHealthValue;         
    }

    private void Recover()
    {
        _healthBar.IncreaseHealth();

        _currentHealth += _changeHealthValue;
    }
}