using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Welcome : MonoBehaviour
{
    public GameObject WelcomePanel;
    public GameObject ShopPanel;

    public void Start()
    {
        WelcomePanel.SetActive(true);
        ShopPanel.SetActive(false);
    }

    public void StartGame()
    {
        if (FindObjectOfType<GameMode>().SelectedGameModeValue == 0)
        {
            if (PlayerPrefs.GetInt("CurrentScene") < 1)
            {
                //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                PlayerPrefs.SetInt("CurrentScene", PlayerPrefs.GetInt("CurrentScene") + 1);
                SceneManager.LoadScene(PlayerPrefs.GetInt("CurrentScene"));
            }
            else
            {
                SceneManager.LoadScene(PlayerPrefs.GetInt("CurrentScene"));
            }

        }
        else if (FindObjectOfType<GameMode>().SelectedGameModeValue == 1)
            SceneManager.LoadScene("FreeMode");
    }

    public void EndGame()
    {
        Application.Quit();
    }

    public void Shopping()
    {
        WelcomePanel.SetActive(false);
        ShopPanel.SetActive(true);
    }

    public void BackToMenu()
    {
        WelcomePanel.SetActive(true);
        ShopPanel.SetActive(false);
    }

    public void GoToMenuFromCredits()
    {
        PlayerPrefs.SetInt("CurrentScene", 0);
        SceneManager.LoadScene("Menu");
    }

    public void GotoCredits()
    {
        SceneManager.LoadScene("Credits");
    }
}
