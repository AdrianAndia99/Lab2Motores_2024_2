using UnityEngine;
public enum ObstacleType
{
    Asteroid,
    SpaceGarbage,
    EnemyPieces
}
public class Obstacle : MonoBehaviour
{
    [SerializeField] private float speed; // Velocidad del obst�culo
    [SerializeField] public int life; // Vida del obst�culo
    public int damage;
    private Rigidbody2D _compRigidBody2D;
    public bool moveUp; // Direcci�n del movimiento
    public GameObject explosionPrefab;
    public ObstacleType type;

    public int AsteroidSound;
    public int SpaceGarbageSound;
    public int EnemyPiecesSound;

    private void Awake()
    {
        _compRigidBody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector2 direction = moveUp ? new Vector2(1, 1) : new Vector2(1, -1);
        _compRigidBody2D.linearVelocity = direction * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            PlayerController.Instance.Life = PlayerController.Instance.Life - damage;
            Destroy(this.gameObject);
        }
        else if (collision.tag == "ObstacleEliminator")
        {
            Destroy(this.gameObject);
        }
        else if (collision.tag == "Bullet")
        {
            BasicBullet bullet = collision.gameObject.GetComponent<BasicBullet>();
            if (bullet != null)
            {
                life -= bullet.damage;
                Destroy(bullet.gameObject);
                if (life <= 0)
                {
                    Instantiate(explosionPrefab, transform.position, Quaternion.identity);
                    Destroy(this.gameObject);
                }
            }
        }
        else if (collision.tag == "PerforatorBullet")
        {
            PerforatorBullet bullet = collision.gameObject.GetComponent<PerforatorBullet>();
            if (bullet != null)
            {
                life -= bullet.damage;
                if (life <= 0)
                {

                    Instantiate(explosionPrefab, transform.position, Quaternion.identity);
                    Destroy(this.gameObject);
                }
            }
        }
        else if (collision.tag == "TripleBullet")
        {
            TripleBullet bullet = collision.gameObject.GetComponent<TripleBullet>();
            if (bullet != null)
            {
                life -= bullet.damage;
                Destroy(bullet.gameObject);
                if (life <= 0)
                {
                    Instantiate(explosionPrefab, transform.position, Quaternion.identity);
                    Destroy(this.gameObject);
                }
            }
        }
        else if (collision.tag == "TripleBulletPrefab")
        {
            TripleBulletPrefab bullet = collision.gameObject.GetComponent<TripleBulletPrefab>();
            if (bullet != null)
            {
                life -= bullet.damage;
                Destroy(bullet.gameObject);
                if (life <= 0)
                {
                    Instantiate(explosionPrefab, transform.position, Quaternion.identity);
                    Destroy(this.gameObject);
                }
            }
        }
    }
}
