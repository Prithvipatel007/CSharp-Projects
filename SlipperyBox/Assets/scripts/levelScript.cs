using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class levelScript : MonoBehaviour
{
    public Text level;

    // Update is called once per frame
    void Update()
    {
        var lvl = SceneManager.GetActiveScene().buildIndex - 1;
        level.text = lvl.ToString();
    }
}
