using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePistol : MonoBehaviour
{
    [SerializeField]
    public GameObject TheGun;

    [SerializeField]
    public GameObject MuzzleFlash;

    [SerializeField]
    public AudioSource GunFire;

    public bool isFiring = false;
    
    [SerializeField]
    public float TargetDistance;

    [SerializeField]
    public int DamageAmount = 5;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if(isFiring == false)
            {
                StartCoroutine(FiringPistol());
            }
        }
    }

    IEnumerator FiringPistol()
    {
        isFiring = true;
        RaycastHit Shot;

        if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out Shot))
        {
            TargetDistance = Shot.distance;
            Shot.transform.SendMessage("DamageZombie", DamageAmount, SendMessageOptions.DontRequireReceiver);
        }

        TheGun.GetComponent<Animation>().Play("PistolShotAnim");
        MuzzleFlash.SetActive(true);
        MuzzleFlash.GetComponent<Animation>().Play("MuzzleAnim");
        GunFire.Play();
        yield return new WaitForSeconds(0.5f);
        isFiring = false;
        MuzzleFlash.SetActive(false);
    }
}
