using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhasingPowerUp : MonoBehaviour
{
    public float speed = 100f;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0f, 1f, 0f) * Time.deltaTime * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            FindObjectOfType<AudioManager>().Play("Phasing");

            StartCoroutine(FindObjectOfType<PlayerMoment>().PhasingDelay3sec());
            StartCoroutine(FindObjectOfType<PlayerMoment>().PhasingDelayStop());

            Destroy(gameObject);

        }
    }

}
