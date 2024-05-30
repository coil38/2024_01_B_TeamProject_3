using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100; // �÷��̾��� �ִ� ü���Դϴ�.
    private int currentHealth; // ���� ü���� �����մϴ�.
    public HealthBar healthBar; // �÷��̾��� ü�¹��Դϴ�.
    
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

    public void Heal(int amount)
    {
        Debug.Log("Healing amount: " + amount); // Healing amount Ȯ��
        currentHealth = Mathf.Min(currentHealth + amount, maxHealth); // currentHealth�� ������Ű�� maxHealth�� �ʰ����� �ʵ��� ��
        healthBar.SetHealth(currentHealth); // ü�¹ٸ� ������Ʈ�մϴ�.
        Debug.Log("Player Health: " + currentHealth); // ���� ü���� ����մϴ�.
    }
    
    void Die()
    {
        Debug.Log("Player Died"); // �÷��̾ �׾����� ����մϴ�.
        // �÷��̾ �׾��� ���� ������ �����մϴ�.
    }
}
