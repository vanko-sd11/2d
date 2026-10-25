using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class DeathPanel : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private GameObject _panel;
    [SerializeField] private Button _restartButton;

    private void Awake()
    {
        _panel.SetActive(false);
    }

    private void OnEnable()
    {
        _health.Died += Show;
        _restartButton.onClick.AddListener(RestartGame);
    }
    private void OnDisable()
    {
        _health.Died -= Show;
        _restartButton.onClick.RemoveListener(RestartGame);
    }
    private void Show()
    {
        _panel.SetActive(true);
        Time.timeScale = 0;
    }
    private void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
    public void MenuGame()
    {
        SceneManager.LoadScene("Menu");
    }
}
