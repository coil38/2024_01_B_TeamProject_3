using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement1 : MonoBehaviour
{
    public Transform player; // �÷��̾��� Transform
    public float speed = 5f; // ������ �̵� �ӵ�

    void Update()
    {
        // �÷��̾�� �������� ���� ��ġ
        Vector3 playerPosition = player.position;
        Vector3 slimePosition = transform.position;

        // �÷��̾ ���� ���� ���
        Vector3 direction = (playerPosition - slimePosition).normalized;

        // �������� �������� �̵�
        transform.position += direction * speed * Time.deltaTime;
    }
}
