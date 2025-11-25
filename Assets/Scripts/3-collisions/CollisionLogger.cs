using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * This component logs all four kinds of collisions involving its object.
 */
public class CollisionLogger : MonoBehaviour
{
    private void Start()
    {
        Debug.Log($"Start CollisionLogger on {name}");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log($"{name} Trigger 2D with name={other.name} tag={other.tag}");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Collider2D other = collision.collider;
        Debug.Log($"{name} Collision 2D with name={other.name} tag={other.tag}");
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"{name} Trigger with name={other.name} tag={other.tag}");
    }

    private void OnCollisionEnter(Collision collision)
    {
        Collider other = collision.collider;
        Debug.Log($"{name} Collision with name={other.name} tag={other.tag}");
    }
}
