using UnityEngine;
using UnityEngine.InputSystem;
public class CharacterController3D : MonoBehaviour
{
    private Rigidbody myRB;
    private float speed = 5f;
    private float jumpForce = 10f;

    private Vector2 movementInput;
    private bool isJumping = false;

    private void Start()
    {
        myRB = GetComponent<Rigidbody>();
    }
    public void OnMovement(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            movementInput = context.ReadValue<Vector2>();
        }
        else if (context.canceled)
        {
            movementInput = Vector2.zero;
        }
    }
    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed && IsGrounded())
        {
            isJumping = true;
        }
    }

    private void FixedUpdate()
    {
        ApplyPhysics();
    }
    private void ApplyPhysics()
    {
        Vector3 movement = new Vector3(movementInput.x, 0, movementInput.y) * speed;
        Vector3 newVelocity = new Vector3(movement.x, myRB.linearVelocity.y, movement.z);
        myRB.linearVelocity = newVelocity;

        if (isJumping)
        {
            myRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isJumping = false;
        }
    }
    private bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, 1.1f);
    }
}