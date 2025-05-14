using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlatformController : MonoBehaviour
{
    private Vector2 movementInput;
    private Vector2 rotationInput;


    [SerializeField] private float speed;
    [SerializeField] private float rotationSpeed;


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
    public void OnRotate(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            rotationInput = context.ReadValue<Vector2>();
        }
        else if (context.canceled)
        {
            rotationInput = Vector2.zero;
        }
    }

    private void FixedUpdate()
    {
        Vector3 newPosition = transform.position + new Vector3(movementInput.x, 0, movementInput.y) * speed * Time.deltaTime;
        transform.position = newPosition;

        transform.Rotate(Vector3.forward * rotationInput.x * rotationSpeed * Time.deltaTime);

    }
}
