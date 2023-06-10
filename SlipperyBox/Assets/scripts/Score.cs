using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Transform player;
    public Text scoreText;
    private int score;

    // Update is called once per frame
    void Update()
    {
        // player.position.z is how many steps we moved on z axis
        score = (int) player.position.z / 100  ;
        scoreText.text = score.ToString("0");
    }

    public int getScore()
    {
        return score;
    }
}
