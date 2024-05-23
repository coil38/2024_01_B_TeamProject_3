using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 50; // 적의 최대 체력입니다.
    private int currentHealth; // 현재 체력을 추적합니다.
    public HealthBar healthBar; // 적의 체력바입니다.

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth; // 현재 체력을 최대 체력으로 초기화합니다.
        healthBar.SetMaxHealth(maxHealth); // 체력바를 초기화합니다.
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage; // 데미지만큼 현재 체력을 감소시킵니다.
        healthBar.SetHealth(currentHealth); // 체력바를 업데이트합니다.
        Debug.Log("Enemy Health: " + currentHealth); // 현재 체력을 출력합니다.
        if (currentHealth <= 0)
        {
            Die(); // 현재 체력이 0 이하가 되면 죽음 처리를 합니다.
        }
    }

    void Die()
    {
        Debug.Log("Enemy Died"); // 적이 죽었음을 출력합니다.
        Destroy(gameObject); // 적 오브젝트를 파괴합니다.
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
