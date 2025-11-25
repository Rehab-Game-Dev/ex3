using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * This component destroys its object whenever it triggers a 2D collider with the given tag.
 */
public class DestroyOnTrigger2D : MonoBehaviour
{
    [Tooltip("Every object tagged with this tag will trigger the destruction of both objects")]
    [SerializeField] private string triggeringTag;

    // "public event" means that other objects can just subscribe or unsubscribe, but not modify the event directly
    public event System.Action onHit;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == triggeringTag && enabled)
        {
            // destroy both objects
            Destroy(gameObject);
            Destroy(other.gameObject);

            // add points to player score
            GAME_STATUS.playerScore += 1;

            // invoke any subscribers
            onHit?.Invoke();
        }
    }

    private void Update()
    {
        // Just to show the enabled checkbox in Editor
    }
}
