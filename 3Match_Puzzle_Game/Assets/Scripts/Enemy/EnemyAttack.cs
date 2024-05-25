using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public int attackDamage = 10; // ���� �� ���� �������Դϴ�.
    public float attackRange = 1.0f; // ���� �����Դϴ�.
    public float attackRate = 1.0f; // �ʴ� ���� Ƚ���Դϴ�.
    private float nextAttackTime = 0f; // ���� ������ ������ �ð��� �����մϴ�.
    public Transform player; // �÷��̾��� Transform�� �����մϴ�.

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null)
        {
            return; // �÷��̾ ������ ������Ʈ�� �����մϴ�.
        }

        float distanceToPlayer = Vector2.Distance(transform.position, player.position); // �÷��̾���� �Ÿ��� ����մϴ�.
        if (distanceToPlayer <= attackRange && Time.time >= nextAttackTime)
        {
            Attack(); // �÷��̾ ���� ���� ���� �ְ� ������ ������ �ð��� �Ǹ� �����մϴ�.
            nextAttackTime = Time.time + 1f / attackRate; // ���� ���� �ð��� �����մϴ�.
        }
    }

    void Attack()
    {
        player.GetComponent<PlayerHealth>().TakeDamage(attackDamage);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red; // ����� ������ ���������� �����մϴ�.
        Gizmos.DrawWireSphere(transform.position, attackRange); // ���� ������ ��Ÿ���� ���� �׸��ϴ�.
    }
}
