using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seq002JumpScare : MonoBehaviour
{
    [SerializeField]
    public AudioSource DoorBang;

    [SerializeField]
    public AudioSource DoorJumpMusic;

    [SerializeField]
    public GameObject TheZombie;

    [SerializeField]
    public GameObject TheDoor;

    void OnTriggerEnter(Collider other)
    {
        GetComponent<BoxCollider>().enabled = false;
        TheDoor.GetComponent<Animation>().Play("JumpScareDoorAnim");
        DoorBang.Play();
        TheZombie.SetActive(true);
        StartCoroutine(PlayJumpMusic());
    }

    IEnumerator PlayJumpMusic()
    {
        yield return new WaitForSeconds(0.4f);
        DoorJumpMusic.Play();
    }
}
