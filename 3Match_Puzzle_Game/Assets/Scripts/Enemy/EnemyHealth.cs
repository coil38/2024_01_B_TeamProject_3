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

    public EnemyMovement1 enemyMovement1;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        _animator = GetComponent<Animator>();
        enemyCollider = GetComponent<Collider2D>();

        enemyMovement1 = FindAnyObjectByType<EnemyMovement1>();
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
        enemyMovement1.StopMovement(); // 적의 움직임을 멈춤
        _animator.SetTrigger("doDead");
        enemyCollider.enabled = false;
        StartCoroutine(DeadRoutine());
        SoundManager.instance.PlaySound("EnemyDead");
    }

    private IEnumerator DeadRoutine()
    {
        // 죽는 애니메이션이 완료될 때까지 대기
        yield return new WaitForSeconds(_animator.GetCurrentAnimatorStateInfo(0).length);
        gameObject.SetActive(false);
        GameManager.Instance.EnemyKilled();
    }
}
