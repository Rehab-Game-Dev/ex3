using UnityEngine;

/// <summary>
/// This component spawns the given laser prefab whenever the player clicks a given key.
/// It also updates the "scoreText" field of the new laser.
/// </summary>
public class LaserShooter : ClickSpawner
{
    [SerializeField]
    [Tooltip("How many points to add to the shooter, if the laser hits its target")]
    private int pointsToAdd = 1;

    /// <summary>
    /// Reference to the field that holds the score to be updated when the laser hits its target.
    /// </summary>
    private NumberField scoreField;

    private void Start()
    {
        scoreField = GetComponentInChildren<NumberField>();
        if (scoreField == null)
        {
            Debug.LogError($"No child of {gameObject.name} has a NumberField component!");
        }
    }

    private void AddScore()
    {
        scoreField.AddNumber(pointsToAdd);
    }

    /// <summary>
    /// Spawns the laser and registers the AddScore callback on hit.
    /// </summary>
    /// <returns>The spawned laser GameObject.</returns>
    protected override GameObject SpawnObject()
    {
        GameObject newObject = base.SpawnObject();

        DestroyOnTrigger2D newObjectDestroyer = newObject.GetComponent<DestroyOnTrigger2D>();
        if (newObjectDestroyer != null)
        {
            newObjectDestroyer.onHit += AddScore;
        }

        return newObject;
    }
}
