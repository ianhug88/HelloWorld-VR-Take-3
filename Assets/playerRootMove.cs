using UnityEngine;
using UnityEngine.InputSystem;

public class RigidbodyLocomotion : MonoBehaviour
{
    public Rigidbody rb;
    public Transform head; // drag Main Camera here
    public InputActionProperty moveInput;
    public float speed = 3f;

    void FixedUpdate()
    {
        Vector2 input = moveInput.action.ReadValue<Vector2>();

        Vector3 direction = new Vector3(input.x, 0f, input.y);

        // Make movement relative to head direction
        direction = head.TransformDirection(direction);
        direction.y = 0f;

        rb.MovePosition(
            rb.position + direction * speed * Time.fixedDeltaTime
        );
    }
}



