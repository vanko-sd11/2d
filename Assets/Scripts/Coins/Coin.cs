using UnityEngine;

public class Coin : MonoBehaviour
{

    [SerializeField] private int _coin = 1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.TryGetComponent(out WalletCoins wallet))
        {
            return;
        }
            

        wallet.Add(_coin);
        Destroy(gameObject);
    }
}
