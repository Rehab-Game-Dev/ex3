using System.Collections;
using System.Threading.Tasks;
using UnityEngine;

/// <summary>
/// This component spawns the given object at fixed time intervals at this object's position.
/// </summary>
public class TimedSpawner : MonoBehaviour
{
    [SerializeField] private Mover prefabToSpawn;
    [SerializeField] private Vector3 velocityOfSpawnedObject;
    [SerializeField] private float secondsBetweenSpawns = 1f;

    private void Start()
    {
        SpawnRoutine();
        Debug.Log("Start finished");
    }

    /// <summary>
    /// Spawns objects continuously at fixed intervals.
    /// </summary>
    private async void SpawnRoutine()
    {
        while (true)
        {
            GameObject newObject = Instantiate(prefabToSpawn.gameObject, transform.position, Quaternion.identity);
            Mover newMover = newObject.GetComponent<Mover>();
            if (newMover != null)
            {
                newMover.SetVelocity(velocityOfSpawnedObject);
            }

            await Awaitable.WaitForSecondsAsync(secondsBetweenSpawns);
            // For more options, see: https://docs.unity3d.com/6000.0/Documentation/Manual/async-awaitable-introduction.html
        }
    }
}
