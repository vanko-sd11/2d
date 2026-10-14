using System;
using UnityEngine;

public class WalletCoins : MonoBehaviour
{
    // OnCoinsCountChanged
    public event Action<int> ChangCoins;

    private int _coins;

    public void Add(int amount)
    {
        _coins += amount;
        ChangCoins?.Invoke(_coins);
    }
}
