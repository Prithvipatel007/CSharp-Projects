using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreDistance : MonoBehaviour
{
    public Text HighScore;

    // Start is called before the first frame update
    void Start()
    {
        HighScore.text = PlayerPrefs.GetInt("HighScore").ToString("0");
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("HighScore") < FindObjectOfType<Score>().getScore())
        {
            PlayerPrefs.SetInt("HighScore", FindObjectOfType<Score>().getScore());
        }
    }
}
