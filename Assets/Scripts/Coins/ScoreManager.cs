using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private WalletCoins _wallet;
    [SerializeField] private TMP_Text _text;

    private void OnEnable()
    {
        _wallet.ChangCoins += OnChangCoins;
    }
    private void OnDisable()
    {
        _wallet.ChangCoins -= OnChangCoins;
    }

    private void OnChangCoins(int coins)
    {
        _text.text = coins.ToString();
    }
}
