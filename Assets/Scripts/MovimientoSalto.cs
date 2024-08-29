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

    [SerializeField] private float life;
    [SerializeField] private float maxLife;
    [SerializeField] BarraVida barraVida;

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
            TakeDamage(2);
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

    public void TakeDamage(float damage)
    {
        life -= damage;
        barraVida.CambiarVidaActual(life);
        if(life <= 0)
        {
            Debug.Log("Vida");
            Destroy(gameObject);
        }
    }
}