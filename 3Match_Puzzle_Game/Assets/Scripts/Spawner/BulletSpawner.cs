using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject meleeBulletPrefab;
    public GameObject magicalBulletPrefab;
    public GameObject spearBulletPrefab;
    public GameObject bowBulletPrefab;

    public float spawnRateMin = 0.5f;      // 최소 생성 주기
    public float spawnRateMax = 1.5f;      // 최대 생성 주기

    private Transform target;   // 발사할 대상
    private float spawnRate;   // 생성 주기
    private float timeAfterSpawn; // 최근 생성 시점에서 지난 시간

    void Start()
    {
        // 최근 생성 이후의 누적 시간을 0으로 초기화
        timeAfterSpawn = 0;

        // 탄알 생성 간격을 spawnRateMin과 spawnRateMax 사이에서 랜덤 지정  
        spawnRate = Random.Range(spawnRateMin, spawnRateMax);

        // 초기 타겟 설정을 null로 함
        target = null;
    }

    void Update()
    {
        // timeAfterSpawn 갱신
        timeAfterSpawn += Time.deltaTime;

        // 최근 생성 시점에서부터 누적된 시간이 생성 주기보다 크거나 같다면
        if (timeAfterSpawn > spawnRate)
        {
            // 누적된 시간을 리셋
            timeAfterSpawn = 0;
        }
    }

    public void SpawnBullet(GameObject bulletPrefab, Player_Bullet.BulletType bulletType)
    {
        if (target != null)
        {
            // 총알 생성
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);

            // 총알 방향 설정
            Vector2 direction = (target.position - transform.position).normalized;
        
            // 총알 Rigidbody2D 컴포넌트 설정
            Rigidbody2D bulletRigidbody = bullet.GetComponent<Rigidbody2D>();
            bulletRigidbody.velocity = direction * bullet.GetComponent<Player_Bullet>().speed;
        
            // 총알이 적(Enemy)을 향하도록 회전
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            bullet.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            // 총알 타입 설정
            Player_Bullet bulletScript = bullet.GetComponent<Player_Bullet>();
            bulletScript.bulletType = bulletType;
        }
        else
        {
            // 랜덤 타겟 설정 (기존 코드)
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

            if (enemies.Length > 0)
            {
                // 배열에서 랜덤하게 적(Enemy)을 선택하여 대상으로 설정
                target = enemies[Random.Range(0, enemies.Length)].transform;
            }
        }
    }

    public void SetTarget(GameObject targetObject)
    {
        if (targetObject.CompareTag("Enemy"))
        {
            target = targetObject.transform;
        }
    }
}