using System.Security.Cryptography;
using UnityEngine;

public class OstacleCollision : MonoBehaviour
{
    public Rigidbody Bullet;

    public ParticleSystem particleSystem;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            FindObjectOfType<AudioManager>().Play("BurstSound");
            Destroy(gameObject);
            Instantiate(particleSystem, transform.position, Quaternion.identity);
        }
    }
}
