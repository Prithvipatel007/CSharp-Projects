using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollection : MonoBehaviour
{
    public float speed = 100f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0f,1f,0f) * Time.deltaTime * speed);

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            FindObjectOfType<AudioManager>().Play("BulletCollected");
            other.GetComponent<PlayerMoment>().bullets = other.GetComponent<PlayerMoment>().bullets + 10;
            //PlayerPrefs.SetInt("Bullets", other.GetComponent<PlayerMoment>().bullets);
            Destroy(gameObject);
        }
    }
}
