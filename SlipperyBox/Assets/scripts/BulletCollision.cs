using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }

        if (collision.collider.CompareTag("Boss"))
        {
            Destroy(gameObject);
        }

        if (collision.collider.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
