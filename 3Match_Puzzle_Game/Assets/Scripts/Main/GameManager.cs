using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private MonsterSpawner monsterSpawner;

    public GameObject gameClear;

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
            monsterSpawner.SetMonstersAlive(false); // 몬스터가 모두 죽었음을 MonsterSpawner에 알림

            Time.timeScale = 0;
            
            gameClear.SetActive(true);
            
            Debug.Log("Game Clear!");
        }
    }
}