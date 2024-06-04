using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 2f; // 적의 이동 속도입니다.
    public float distanceToMaintain = 1.0f;  // 플레이어와의 유지 거리
    public Transform player;
    private bool isMoving = true;
    private Rigidbody2D rb;

    private Animator _animator;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(-speed, rb.velocity.y); // 왼쪽으로 움직이기 위해 속도를 설정합니다.
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        rb.velocity = new Vector2(-speed, rb.velocity.y); // 계속해서 왼쪽으로 움직이게 합니다.

        if (rb.velocity.y == 0)
        {
            _animator.SetBool("isMove", false);
        }
        else
        {
            _animator.SetBool("isMove", true);
        }
        if (isMoving)
        {
            MoveToTarget();     // 이동 중이라면 목표 위치로 이동
        }
    }

    void Slime1Move()
    {
        SoundManager.instance.PlaySound("Slime1_Move");
    }

    void MoveToTarget()
    {
       Vector3 targetPosition = player.position;

        // 슬라임이 플레이어의 x 또는 y 좌표 중 하나만 따라가도록 함
        if (Mathf.Abs(player.position.x - transform.position.x) > distanceToMaintain)
        {
            targetPosition = new Vector3(player.position.x, transform.position.y, transform.position.z);
        }
        else if (Mathf.Abs(player.position.y - transform.position.y) > distanceToMaintain)
        {
            targetPosition = new Vector3(transform.position.x, player.position.y, transform.position.z);
        }

        Vector3 newPosition = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);  // 목표 위치로 이동
        rb.MovePosition(newPosition);  // Rigidbody2D를 사용하여 이동

        // 목표 위치에 도달했는지 확인
        if (Vector3.Distance(transform.position, targetPosition) < 0.01f)
        {
            isMoving = false;
            rb.velocity = Vector2.zero;  // 속도 0으로 설정하여 멈춤
        }
    }
}
