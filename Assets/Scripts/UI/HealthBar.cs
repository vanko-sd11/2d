using System;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image _healthBar;
    [SerializeField] private Health _health;

    private void OnEnable()
    {
        _health.OnChanged += OnHealthChanged;
    }
    private void OnDisable()
    {
        _health.OnChanged -= OnHealthChanged;
    }

    private void OnHealthChanged(float current, float max)
    {
        _healthBar.fillAmount = current / max;
    }
