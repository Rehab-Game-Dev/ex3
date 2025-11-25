using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// This component spawns the given object whenever the player clicks a given key.
/// </summary>
public class ClickSpawner : MonoBehaviour
{
    [SerializeField] protected InputAction spawnAction = new InputAction(type: InputActionType.Button);
    [SerializeField] protected GameObject prefabToSpawn;
    [SerializeField] protected Vector3 velocityOfSpawnedObject;

    private void OnEnable()
    {
        spawnAction.Enable();
    }

    private void OnDisable()
    {
        spawnAction.Disable();
    }

    /// <summary>
    /// Spawns the object and sets its velocity if it has a Mover component.
    /// </summary>
    /// <returns>The spawned GameObject.</returns>
    protected virtual GameObject SpawnObject()
    {
        Debug.Log("Spawning a new " + prefabToSpawn.name);

        // Step 1: Spawn the new object at this object's position with no rotation
        Vector3 positionOfSpawnedObject = transform.position;
        Quaternion rotationOfSpawnedObject = Quaternion.identity;
        GameObject newObject = Instantiate(prefabToSpawn, positionOfSpawnedObject, rotationOfSpawnedObject);

        // Step 2: Set the velocity if it has a Mover component
        Mover newObjectMover = newObject.GetComponent<Mover>();
        if (newObjectMover != null)
        {
            newObjectMover.SetVelocity(velocityOfSpawnedObject);
        }

        return newObject;
    }

    private void Update()
    {
        if (spawnAction.WasPressedThisFrame())
        {
            SpawnObject();
        }
    }
}
