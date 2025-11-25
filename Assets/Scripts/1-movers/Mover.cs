using UnityEngine;

/// <summary>
/// This component moves its object in a fixed velocity.
/// NOTE: velocity is defined as speed + direction.
///       speed is a number; velocity is a vector.
/// </summary>
public class Mover : MonoBehaviour
{
    [Tooltip("Movement vector in meters per second")]
    [SerializeField] private Vector3 velocity;

    private void Update()
    {
        transform.position += velocity * Time.deltaTime;
    }

    /// <summary>
    /// Sets the movement velocity.
    /// </summary>
    /// <param name="newVelocity">The new velocity vector.</param>
    public void SetVelocity(Vector3 newVelocity)
    {
        velocity = newVelocity;
    }
}
