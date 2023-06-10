using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DistanceTracking : MonoBehaviour
{

    public Transform player;
    public Transform end;

    float distance;
    float sliderCurrentValue;

    public Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(sliderCurrentValue == 0.9f)
        {
            slider.enabled = false;
            Debug.Log("Slider Destroyed");
        }
        else
        {
            distance = player.position.z - (end.position.z - player.position.z) * -0.0001f;
            sliderCurrentValue = distance / (end.position.z);
            slider.value = sliderCurrentValue;
            Debug.Log(sliderCurrentValue);
        }
        
    }
}
