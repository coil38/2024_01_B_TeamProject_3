using UnityEngine;
using UnityEngine.UI;

public class Attack : MonoBehaviour
{
    // ScoreCounter의 인스턴스
    private ScoreCounter _scoreCounter;

    // BulletSpawner 인스턴스
    private BulletSpawner bulletSpawner;
    
    // PlayerHealth 인스턴스
    private PlayerHealth playerHealth;

    // 공격에 필요한 점수
    public int meleeAttackCost = 50;
    public int magcialAttackCost = 100;
    public int spearAttackCost = 70;
    public int playerHealCost = 50;
    public int bowAttackCost = 30;

    // 공격 버튼 참조
    public Button meleeAttackButton;
    public Button magcialAttackButton;
    public Button spearAttackButton;
    public Button playerHealButton;
    public Button bowAttackButton;

    void Awake()
    {
        // BulletSpawner의 인스턴스를 가져옴
        bulletSpawner = FindObjectOfType<BulletSpawner>();
        
        // PlayerHealth 인스턴스를 가져옴
        playerHealth = FindObjectOfType<PlayerHealth>();
    }

    void Start()
    {
        _scoreCounter = ScoreCounter.Instance;
        
        playerHealth = FindObjectOfType<PlayerHealth>();
    }
    
    void Update()
    {
        meleeAttackButton.interactable = _scoreCounter.Score >= meleeAttackCost;
        magcialAttackButton.interactable = _scoreCounter.Score >= magcialAttackCost;
        spearAttackButton.interactable = _scoreCounter.Score >= spearAttackCost;
        playerHealButton.interactable = _scoreCounter.Score >= playerHealCost;
        bowAttackButton.interactable = _scoreCounter.Score >= bowAttackCost;
    }

    public void MeleeAttack()
    {
        PerformAttack(meleeAttackCost, "근접");
        SoundManager.instance.PlaySound("Melee");
        
    }

    public void MagcialAttack()
    {
        PerformAttack(magcialAttackCost, "마법");
        SoundManager.instance.PlaySound("Magcial");
    }

    public void SpearAttack()
    {
        PerformAttack(spearAttackCost, "창");
        SoundManager.instance.PlaySound("Spear");
    }

    public void PlayerHeal()
    {
        PerformHeal(playerHealCost);
        SoundManager.instance.PlaySound("Healing");
    }

    public void BowAttack()
    {
        PerformAttack(bowAttackCost, "활");
        SoundManager.instance.PlaySound("Crossbow");
    }

    private void PerformAttack(int cost, string attackType)
    {
        if (_scoreCounter.Score >= cost)
        {
            _scoreCounter.Score -= cost;
            Debug.Log($"코스트 {cost} 의 {attackType} 공격을 실행합니다!");
            bulletSpawner.SpawnBullet(); 
        }
    }

    private void PerformHeal(int cost)
    {
        // 플레이어의 점수가 힐에 필요한 점수보다 충분한지 확인
        if (_scoreCounter.Score >= cost)
        {
            // 점수를 감소시킴
            _scoreCounter.Score -= cost;

            // 플레이어 힐
            if (playerHealth != null)
            {
                playerHealth.Heal(30);
            }

            Debug.Log($"코스트 {cost} 를 사용하여 플레이어를 힐합니다!");
        }
    }
    
    // 플레이어에게 데미지 주는 메서드
    public void DamagePlayer(int damageAmount)
    {
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(damageAmount);
        }
    }
}