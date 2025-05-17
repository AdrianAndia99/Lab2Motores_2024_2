
using UnityEngine;

public class KamikazeEnemy : MonoBehaviour
{
    [SerializeField] private float speed;
    public Transform playerTransform;
    [SerializeField] private int damage;
    [SerializeField] public int life;
    private Rigidbody2D _compRigidBody2D;
    [SerializeField] public GameObject mysteryBoxPrefab;
    public GameObject explosionPrefab;
    private void Awake()
    {
        _compRigidBody2D = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (playerTransform != null)
        {
            Vector2 direction = (playerTransform.position - transform.position).normalized;
            _compRigidBody2D.linearVelocity = direction * speed;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Instantiate(explosionPrefab,transform.position,Quaternion.identity);
            AudioManagerController.Instance.PlaySfx(4);
            PlayerController.Instance.Life = PlayerController.Instance.Life - damage;
            Destroy(this.gameObject);
        }
        else if (collision.tag == "EnemyEliminator")
        {
            Destroy(this.gameObject);
        }
        else if (collision.tag == "Bullet")
        {
            BasicBullet bullet = collision.gameObject.GetComponent<BasicBullet>();
            if (bullet != null)
            {
                AudioManagerController.Instance.PlaySfx(5);
                life -= bullet.damage;
                Destroy(bullet.gameObject);
                if (life <= 0)
                {
                    Instantiate(explosionPrefab, transform.position, Quaternion.identity);
                    // Hay un 20% de probabilidad de soltar una caja misteriosa
                    if (Random.value < 0.2f)
                    {
                        Instantiate(mysteryBoxPrefab, transform.position, Quaternion.identity);
                    }
                    AudioManagerController.Instance.PlaySfx(4);
                    UIManagerController.Instance.EnemyEliminated();
                    Destroy(this.gameObject);
                }
            }
        }
        else if (collision.tag == "PerforatorBullet")
        {
            PerforatorBullet bullet = collision.gameObject.GetComponent<PerforatorBullet>();
            if (bullet != null)
            {
                AudioManagerController.Instance.PlaySfx(5);
                life -= bullet.damage;
                if (life <= 0)
                {
                    Instantiate(explosionPrefab, transform.position, Quaternion.identity);
                    // Hay un 20% de probabilidad de soltar una caja misteriosa
                    if (Random.value < 0.2f)
                    {
                        Instantiate(mysteryBoxPrefab, transform.position, Quaternion.identity);
                    }
                    AudioManagerController.Instance.PlaySfx(4);
                    UIManagerController.Instance.EnemyEliminated();
                    Destroy(this.gameObject);
                }
            }
        }
        else if (collision.tag == "TripleBullet")
        {
            TripleBullet bullet = collision.gameObject.GetComponent<TripleBullet>();
            if (bullet != null)
            {
                AudioManagerController.Instance.PlaySfx(5);
                life -= bullet.damage;
                Destroy(bullet.gameObject);
                if (life <= 0)
                {
                    Instantiate(explosionPrefab, transform.position, Quaternion.identity);
                    // Hay un 20% de probabilidad de soltar una caja misteriosa
                    if (Random.value < 0.2f)
                    {
                        Instantiate(mysteryBoxPrefab, transform.position, Quaternion.identity);
                    }
                    AudioManagerController.Instance.PlaySfx(4);
                    UIManagerController.Instance.EnemyEliminated();
                    Destroy(this.gameObject);
                }
            }
        }
        else if (collision.tag == "TripleBulletPrefab")
        {
            TripleBulletPrefab bullet = collision.gameObject.GetComponent<TripleBulletPrefab>();
            if (bullet != null)
            {
                AudioManagerController.Instance.PlaySfx(5);
                life -= bullet.damage;
                Destroy(bullet.gameObject);
                if (life <= 0)
                {
                    Instantiate(explosionPrefab, transform.position, Quaternion.identity);
                    // Hay un 20% de probabilidad de soltar una caja misteriosa
                    if (Random.value < 0.2f)
                    {
                        Instantiate(mysteryBoxPrefab, transform.position, Quaternion.identity);
                    }
                    AudioManagerController.Instance.PlaySfx(4);
                    UIManagerController.Instance.EnemyEliminated();
                    Destroy(this.gameObject);
                }
            }
        }
    }
}
