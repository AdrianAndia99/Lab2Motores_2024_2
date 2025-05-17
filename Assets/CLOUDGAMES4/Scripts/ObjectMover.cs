using UnityEngine;

public class ObjectMover : MonoBehaviour
{
    public float speed; // Velocidad de movimiento
    private Rigidbody2D _compRigidBody2D;

    private void Awake()
    {
        _compRigidBody2D = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        _compRigidBody2D.linearVelocity = new Vector2(-speed, 0);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "SpriteEliminator")
        {
            Destroy(this.gameObject);
        }
    }
}
