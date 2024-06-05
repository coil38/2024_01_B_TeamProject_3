using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 50;
    private int currentHealth;
    public HealthBar healthBar;

    private Animator _animator;

    private Collider2D enemyCollider;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        _animator = GetComponent<Animator>();
        enemyCollider = GetComponent<Collider2D>();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
        else
        {
            _animator.SetTrigger("doDamaged");
        }
    }

    void Die()
    {
        _animator.SetTrigger("doDead");
        enemyCollider.enabled = false;      
        StartCoroutine(DeadRoutine());
    }

    private IEnumerator DeadRoutine()
    {
        yield return new WaitForSeconds(_animator.GetCurrentAnimatorStateInfo(0).length);
        gameObject.SetActive(false);
        GameManager.Instance.EnemyKilled();
    }
}