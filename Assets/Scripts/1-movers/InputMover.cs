using UnityEngine;
using UnityEngine.InputSystem;

/**
 * This component moves its object when the player clicks the arrow keys.
 */
public class InputMover: MonoBehaviour {
    [Tooltip("Speed of movement, in meters per second")]
    [SerializeField] float speed = 10f;

    [Tooltip("Speed multiplier when holding Shift")]
    [SerializeField] float boostMultiplier = 2f;

    [SerializeField] InputAction move = new InputAction(
        type: InputActionType.Value, expectedControlType: nameof(Vector2));

    void OnEnable()  {
        move.Enable();
    }

    void OnDisable()  {
        move.Disable();
    }

    void Update() {
        Vector2 moveDirection = move.ReadValue<Vector2>();

        float currentSpeed = speed;

        // boost with Shift
        if (Keyboard.current.rightShiftKey.isPressed) {
            currentSpeed *= boostMultiplier;
        }

        Vector3 movementVector = new Vector3(moveDirection.x, moveDirection.y, 0) 
                                 * currentSpeed * Time.deltaTime;

        transform.position += movementVector;
    }
}
