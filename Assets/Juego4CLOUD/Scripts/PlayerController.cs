using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;
public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance { get; private set; }
    private Rigidbody2D _compRigidbody2D;
    private Vector2 inputDirection;
    [Header("Player Settings")]
    [SerializeField] private int speed;
    [SerializeField] private int life;
    [SerializeField] private int maxLife;
    public GameData gameData;
    [Header("Player Bullets")]
    [SerializeField] private GameObject basicbullet;
    [SerializeField] public GameObject currentPowerUp; // El power up actual
    [SerializeField] private float fireRate;
    private bool isFiring = false;
    private float nextFire = 0.0f;
    [Header("Player Events")]
    public UnityEvent<int> OnPlayerDamage;
    public int Life
    {
        get
        {
            return life;
        }
        set
        {
            int oldLife = life;
            if (value > maxLife)
            {
                life = maxLife;
            }
            else
            {
                life = value;
            }
            OnPlayerDamage?.Invoke(life);
            // Cuando el jugador pierde una vida, vuelve a usar el disparo normal
            if (life < oldLife)
            {
                currentPowerUp = null;
            }
            // Si la vida llega a 0, cambiamos a la escena de "game over"
            if (life <= 0)
            {
                GameManagerController.Instance.ChangeScene("GameOver");
            }
        }
    }
    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
        _compRigidbody2D = GetComponent<Rigidbody2D>();

        OnPlayerDamage?.Invoke(life);
    }
    private void Start()
    {
        UIManagerController.Instance.lifeBar.maxValue = maxLife;
    }
    public void Movimiento(InputAction.CallbackContext context)
    {
        inputDirection = context.ReadValue<Vector2>();
    }
    public void Disparar(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            isFiring = true;
        }
        else if (context.canceled)
        {
            isFiring = false;
        }
    }
    void FixedUpdate()
    {
        _compRigidbody2D.linearVelocity = new Vector2(inputDirection.x * speed, inputDirection.y * speed);
    }
    void Update()
    {
        if (isFiring && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            // Si el jugador tiene un power up, lo usa
            if (currentPowerUp != null)
            {
                Instantiate(currentPowerUp, transform.position, Quaternion.identity);
            }
            // Si no, usa el disparo normal
            else
            {
                AudioManagerController.Instance.PlaySfx(3);
                Instantiate(basicbullet, transform.position, Quaternion.identity);
            }
        }
    }
}
