using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{
    public void Start()
    {
        PlayerPrefs.SetInt("CurrentScene", 0);
        FindObjectOfType<PlayerMoment>().bullets = 0;
        PlayerPrefs.SetInt("Bullets", 0);
    }

    public void quit()
    {
        PlayerPrefs.SetInt("CurrentScene", 0);
        Application.Quit();
    }
}
