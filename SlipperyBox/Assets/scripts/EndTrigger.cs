using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            PlayerPrefs.SetInt("Coins", FindObjectOfType<PlayerMoment>().coins);
            PlayerPrefs.SetInt("Bullets", FindObjectOfType<PlayerMoment>().bullets);
            FindObjectOfType<GameManager>().completeLevel();
        }
    }
}
