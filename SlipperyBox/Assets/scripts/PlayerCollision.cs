using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour
{
    public ParticleSystem particleSystem;

    private Rigidbody thisRigidBody;

    private void Start()
    {
        thisRigidBody = GetComponent<Rigidbody>();
    }

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Obstacle")
        {
            FindObjectOfType<AudioManager>().Play("PlayerDeath");

            if (SceneManager.GetActiveScene().name == "FreeMode")
            {
                //Destroy();
                FindObjectOfType<AdManager>().PlayInterstitialAd();
            }
            
            if (SceneManager.GetActiveScene().name == "Guide")
            {
                //Destroy();
                FindObjectOfType<AdManager>().PlayInterstitialAd();
            }
            else
                FindObjectOfType<GameManager>().CheckToContinue();

            //Destroy();
            //movement.enabled = false;
            //FindObjectOfType<GameManager>().EndGame();
        }
    }



    void Destroy()
    {
        Instantiate(particleSystem, transform.position, Quaternion.identity);
        gameObject.SetActive(false);
    }

    IEnumerator delay()
    {
        yield return new WaitForSeconds(2.0f);
    }

}
