using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public enum AttackType { Melee, Magical, Spear, Bow }
    public List<AttackType> allowedAttackTypes; // 허용되는 공격 타입 리스트

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

    public void TakeDamage(int damage, Player_Bullet.BulletType bulletType)
    {
        // 탄알 타입이 허용되는 타입에 포함될 때만 데미지 적용
        if (allowedAttackTypes.Contains((AttackType)bulletType))
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