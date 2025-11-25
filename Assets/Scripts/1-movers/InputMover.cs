using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// This component moves its object when the player clicks the arrow keys.
/// </summary>
public class InputMover : MonoBehaviour
{
    [Tooltip("Speed of movement, in meters per second")]
    [SerializeField] private float speed = 10f;

    [Tooltip("Speed multiplier when holding Shift")]
    [SerializeField] private float boostMultiplier = 2f;

    [SerializeField]
    private InputAction move = new InputAction(
        type: InputActionType.Value,
        expectedControlType: nameof(Vector2)
    );

    private void OnEnable()
    {
        move.Enable();
    }

    private void OnDisable()
    {
        move.Disable();
    }

    private void Update()
    {
        Vector2 moveDirection = move.ReadValue<Vector2>();
        float currentSpeed = speed;

        // Boost with Shift
        if (Keyboard.current.rightShiftKey.isPressed)
        {
            currentSpeed *= boostMultiplier;
        }

        Vector3 movementVector = new Vector3(moveDirection.x, moveDirection.y, 0f)
                                 * currentSpeed * Time.deltaTime;

        transform.position += movementVector;
    }
}
