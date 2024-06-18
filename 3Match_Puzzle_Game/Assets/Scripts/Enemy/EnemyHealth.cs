using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public enum AttackType { Melee, Magical, Spear, Bow }
    public List<AttackType> allowedAttackTypes; // ���Ǵ� ���� Ÿ�� ����Ʈ

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
        // ź�� Ÿ���� ���Ǵ� Ÿ�Կ� ���Ե� ���� ������ ����
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
        enemyMovement1.StopMovement(); // ���� �������� ����
        _animator.SetTrigger("doDead");
        enemyCollider.enabled = false;
        StartCoroutine(DeadRoutine());
        SoundManager.instance.PlaySound("EnemyDead");
    }

    private IEnumerator DeadRoutine()
    {
        // �״� �ִϸ��̼��� �Ϸ�� ������ ���
        yield return new WaitForSeconds(_animator.GetCurrentAnimatorStateInfo(0).length);
        gameObject.SetActive(false);
        GameManager.Instance.EnemyKilled();
    }
}
