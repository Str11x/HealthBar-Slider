using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int _maxHealth;
    [SerializeField] private HealthBarRenderer _renderer;
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
        _renderer.ReduceHealthRenderer();

        _currentHealth -= 10;         
    }

    private void Recover()
    {
        _renderer.IncreaseHealthRenderer();

        _currentHealth += 10;
    }
}