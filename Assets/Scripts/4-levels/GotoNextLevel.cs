using UnityEngine;
using UnityEngine.SceneManagement;

/**
 * This component moves the GameObject to the origin and loads the specified scene
 * when an object with the given tag enters its trigger.
 */
public class GotoNextLevel : MonoBehaviour
{
    [Tooltip("Every object tagged with this tag will trigger the scene change")]
    [SerializeField] private string triggeringTag;

    [Tooltip("Name of the scene to move to when triggering the given tag")]
    [SerializeField] private string sceneName;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(triggeringTag))
        {
            Debug.Log($"Moving {name} to origin and loading scene {sceneName}");
            transform.position = Vector3.zero;
            SceneManager.LoadScene(sceneName);
        }
    }
}
