using UnityEngine;
using UnityEngine.SceneManagement;

public class MonsterSpawner : MonoBehaviour
{
    public GameObject monsterPrefab;
    public float spawnDelay = 3f;
    public Transform spawnPoint;

    private bool areMonstersAlive;
    private int maxStages = 3; // �ִ� �������� ��

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
        // ���� ���� �̸��� ������
        string currentSceneName = SceneManager.GetActiveScene().name;

        // ���� ���������� ��ȣ�� ����
        int currentStageNumber = int.Parse(currentSceneName.Substring("Stage".Length));

        if (currentStageNumber < maxStages)
        {
            // ���� ���������� �̵�
            int nextStageNumber = currentStageNumber + 1;
            string nextStageName = "Stage" + nextStageNumber;
            SceneManager.LoadScene(nextStageName);
        }
        else
        {
            // �ִ� ���������� �������� �� ���� Ŭ���� �Ǵ� �ʱ�ȭ
            Debug.Log("Game Clear!");
            
            enabled = false;
        }
    }
}