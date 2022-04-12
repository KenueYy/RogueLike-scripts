using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class Enemy : MonoBehaviour
{
    public float maxHealth;
    public float health;
    public float minDamage, maxDamage;
    public float startAttackTime;
    public OnHit HitEvents;
    public HealthBar healthBar;

    private float _attackTime;
    private bool _isReadyAttack;
    private void Start()
    {
        healthBar.SetMaxHealth(maxHealth);
        healthBar.SetHealth(health);
    }
    public void Update()
    {
        AttackSpeedConroller();
    }
    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
            Die();
        healthBar.SetHealth(health);
    }
    private void Die()
    {
        Destroy(gameObject);
    }
    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.collider.GetComponent<PlayerActions>() != null && _isReadyAttack)
        {
            Attack(other.collider);
        }
    }
    public void AttackSpeedConroller()
    {
        if (_attackTime <= 0)
        {
            _isReadyAttack = true;
        }
        else
        {
            _isReadyAttack = false;
            _attackTime -= Time.deltaTime;
        }
    }
    private void Attack(Collider2D player)
    {
        player.GetComponent<PlayerFightSystem>().TakeDamage(maxDamage);
        //HitEvents.Invoke(maxDamage);
        _attackTime = startAttackTime; 
    }
}
[System.Serializable]
public class OnHit : UnityEvent<float> { };
