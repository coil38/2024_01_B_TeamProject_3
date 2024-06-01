using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement1 : MonoBehaviour
{
    public Transform player; // 플레이어의 Transform
    public float speed = 5f; // 슬라임 이동 속도

    void Update()
    {
        // 플레이어와 슬라임의 현재 위치
        Vector3 playerPosition = player.position;
        Vector3 slimePosition = transform.position;

        // 플레이어를 향한 방향 계산
        Vector3 direction = (playerPosition - slimePosition).normalized;

        // 슬라임을 직선으로 이동
        transform.position += direction * speed * Time.deltaTime;
    }
}
