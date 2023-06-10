using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour
{
    public void LoadNextLevel()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        PlayerPrefs.SetInt("CurrentScene", PlayerPrefs.GetInt("CurrentScene") + 1);
        SceneManager.LoadScene(PlayerPrefs.GetInt("CurrentScene"));
    }
}
