using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootButtonAndroid : MonoBehaviour
{
    public bool isshoot = false;

    // Update is called once per frame
    void FixedUpdate()
    {
        FindObjectOfType<PlayerMoment>().ShootfromUI();
    }

    public void Shootstart()
    {
        isshoot = true;
    }

    public void ShootStop()
    {
        isshoot = false;
    }

}
