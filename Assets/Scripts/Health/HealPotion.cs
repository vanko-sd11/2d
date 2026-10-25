using UnityEngine;

public sealed class HealPotion : MonoBehaviour
{
    [SerializeField, Min(1)] private float _healCount = 10f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.TryGetComponent(out Health health))
        {
            return;
        }

        health.Heal(_healCount);
        Destroy(gameObject);
    }
}
