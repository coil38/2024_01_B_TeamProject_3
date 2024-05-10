using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private MonsterSpawner monsterSpawner;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        monsterSpawner = FindObjectOfType<MonsterSpawner>();
    }

    public void EnemyKilled()
    {
        // ��� ���Ͱ� �׾����� üũ
        GameObject[] monsters = GameObject.FindGameObjectsWithTag("Enemy");
        if (monsters.Length == 0)
        {
            monsterSpawner.SetMonstersAlive(false); // ���Ͱ� ��� �׾����� MonsterSpawner�� �˸�
        }
    }
}