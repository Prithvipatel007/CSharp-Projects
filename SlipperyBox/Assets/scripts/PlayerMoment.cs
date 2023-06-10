using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection.Emit;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMoment : MonoBehaviour
{
    public BoxCollider playerBoxColloider;

    public Rigidbody rb;

    public float forwardForce = 3000f;

    public float sidewaysForce = 8000f;

    public float speed = 15000f;

    public int bullets = 0;

    public int coins = 0;

    public Rigidbody theBullet;

    public Rigidbody Clone;

    public bool isShooting = false;

    public GameObject PhasingPowerUpEffect;

    public Joystick joystick;

    private GUIStyle guistyle;

    public Text ammo;

    private void Start()
    {
        guistyle = new GUIStyle();
        if(PlayerPrefs.GetInt("Bullets") != 0)
        {
            if(SceneManager.GetActiveScene().name != "Credits")
            {
                bullets = bullets + PlayerPrefs.GetInt("Bullets");
                coins = coins + PlayerPrefs.GetInt("Coins");
            }
            else
            {
                bullets = 0;
                PlayerPrefs.SetInt("Bullets", 0);
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Add a forward force
        rb.AddForce(0, 0, forwardForce * Time.deltaTime); // time.deltatime is the amount of time since the computer drew that last frame     

        var hoizontalAxis = joystick.Horizontal;
        var comphoizontalAxis = Input.GetAxis("Horizontal");
        //rb.AddForce(sidewaysForce * Time.deltaTime * hoizontalAxis, 0, 0, ForceMode.Force);


        rb.AddForce(sidewaysForce * Time.deltaTime * comphoizontalAxis, 0, 0, ForceMode.Force);

        if ((hoizontalAxis > 0.5f && hoizontalAxis > 0f) || (hoizontalAxis < 0f && hoizontalAxis < -0.5f))
        {
            rb.AddForce(sidewaysForce * Time.deltaTime * hoizontalAxis, 0, 0, ForceMode.Force);
        }

        if ((Input.GetKey(KeyCode.UpArrow)) && bullets > 0 && !isShooting)
        {
            isShooting = true;
            bullets--;
            StartCoroutine(ShootingDone());
        }

        if (rb.position.y < -3f || rb.position.y > 2.5f || rb.position.x > 9f || rb.position.x < -9f) // upside and downside bounds
        {
            if (SceneManager.GetActiveScene().name == "FreeMode" ) // left and right bounds only when it is in free mode
            {
                FindObjectOfType<AdManager>().PlayInterstitialAd();
            }
            else if (SceneManager.GetActiveScene().name == "Guide")
            {
                FindObjectOfType<AdManager>().PlayInterstitialAd();
            }
            else
                FindObjectOfType<GameManager>().CheckToContinue();
            //FindObjectOfType<GameManager>().EndGame();
        }

        if(SceneManager.GetActiveScene().buildIndex != 0)
        {
            ammo.text = (bullets).ToString();
        }

    }

    public IEnumerator ShootingDone()
    {
        Clone = Instantiate(theBullet, transform.position, transform.rotation);
        Clone.velocity = transform.TransformDirection(new Vector3(0, 0, speed * Time.deltaTime));
        yield return new WaitForSeconds(0.2f);
        Destroy(Clone.gameObject, 0.2f);
        isShooting = false;
    }

    public void DisableMovement()
    {
        forwardForce = 0.0f;
        sidewaysForce = 0.0f;
        isShooting = true;
        rb.drag = 10000f;
    }

    public void EnableMovement()
    {
        forwardForce = 4000f;
        sidewaysForce = 2000f;
        isShooting = false;
        rb.drag = 1f;
    }

    public IEnumerator PhasingDelay3sec()
    {
        PhasingPowerUpEffect.SetActive(true);
        playerBoxColloider.enabled = false;
        rb.useGravity = false;
        yield return new WaitForSeconds(6.0f);
    }

    public IEnumerator PhasingDelayStop()
    {
        Invoke("PhasingStop", 7.0f);
        yield return null;
    }

    public void  PhasingStop()
    {
        PhasingPowerUpEffect.SetActive(false);
        playerBoxColloider.enabled = true;
        rb.useGravity = true;
    }

    public void ShootfromUI()
    {
        if (bullets > 0 && !isShooting && FindObjectOfType<ShootButtonAndroid>().isshoot)
        {
            isShooting = true;
            bullets--;
            StartCoroutine(ShootingDone());
        }
    }
}
