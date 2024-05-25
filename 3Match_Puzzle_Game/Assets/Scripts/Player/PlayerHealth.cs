using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100; // �÷��̾��� �ִ� ü���Դϴ�.
    private int currentHealth; // ���� ü���� �����մϴ�.
    public HealthBar healthBar; // �÷��̾��� ü�¹��Դϴ�.

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth; // ���� ü���� �ִ� ü������ �ʱ�ȭ�մϴ�.
        healthBar.SetMaxHealth(maxHealth); // ü�¹ٸ� �ʱ�ȭ�մϴ�.
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage; // ��������ŭ ���� ü���� ���ҽ�ŵ�ϴ�.
        healthBar.SetHealth(currentHealth); // ü�¹ٸ� ������Ʈ�մϴ�.
        Debug.Log("Player Health: " + currentHealth); // ���� ü���� ����մϴ�.
        if (currentHealth <= 0)
        {
            Die(); // ���� ü���� 0 ���ϰ� �Ǹ� ���� ó���� �մϴ�.
        }
    }

    void Die()
    {
        Debug.Log("Player Died"); // �÷��̾ �׾����� ����մϴ�.
        // �÷��̾ �׾��� ���� ������ �����մϴ�.
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
