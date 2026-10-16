using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private float _maxHealth = 100f;
    [SerializeField]private float _currentHealth = 100f;
    [SerializeField] private Image _healthBar;
    [SerializeField] private GameObject _overPanel;


    void Start()
    {
        _overPanel.SetActive(false);
        Bar();
    }


    void Bar()
    {
        _healthBar.fillAmount  = _currentHealth / _maxHealth ;
    }

    public void Heal(float amount)
    {
        _currentHealth = _currentHealth + amount;
        if( _currentHealth > _maxHealth)
        {
            _currentHealth = _maxHealth;
        }
        Bar();
    }
    public void TakeDamage(float damage)
    {
        _currentHealth = _currentHealth - damage;
        if(_currentHealth < 0)
        {
            _currentHealth = 0;
        }
        Bar();

        if(_currentHealth <= 0)
        {
            Die();
        }


    }
    void Die()
    {
        _overPanel.SetActive(true);
        Time.timeScale = 0f;
    }
}
