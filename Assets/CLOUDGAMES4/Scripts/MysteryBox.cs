using UnityEngine;
public class MysteryBox : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private GameObject[] powerUps; // Los prefabs de los power ups
    [SerializeField] private float[] powerUpProbabilities; // Las probabilidades de los power ups

    private Rigidbody2D _compRigidbody2D;

    private void Awake()
    {
        _compRigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        // La caja se mueve en el eje x negativo al instanciarse
        _compRigidbody2D.linearVelocity = new Vector2(-speed, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Cuando el jugador colisiona con la caja...
        if (collision.tag == "Player")
        {
            // Seleccionamos un power up basado en las probabilidades
            int randomIndex = GetRandomPowerUpIndex();

            // Si el �ndice es igual a la longitud del arreglo, entonces el power up es el de aumentar vida
            if (randomIndex == powerUps.Length)
            {
                // Aumentamos la vida del jugador en un rango de 1 a 3 vidas
                AudioManagerController.Instance.PlaySfx(2);
                PlayerController.Instance.Life += Random.Range(1, 4);
            }
            else
            {
                AudioManagerController.Instance.PlaySfx(1);
                // Si no, asignamos el power up seleccionado al jugador
                GameObject powerUp = powerUps[randomIndex];
                PlayerController.Instance.currentPowerUp = powerUp;
            }

            // Destruimos la caja
            Destroy(this.gameObject);
        }
        else if (collision.tag == "SpriteEliminator")
        {
            Destroy(this.gameObject);
        }
    }

    private int GetRandomPowerUpIndex()
    {
        float total = 0;
        foreach (float elem in powerUpProbabilities)
        {
            total += elem;
        }

        float randomPoint = Random.value * total;
        for (int i = 0; i < powerUpProbabilities.Length; i++)
        {
            if (randomPoint < powerUpProbabilities[i])
            {
                if (PlayerController.Instance.currentPowerUp != powerUps[i] || i == powerUps.Length)
                {
                    return i;
                }
                else
                {
                    return GetRandomPowerUpIndex();
                }
            }
            else
            {
                randomPoint -= powerUpProbabilities[i];
            }
        }
        return powerUpProbabilities.Length; // Devuelve el �ndice para aumentar vida
    }
}
