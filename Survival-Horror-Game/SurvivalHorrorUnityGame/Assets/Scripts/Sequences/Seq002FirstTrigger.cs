using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.UI;

public class Seq002FirstTrigger : MonoBehaviour
{
    [SerializeField]
    public GameObject ThePlayer;

    [SerializeField]
    public GameObject TextBox;

    [SerializeField]
    public GameObject TheMarker;

    [SerializeField]
    public GameObject Trigger;

    private void OnTriggerEnter(Collider other)
    {
        ThePlayer.GetComponent<FirstPersonController>().enabled = false;
        StartCoroutine(ScenePlayer());
    }

    IEnumerator ScenePlayer()
    {
        TextBox.GetComponent<Text>().text = "Looks like a weapon on the table";
        yield return new WaitForSeconds(2.5f);
        TextBox.GetComponent<Text>().text = "";
        ThePlayer.GetComponent<FirstPersonController>().enabled = true;
        TheMarker.SetActive(true);
        Trigger.GetComponent<BoxCollider>().enabled = false;

    }
}
