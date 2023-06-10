using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement : MonoBehaviour
{
    private bool isBossShooting = false;

    private Rigidbody clone;

    public float speed = -15000f;

    public Rigidbody theBossBullet;

    public Rigidbody Boss;

    private void FixedUpdate()
    {
        clone = Instantiate(theBossBullet, Boss.position, transform.rotation);
        clone.velocity = transform.TransformDirection(new Vector3(0, 0, speed * Time.deltaTime));
        Destroy(clone.gameObject, 0.2f);
    }
}
