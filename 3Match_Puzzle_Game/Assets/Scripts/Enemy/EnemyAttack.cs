using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public int attackDamage = 10; // 공격 시 가할 데미지입니다.
    public float attackRange = 1.0f; // 공격 범위입니다.
    public float attackRate = 1.0f; // 초당 공격 횟수입니다.
    private float nextAttackTime = 0f; // 다음 공격이 가능한 시간을 추적합니다.
    public Transform player; // 플레이어의 Transform을 참조합니다.

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null)
        {
            return; // 플레이어가 없으면 업데이트를 종료합니다.
        }

        float distanceToPlayer = Vector2.Distance(transform.position, player.position); // 플레이어와의 거리를 계산합니다.
        if (distanceToPlayer <= attackRange && Time.time >= nextAttackTime)
        {
            Attack(); // 플레이어가 공격 범위 내에 있고 공격이 가능한 시간이 되면 공격합니다.
            nextAttackTime = Time.time + 1f / attackRate; // 다음 공격 시간을 설정합니다.
        }
    }

    void Attack()
    {
        player.GetComponent<PlayerHealth>().TakeDamage(attackDamage);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red; // 기즈모 색상을 빨간색으로 설정합니다.
        Gizmos.DrawWireSphere(transform.position, attackRange); // 공격 범위를 나타내는 구를 그립니다.
    }
}
