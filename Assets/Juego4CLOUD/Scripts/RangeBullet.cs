using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeBullet : MonoBehaviour
{
    public float waitTime = 2f; // Tiempo que el proyectil permanecer� quieto
    public float scaleIncrease = 2f; // Cantidad que se escalar� el proyectil
    public int damage = 10; // Da�o que se aplicar� a los enemigos
    public float speed = 10f;
    public float damageInterval = 1f; // Intervalo de tiempo entre cada aplicaci�n de da�o
    private Rigidbody2D _compRigidbody2D;
    private bool isStationary = false; // Bandera para controlar si el proyectil est� quieto
    private float lastDamageTime; // �ltima vez que se aplic� da�o
    public GameObject powerUp;
    public GameObject explosionPrefab;
    private void Awake()
    {
        _compRigidbody2D = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        AudioManagerController.Instance.PlaySfx(7);
    }

    private void FixedUpdate()
    {
        if (!isStationary)
        {
            _compRigidbody2D.linearVelocity = new Vector2(speed, 0);
        }
        else
        {
            _compRigidbody2D.linearVelocity = Vector2.zero;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "BasicEnemy")
        {
            if (!isStationary)
            {
                StartCoroutine(StayAndScale());
            }
        }
        else if (other.tag == "KamikazeEnemy")
        {
            if (!isStationary)
            {
                StartCoroutine(StayAndScale());
            }
        }
        else if (other.tag == "Obstacle")
        {
            if (!isStationary)
            {
                StartCoroutine(StayAndScale());
            }
        }
        else if (other.tag == "Boss")
        {
            if (!isStationary)
            {
                StartCoroutine(StayAndScale());
            }
        }
        else if (other.tag == "Eliminator")
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (isStationary && Time.time >= lastDamageTime + damageInterval)
        {
            if (other.tag == "BasicEnemy")
            {
                // Aplica da�o al enemigo
                BasicEnemy enemy = other.gameObject.GetComponent<BasicEnemy>();
                if (enemy != null)
                {
                    AudioManagerController.Instance.PlaySfx(5);
                    enemy.life -= damage;
                    if (enemy.life <= 0)
                    {
                        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
                        // Hay un 20% de probabilidad de soltar una caja misteriosa
                        if (Random.value < 0.2f)
                        {
                            Instantiate(enemy.mysteryBoxPrefab, transform.position, Quaternion.identity);
                        }
                        AudioManagerController.Instance.PlaySfx(4);
                        UIManagerController.Instance.EnemyEliminated();
                        Destroy(enemy.gameObject);
                    }
                }
                lastDamageTime = Time.time;
            }
            else if (other.tag == "KamikazeEnemy")
            {
                // Aplica da�o al enemigo
                KamikazeEnemy enemy = other.gameObject.GetComponent<KamikazeEnemy>();
                if (enemy != null)
                {
                    AudioManagerController.Instance.PlaySfx(5);
                    enemy.life -= damage;
                    if (enemy.life <= 0)
                    {
                        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
                        // Hay un 20% de probabilidad de soltar una caja misteriosa
                        if (Random.value < 0.2f)
                        {
                            Instantiate(enemy.mysteryBoxPrefab, transform.position, Quaternion.identity);
                        }
                        AudioManagerController.Instance.PlaySfx(4);
                        UIManagerController.Instance.EnemyEliminated();
                        Destroy(enemy.gameObject);
                    }
                }
                lastDamageTime = Time.time;
            }
            else if (other.tag == "Obstacle")
            {
                Obstacle enemy = other.gameObject.GetComponent<Obstacle>();
                if (enemy != null)
                {
                    enemy.SelectSound();
                    enemy.life -= damage;
                    if (enemy.life <= 0)
                    {
                        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
                        AudioManagerController.Instance.PlaySfx(4);
                        Destroy(enemy.gameObject);
                    }
                }
                lastDamageTime = Time.time;

            }
            else if (other.tag == "Boss")
            {
                // Aplica da�o al enemigo
                BossController enemy = other.gameObject.GetComponent<BossController>();
                if (enemy != null)
                {
                    AudioManagerController.Instance.PlaySfx(5);
                    enemy.life -= damage;
                    if (enemy.life <= 0)
                    {
                        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
                        PlayerController.Instance.currentPowerUp = powerUp;
                        AudioManagerController.Instance.PlaySfx(1);
                        AudioManagerController.Instance.PlaySfx(4);
                        UIManagerController.Instance.EnemyEliminated();
                        Destroy(enemy.gameObject);
                    }
                }
                lastDamageTime = Time.time;
            }
        }
    }

    private IEnumerator StayAndScale()
    {
        isStationary = true;

        // Guarda la posici�n original del proyectil
        Vector3 originalPosition = transform.position;

        // Escala el proyectil
        transform.localScale *= scaleIncrease;

        // Espera el tiempo especificado
        yield return new WaitForSeconds(waitTime);

        // Destruye el proyectil
        Destroy(this.gameObject);
    }
}
