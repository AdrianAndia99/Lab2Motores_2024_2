using UnityEngine;

public class BossController : MonoBehaviour
{
    public GameObject bulletPrefab;
    [SerializeField] private float bulletSpeed;
    [SerializeField] private int bulletCount;
    [SerializeField] private float cooldownTime;
    [SerializeField] public int life;
    [SerializeField] private float limit; // L�mite para el movimiento vertical
    [SerializeField] private float speed; // Velocidad de movimiento vertical
    [SerializeField] private int damage; // Velocidad de movimiento vertical
    public GameObject explosionPrefab;
    public GameObject powerUp;
    private float nextFireTime = 0;
    private Rigidbody2D rb;
    private int direction = 1; // Direcci�n inicial hacia arriba

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = new Vector2(0, speed); // Comienza a moverse hacia arriba
    }

    void Update()
    {
        if (Time.time > nextFireTime)
        {
            FireBullets();
            nextFireTime = Time.time + cooldownTime;
        }

        // Cambia de direcci�n si alcanza los l�mites
        if (transform.position.y >= limit)
        {
            direction = -1; // Mover hacia abajo
        }
        else if (transform.position.y <= -limit)
        {
            direction = 1; // Mover hacia arriba
        }

        rb.linearVelocity = new Vector2(0, speed * direction);
    }

    private void FireBullets()
    {
        float angleStep = 180f / (bulletCount - 1); // Ajustar el �ngulo para un patr�n de semic�rculo
        float angle = 0f;

        for (int i = 0; i < bulletCount; i++)
        {
            float projectileDirXposition = transform.position.x - Mathf.Sin((angle * Mathf.PI) / 180) * 0.5f;
            float projectileDirYposition = transform.position.y - Mathf.Cos((angle * Mathf.PI) / 180) * 0.5f;

            Vector2 projectileVector = new Vector2(projectileDirXposition, projectileDirYposition);
            Vector2 projectileMoveDirection = (projectileVector - (Vector2)transform.position).normalized * bulletSpeed;

            GameObject tmpObj = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            tmpObj.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(projectileMoveDirection.x, projectileMoveDirection.y);

            angle += angleStep;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            PlayerController.Instance.Life = PlayerController.Instance.Life - damage;
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
                    PlayerController.Instance.currentPowerUp = powerUp;
                    AudioManagerController.Instance.PlaySfx(1);
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
                    PlayerController.Instance.currentPowerUp = powerUp;
                    AudioManagerController.Instance.PlaySfx(1);
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
                    PlayerController.Instance.currentPowerUp = powerUp;
                    AudioManagerController.Instance.PlaySfx(1);
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
                    PlayerController.Instance.currentPowerUp = powerUp;
                    AudioManagerController.Instance.PlaySfx(1);
                    AudioManagerController.Instance.PlaySfx(4);
                    UIManagerController.Instance.EnemyEliminated();
                    Destroy(this.gameObject);
                }
            }
        }
    }
}
