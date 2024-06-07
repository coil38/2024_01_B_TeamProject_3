using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]

public class Achievement                // ���� Ŭ���� ���� (��� �����̺��(MonoBehaviour) X)
{
    public string name;                 // ���� �̸�
    public string descripttion;         // ���� ����
    public bool isUnlocked;             // ��� ����
    public int currentProgress;         // ���� ����
    public int goal;                    // �Ϸ� ����

    public Achievement(string name, string descripttion, int goal)      // ������ �Լ�
    {
        this.name = name;                               // Achievement Ŭ������ ���� �� �� �̸��� �μ��� �޾Ƽ� ����
        this.descripttion = descripttion;               // Achievement Ŭ������ ���� �� �� ������ �μ��� �޾Ƽ� ����
        this.isUnlocked = false;                        // Achievement Ŭ������ ���� �� �� false
        this.currentProgress = 0;                       // Achievement Ŭ������ ���� �� �� 0
        this.goal = goal;                               // Achievement Ŭ������ ���� �� �� �Ϸ� ����
    }

    public void AddProgress(int amount)                 // ���� ���൵ �Լ�
    {
        if (!isUnlocked)                                // ������� �ʴٸ�
        {
            currentProgress += amount;
            if (currentProgress >= goal)                // ���൵���� �Ϸ� ���ڰ� �� ���� ��
            {
                isUnlocked = true;
                OnAchievementUnlocked();                // ���� �޼��� Debug.Log�� ���
            }
        }
    }

    protected virtual void OnAchievementUnlocked()
    {
        Debug.Log($"���� �޼� : {name}");               // $ ǥ�ð� ����ִ� String ���� {} ���� ���� ��� �� �� �ִ�.
    }
}