using System.Collections;
using System.Threading.Tasks;
using UnityEngine;

/// <summary>
/// This component instantiates a given prefab at random time intervals
/// and at a random X bias from its object position.
/// </summary>
public class TimedSpawnerRandom : MonoBehaviour
{
    [SerializeField] private Mover prefabToSpawn;
    [SerializeField] private Vector3 velocityOfSpawnedObject;

    [Tooltip("Minimum time between consecutive spawns, in seconds")]
    [SerializeField] private float minTimeBetweenSpawns = 0.2f;

    [Tooltip("Maximum time between consecutive spawns, in seconds")]
    [SerializeField] private float maxTimeBetweenSpawns = 1.0f;

    [Tooltip("Maximum distance in X between spawner and spawned objects, in meters")]
    [SerializeField] private float maxXDistance = 1.5f;

    [SerializeField] private Transform parentOfAllInstances;

    private void Start()
    {
        SpawnRoutine();
    }

    /// <summary>
    /// Spawns objects continuously at random intervals and X offsets.
    /// </summary>
    private async void SpawnRoutine()
    {
        while (true)
        {
            float timeBetweenSpawns = Random.Range(minTimeBetweenSpawns, maxTimeBetweenSpawns);
            await Awaitable.WaitForSecondsAsync(timeBetweenSpawns);

            if (!this) break; // Stop if the spawner is destroyed

            Vector3 positionOfSpawnedObject = new Vector3(
                transform.position.x + Random.Range(-maxXDistance, maxXDistance),
                transform.position.y,
                transform.position.z);

            GameObject newObject = Instantiate(prefabToSpawn.gameObject, positionOfSpawnedObject, Quaternion.identity);

            Mover mover = newObject.GetComponent<Mover>();
            if (mover != null)
            {
                mover.SetVelocity(velocityOfSpawnedObject);
            }

            if (parentOfAllInstances != null)
            {
                newObject.transform.parent = parentOfAllInstances;
            }
        }
    }
}
