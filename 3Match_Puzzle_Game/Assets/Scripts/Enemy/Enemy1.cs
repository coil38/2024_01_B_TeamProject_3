using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    public float speed = 3.0f;  // 적의 이동 속도
    public Transform player;    // 플레이어의 Transform
    public float distanceToMaintain = 1.0f;  // 플레이어와의 유지 거리
    public GameObject bulletPrefab;     // 발사할 총알 프리팹
    public Transform firePoint;         // 총알이 발사될 위치
    public float shootInterval = 1.0f;  // 총알 발사 간격
    private float nextShootTime = 0f;   // 다음 발사 시간
    private bool isMoving = true;       // 적이 이동 중인지 여부

    private Rigidbody2D rb;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();  // Rigidbody2D 컴포넌트 가져오기
    }
    
    void Update()
    {
        if (isMoving)
        {
            MoveToTarget();     // 이동 중이라면 목표 위치로 이동
        }
        else
        {
            ShootAtPlayer();    // 목표 위치에 도달했다면 플레이어에게 총알 발사
        }
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

    void ShootAtPlayer()
    {
       if (Time.time > nextShootTime)  // 현재 시간이 다음 발사 시간보다 크다면 총알 발사
        {
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);  // 총알 생성
            nextShootTime = Time.time + shootInterval;  // 다음 발사 시간 갱신
        }
    }
}
