using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.UI;

public class Seq001Opening : MonoBehaviour
{
    [SerializeField]
    public GameObject ThePlayer;

    [SerializeField]
    public GameObject FadeScreenIn;

    [SerializeField]
    public GameObject TextBox;


    // Start is called before the first frame update
    void Start()
    {
        ThePlayer.GetComponent<FirstPersonController>().enabled = false;        // disable the momvement in the beginning

        StartCoroutine(ScenePlayer());

    }

    IEnumerator ScenePlayer()
    {
        yield return new WaitForSeconds(1.5f);
        FadeScreenIn.SetActive(false);
        TextBox.GetComponent<Text>().text = "I need to get out of here";
        yield return new WaitForSeconds(2f);
        TextBox.GetComponent<Text>().text = "";
        ThePlayer.GetComponent<FirstPersonController>().enabled = true;        // enable the momvement in the beginning

    }
}
