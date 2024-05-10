using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    public void Die()
    {
        gameObject.SetActive(false); // 몬스터 비활성화
        GameManager.Instance.EnemyKilled(); // GameManager를 통해 몬스터가 죽었음을 알림
    }
}