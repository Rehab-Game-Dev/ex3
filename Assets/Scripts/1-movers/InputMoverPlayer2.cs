using UnityEngine;
using UnityEngine.InputSystem;

/**
 * Controls Player 2 using WASD + LeftCtrl to shoot
 */
public class InputMoverPlayer2 : MonoBehaviour {

    [SerializeField] float speed = 10f;
    [SerializeField] float boostMultiplier = 2f;

    // SHOOT event
    public System.Action OnShoot;

    void Update() {
        Vector2 moveDirection = Vector2.zero;

        //  WASD
        if (Keyboard.current.wKey.isPressed) moveDirection.y += 1;
        if (Keyboard.current.sKey.isPressed) moveDirection.y -= 1;
        if (Keyboard.current.aKey.isPressed) moveDirection.x -= 1;
        if (Keyboard.current.dKey.isPressed) moveDirection.x += 1;

        //  Shift
        float currentSpeed = speed;
        if (Keyboard.current.leftShiftKey.isPressed)
            currentSpeed *= boostMultiplier;

        // MOVEMENT
        Vector3 movement = new Vector3(moveDirection.x, moveDirection.y, 0)
                           * currentSpeed * Time.deltaTime;

        transform.position += movement;

        // SHOOT WITH Ctrl
        if (Keyboard.current.leftCtrlKey.wasPressedThisFrame ||
            Keyboard.current.rightCtrlKey.wasPressedThisFrame)
        {
            OnShoot?.Invoke();
        }
    }
}
