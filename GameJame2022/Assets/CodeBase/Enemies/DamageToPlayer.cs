using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageToPlayer : MonoBehaviour
{
    [SerializeField] private float damage;
    [SerializeField] private Health PlayerHealth;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerHealth.Damage(damage);
    }
}
