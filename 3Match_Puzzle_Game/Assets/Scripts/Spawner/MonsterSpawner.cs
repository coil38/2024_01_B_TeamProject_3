using UnityEngine;
using UnityEngine.SceneManagement;

public class MonsterSpawner : MonoBehaviour
{
    public GameObject monsterPrefab;
    public float spawnDelay = 3f;
    public Transform spawnPoint;

    private bool areMonstersAlive;
    private int maxStages = 3; // 최대 스테이지 수

    void Start()
    {
        areMonstersAlive = true;
        Invoke("SpawnMonster", spawnDelay);
    }

    void Update()
    {
        if (!areMonstersAlive)
        {
            LoadNextStage();
        }
    }

    void SpawnMonster()
    {
        Instantiate(monsterPrefab, spawnPoint.position, Quaternion.identity);
    }

    public void SetMonstersAlive(bool alive)
    {
        areMonstersAlive = alive;
    }

    void LoadNextStage()
    {
        // 현재 씬의 이름을 가져옴
        string currentSceneName = SceneManager.GetActiveScene().name;

        // 현재 스테이지의 번호를 추출
        int currentStageNumber = int.Parse(currentSceneName.Substring("Stage".Length));

        if (currentStageNumber < maxStages)
        {
            // 다음 스테이지로 이동
            int nextStageNumber = currentStageNumber + 1;
            string nextStageName = "Stage" + nextStageNumber;
            SceneManager.LoadScene(nextStageName);
        }
        else
        {
            // 최대 스테이지에 도달했을 때 게임 클리어 또는 초기화
            Debug.Log("Game Clear!");
            
            enabled = false;
        }
    }
}