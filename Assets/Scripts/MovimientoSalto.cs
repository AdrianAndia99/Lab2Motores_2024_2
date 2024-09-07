using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovimientoSalto : MonoBehaviour
{
    public float speed;
    public float jumpforce;
    public int maxJumps = 2;
    int JumpsRemaining;
    private float moveInput;
    private Rigidbody2D rb2D;
    public Transform groundCheck;
    public float groundCheckDistance;
    public LayerMask whatIsGround;
    public Vector2 groundCheckDirection = Vector2.down;

    [SerializeField] private int life;
    [SerializeField] private int maxLife;
    [SerializeField] BarraVida barraVida;
    [SerializeField] private Manager gameManager;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();

        life = maxLife;
        barraVida.IniciarBarra(life);
    }

    void FixedUpdate()
    {
        rb2D.velocity = new Vector2(moveInput * speed, rb2D.velocity.y);
        IsGrounded();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemi"))
        {
            SpriteRenderer playerSpriteRenderer = GetComponent<SpriteRenderer>();
            SpriteRenderer enemySpriteRenderer = collision.gameObject.GetComponent<SpriteRenderer>();

            if (playerSpriteRenderer.color != enemySpriteRenderer.color)
            {
                TakeDamage(2);
            }
            else
            {
                Debug.Log("Colores iguales, no se recibe daño.");
            }
        }

        if (collision.gameObject.CompareTag("Insta"))
        {
            gameManager.EndGame(true);

        }else if (collision.gameObject.CompareTag("Respawn"))
        {
            gameManager.EndGame(false);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Money"))
        {
            int points = 10;
            GameEvents.ScoreUpdated(points);
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Heart"))
        {
            int healAmount = 20;
            Heal(healAmount);
            Destroy(other.gameObject);
        }
    }

    public void OnMovement(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>().x;
        Debug.Log("me muevo");
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (JumpsRemaining > 0)
        {
            if (context.performed)
            {
                rb2D.velocity = new Vector2(rb2D.velocity.x, jumpforce);
                JumpsRemaining--;
            }
            else if (context.canceled)
            {
                rb2D.velocity = new Vector2(rb2D.velocity.x, rb2D.velocity.y * 0.5f);
                JumpsRemaining--;
            }
            Debug.Log("SALTA");
        }
    }

    private void IsGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(groundCheck.position, groundCheckDirection, groundCheckDistance, whatIsGround);
        Debug.DrawLine(transform.position, transform.position + Vector3.down, Color.black);

        if (hit.collider != null)
        {
            JumpsRemaining = maxJumps;
        }
        else
        {
            JumpsRemaining = 0;
        }
    }

    public void TakeDamage(int damage)
    {
        life -= damage;
        life = Mathf.Clamp(life, 0, maxLife);

        barraVida.CambiarVidaActual(life);
        GameEvents.LifeUpdated(life);

        Debug.Log("Vida");
        if (life == 0)
        {
            GameEvents.GameEnd(false);
            Destroy(gameObject);
        }
    }
    public void Heal(int amount)
    {
        life += amount;
        life = Mathf.Clamp(life, 0, maxLife);

        barraVida.CambiarVidaActual(life);
        GameEvents.LifeUpdated(life);
    }
}