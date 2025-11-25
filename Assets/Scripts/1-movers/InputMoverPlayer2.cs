using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Controls Player 2 using WASD + LeftCtrl/RightCtrl to shoot.
/// </summary>
public class InputMoverPlayer2 : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private float boostMultiplier = 2f;

    /// <summary>
    /// Event invoked when shooting.
    /// </summary>
    public System.Action OnShoot;

    private void Update()
    {
        Vector2 moveDirection = Vector2.zero;

        // WASD movement
        if (Keyboard.current.wKey.isPressed) moveDirection.y += 1;
        if (Keyboard.current.sKey.isPressed) moveDirection.y -= 1;
        if (Keyboard.current.aKey.isPressed) moveDirection.x -= 1;
        if (Keyboard.current.dKey.isPressed) moveDirection.x += 1;

        // Shift boost
        float currentSpeed = speed;
        if (Keyboard.current.leftShiftKey.isPressed)
        {
            currentSpeed *= boostMultiplier;
        }

        // Movement
        Vector3 movement = new Vector3(moveDirection.x, moveDirection.y, 0f)
                           * currentSpeed * Time.deltaTime;
        transform.position += movement;

        // Shoot with Ctrl
        if (Keyboard.current.leftCtrlKey.wasPressedThisFrame ||
            Keyboard.current.rightCtrlKey.wasPressedThisFrame)
        {
            OnShoot?.Invoke();
        }
    }
}
