using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement1 : MonoBehaviour
{
    public Transform player; // Player의 Transform을 저장하기 위한 변수
    public GameObject bulletPrefab; // 발사할 Bullet의 프리팹
    public float moveSpeed = 1f; // 적의 이동 속도
    public float minDistance = 2f; // Player와의 최소 거리
    public float maxDistance = 10f; // Player와의 최대 거리
    public float fireRate = 2f; // Bullet 발사 주기
    private float nextFireTime; // 다음 발사 시간

    private Rigidbody2D rb; // Rigidbody2D 컴포넌트에 접근하기 위한 변수
    private bool isMoving = true; // 이동 중인지 여부를 나타내는 변수


    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Rigidbody2D 컴포넌트에 접근
        player = GameObject.FindGameObjectWithTag("Player").transform; // Player를 찾아서 Transform 저장
        nextFireTime = Time.time; // 다음 발사 시간 초기화
    }

    
    void Update()
    {

    }
    void FixedUpdate()
    {
        if (player != null)
        {
            // 적과 Player 사이의 거리를 계산
            float distanceToPlayer = Vector2.Distance(transform.position, player.position);

            // 적과 Player 간의 거리가 최소 거리보다 크고 최대 거리보다 작으면 이동
            if (distanceToPlayer > minDistance && distanceToPlayer < maxDistance)
            {
                isMoving = true;
                // Player 방향으로 적을 이동시키기
                Vector2 direction = ((Vector2)player.position - rb.position).normalized;
                rb.MovePosition(rb.position + direction * moveSpeed * Time.fixedDeltaTime);
            }
            else
            {
                isMoving = false;
            }

            // 적이 Player를 향해 Bullet을 발사하는 로직
            if (!isMoving && Time.time > nextFireTime)
            {
                // Bullet 발사
                GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
                // Bullet을 Player를 향해 발사
                bullet.GetComponent<Rigidbody2D>().velocity = (player.position - transform.position).normalized * 10f;
                // 다음 발사 시간 설정
                nextFireTime = Time.time + fireRate;
            }
        }
    }
}
