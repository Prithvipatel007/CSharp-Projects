using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    bool gameHasEnded = false;

    public float restartDelay = 5.0f;

    public GameObject completeLevelUI;

    public Rigidbody rb;

    public GameObject WatchAdButton;

    public GameObject RestartButton;

    public void completeLevel()
    {
        FindObjectOfType<AdManager>().PlayInterstitialAd();
    }

    public void EndGame()
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            Debug.Log("Game Over");
            if (SceneManager.GetActiveScene().name == "FreeMode")
            {
                SceneManager.LoadScene("Menu");
            }
            else
            {
                Invoke("Restart", restartDelay);
            }
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //FindObjectOfType<PlayerMoment>().bullets = 0;
        // FindObjectOfType<PlayerMoment>().coins = 0;
    }

    public void GotoMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void quitGame()
    {
        Application.Quit();
    }

    public void SkipLevel()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        PlayerPrefs.SetInt("CurrentScene", PlayerPrefs.GetInt("CurrentScene") + 1);
        SceneManager.LoadScene(PlayerPrefs.GetInt("CurrentScene"));
    }

    public void GetToLastCheckPoint()
    {
        FindObjectOfType<PlayerMoment>().DisableMovement();
        StartCoroutine(delay());
        rb.transform.position = CheckPoint.GetActiveCheckpointPosition();
        Vector3 tempRotation = transform.rotation.eulerAngles;
        tempRotation.x = 0f;
        tempRotation.y = 0f;
        tempRotation.z = 0f;
        rb.transform.rotation = Quaternion.Euler(tempRotation);
    }

    IEnumerator delay()
    {
        yield return new WaitForSeconds(2.0f);
    }

    public void Continue()
    {
        // Watch full advertisement
        Debug.Log("Watching Advertisement");

        FindObjectOfType<AdManager>().PlayRewardedVideo();
    }

    public void CheckToContinue()
    {
        WatchAdButton.SetActive(true);
        RestartButton.SetActive(true);
        GetToLastCheckPoint();
    }

}
