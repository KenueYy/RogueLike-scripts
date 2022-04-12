using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFightSystem : MonoBehaviour
{
    public PlayerUI playerUI;
    public Transform attackPoint;
    public LayerMask EnemyLayer;
    public float maxHealth;
    public float health;
    public float damage;
    public float startAttackTime;
    public float attackRange;
    private Animator _anim;
    private float _attackTime;
    private void Start()
    {
        playerUI.healthBar.SetMaxHealth(maxHealth);
        playerUI.healthBar.SetHealth(health);
        _anim = GetComponent<Animator>();
    }
    public void Update()
    {
        if (_attackTime <= 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Attack();
                _attackTime = startAttackTime;
            }
            
        }
        else
        {
            _attackTime -= Time.deltaTime;
        }
    }
    public void TakeDamage(float damage)
    {
        health -= damage;
        if(health <= 0)
        {
            Destroy(gameObject);
        }
        playerUI.healthBar.SetHealth(health);
    }
    public void Attack()
    {
        _anim.SetTrigger("Attack");
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, EnemyLayer);
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().TakeDamage(damage/hitEnemies.Length);
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
    public void BuffDamage(float value)
    {
        damage += value;
    }
    public void BuffAttackSpeed(float value)
    {
        startAttackTime -= value;
    }
    public void BuffMaxHealth(float value)
    {
        maxHealth += value;
        health += value;
        playerUI.healthBar.SetMaxHealth(maxHealth);
        playerUI.healthBar.SetHealth(health);
    }
}
    