using UnityEngine;

public sealed  class Thorns : MonoBehaviour
{
    [SerializeField, Min(1)] private float _damage = 10f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(!other.TryGetComponent(out Health health))
        {
            return;
        }

        health.TakeDamage(_damage);
    }
}
