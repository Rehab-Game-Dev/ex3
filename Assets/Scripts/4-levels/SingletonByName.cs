using System.Linq;
using UnityEngine;

/**
 * Implements a singleton pattern in Unity:
 * ensures that there is exactly one GameObject with this name.
 * 
 * @author Erel Segal-Halevi
 * @since 2020-02
 */
public class SingletonByName : MonoBehaviour
{
    private void Awake()
    {
        string myName = gameObject.name;

        // Find all GameObjects in the scene with the same name
        GameObject[] otherObjectsWithSameName = Resources
            .FindObjectsOfTypeAll<GameObject>()
            .Where(obj => obj.name == myName)
            .ToArray();

        Debug.Log($"otherObjectsWithSameName.Length: {otherObjectsWithSameName.Length}");

        if (otherObjectsWithSameName.Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
