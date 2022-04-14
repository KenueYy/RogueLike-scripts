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
    public HealthBar healthBar;

    private float _attackTime;
    private bool _isReadyAttack;
    private void Awake()
    {
        healthBar.SetMaxValue(maxHealth);
        healthBar.SetValue(health);
        healthBar.UpdateTextValue();
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
        healthBar.SetValue(health);
        healthBar.UpdateTextValue();
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
