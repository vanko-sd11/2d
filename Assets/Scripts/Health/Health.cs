using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField, Min(1)] private float _maxHealth = 100f;
    [SerializeField] private float _currentHealth = 100f;

    public event Action<float, float> OnChanged;
    public event Action Died;

    private void Start()
    {
        OnChanged?.Invoke(_currentHealth, _maxHealth);
    }

    public void Heal(float amount)
    {
        _currentHealth = Mathf.Min(_currentHealth + amount, _maxHealth);
        OnChanged?.Invoke(_currentHealth, _maxHealth);
    }

    public void TakeDamage(float damage)
    {
        if (_currentHealth <= 0)
        {
            return;
        }

        _currentHealth = Mathf.Max(_currentHealth - damage, 0);
        OnChanged?.Invoke(_currentHealth, _maxHealth);

        if (_currentHealth == 0)
        {
            Died?.Invoke();
        }
    }
}
