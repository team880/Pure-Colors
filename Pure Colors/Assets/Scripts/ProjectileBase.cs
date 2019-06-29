using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public abstract class ProjectileBase : MonoBehaviour
{
    public bool enemyProjectile;
    public int damage;
    public float projectileSpeed;
    private Rigidbody2D _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }
    public abstract Vector2 SetFlightDirection();

    public void Fly(Vector2 direction, float speed)
    {
        _rigidbody.velocity = direction * speed;
    }
}
