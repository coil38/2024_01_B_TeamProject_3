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
        // 모든 몬스터가 죽었는지 체크
        GameObject[] monsters = GameObject.FindGameObjectsWithTag("Enemy");
        if (monsters.Length == 0)
        {
            monsterSpawner.SetMonstersAlive(false);
        }
    }
}