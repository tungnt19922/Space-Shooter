using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private GameObject explosionPrefabs;
    [SerializeField] private int defaultHealthPoint;
    [SerializeField] private int healthPoint;
    public System.Action onDead;


    private void Start()
    {
        healthPoint = defaultHealthPoint;
    }

    public void TakeDamage(int damage)
    {
        if (healthPoint <= 0) return;

        healthPoint -= damage;
        if (healthPoint <= 0) Die();

    }

    protected virtual void Die()
    {
        var explosion = Instantiate(explosionPrefabs, transform.position, transform.rotation);
        Destroy(explosion, 2);
        Destroy(gameObject);
        onDead?.Invoke();
    }
}
