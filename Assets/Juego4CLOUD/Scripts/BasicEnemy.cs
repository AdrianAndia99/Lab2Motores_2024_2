using System.Collections;
using UnityEngine;
public class BasicEnemy : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float projectileSpeed;
    [SerializeField] private float firingRate;
    [SerializeField] private int damage;
    [SerializeField] public int life;
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] public GameObject mysteryBoxPrefab;
    public Transform playerTransform;
    public GameObject explosionPrefab;
    private Vector2 direction;
    private Rigidbody2D _compRigidbody2D;
    private void Awake()
    {
        _compRigidbody2D = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        if (playerTransform != null)
        {
            direction = (playerTransform.position - transform.position).normalized;
        }
        StartCoroutine(FireProjectile());
    }

    void Update()
    {
        _compRigidbody2D.linearVelocity = direction * speed;
    }

    IEnumerator FireProjectile()
    {
        while (true)
        {
            if (playerTransform != null)
            {
                GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
                projectile.GetComponent<Rigidbody2D>().linearVelocity = direction * projectileSpeed;
            }
            yield return new WaitForSeconds(1 / firingRate);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
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
