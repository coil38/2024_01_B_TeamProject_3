using UnityEngine;

public class Player_Bullet : MonoBehaviour
{
    public enum BulletType { Melee, Magical, Spear, Bow }
    public BulletType bulletType; // ź���� Ÿ��
    public float speed = 8f;
    public int damage = 20;
    private Rigidbody2D rigid;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        rigid.velocity = transform.right * speed;
        Destroy(gameObject, 3f);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            EnemyHealth enemyHealth = collision.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damage, bulletType);
                gameObject.SetActive(false);
            }
        }
    }
}