using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyBase : MonoBehaviour, IDamagable
{
    public int MaxHealth 
    {
        get => maxHealth;
        set => maxHealth = value;
    }
    public int Health
    {
        get => health;
        set => health = value;
    }
    [SerializeField] private int maxHealth;
    [SerializeField] private int health;
    [SerializeField] internal float moveSpeed;

    private Rigidbody2D rigidbody;
    public virtual void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        health = maxHealth;
        print(Health);
    }

    public virtual void TakeDamage(int incomingDamage)
    {
        health -= incomingDamage;
        if(health == 0) Die();
    }

    public void Move(Vector2 direction)
    {
        rigidbody.velocity = direction * moveSpeed;
        rigidbody.velocity = Vector2.ClampMagnitude(rigidbody.velocity, moveSpeed);
    }

    public virtual void Die()
    {
        Destroy(gameObject);
    }
}
