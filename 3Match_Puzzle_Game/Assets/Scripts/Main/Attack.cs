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
    public int magicalAttackCost = 100;
    public int spearAttackCost = 70;
    public int playerHealCost = 50;
    public int bowAttackCost = 30;

    // 공격 버튼 참조
    public Button meleeAttackButton;
    public Button magicalAttackButton;
    public Button spearAttackButton;
    public Button playerHealButton;
    public Button bowAttackButton;

    void Awake()
    {
        bulletSpawner = FindObjectOfType<BulletSpawner>();
        
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
        magicalAttackButton.interactable = _scoreCounter.Score >= magicalAttackCost;
        spearAttackButton.interactable = _scoreCounter.Score >= spearAttackCost;
        playerHealButton.interactable = _scoreCounter.Score >= playerHealCost;
        bowAttackButton.interactable = _scoreCounter.Score >= bowAttackCost;
    }

    public void MeleeAttack()
    {
        PerformAttack(meleeAttackCost, bulletSpawner.meleeBulletPrefab, Player_Bullet.BulletType.Melee);
        SoundManager.instance.PlaySound("Melee");
    }

    public void MagicalAttack()
    {
        PerformAttack(magicalAttackCost, bulletSpawner.magicalBulletPrefab, Player_Bullet.BulletType.Magical);
        SoundManager.instance.PlaySound("Magical");
    }

    public void SpearAttack()
    {
        PerformAttack(spearAttackCost, bulletSpawner.spearBulletPrefab, Player_Bullet.BulletType.Spear);
        SoundManager.instance.PlaySound("Spear");
    }

    public void BowAttack()
    {
        PerformAttack(bowAttackCost, bulletSpawner.bowBulletPrefab, Player_Bullet.BulletType.Bow);
        SoundManager.instance.PlaySound("Crossbow");
    }

    public void PlayerHeal()
    {
        PerformHeal(playerHealCost);
        SoundManager.instance.PlaySound("Healing");
    }
    
    private void PerformAttack(int cost, GameObject bulletPrefab, Player_Bullet.BulletType bulletType)
    {
        if (_scoreCounter.Score >= cost)
        {
            _scoreCounter.Score -= cost;
            Debug.Log($"코스트 {cost} 의 공격 {bulletPrefab} 을 실행합니다!");
            bulletSpawner.SpawnBullet(bulletPrefab, bulletType); 
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
                playerHealth.Heal(5);
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