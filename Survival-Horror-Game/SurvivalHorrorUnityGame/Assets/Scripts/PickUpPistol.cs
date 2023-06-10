using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUpPistol: MonoBehaviour
{
    public float TheDistance;

    [SerializeField]
    public GameObject ActionDisplay;
    
    [SerializeField]
    public GameObject ActionText;

    [SerializeField]
    public GameObject FakePistol;

    [SerializeField]
    public GameObject RealPistol;

    [SerializeField]
    public GameObject GuideArrow;

    [SerializeField]
    public GameObject ExtraCross;

    [SerializeField]
    public GameObject TheJumpTrigger;


    // Update is called once per frame
    void Update()
    {
        TheDistance = PlayerCasting.DistanceFromTarget;
    }

    void OnMouseOver()
    {
        if (TheDistance <= 1)
        {
            ExtraCross.SetActive(true);
            ActionText.GetComponent<Text>().text = "Pick Up Pistol";
            ActionText.SetActive(true);
            ActionDisplay.SetActive(true);
        }

        if (Input.GetButtonDown("Action"))
        {
            if(TheDistance <= 1)
            {
                ExtraCross.SetActive(true);
                this.GetComponent<BoxCollider>().enabled = false;
                ActionDisplay.SetActive(false);
                ActionText.SetActive(false);
                FakePistol.SetActive(false);
                RealPistol.SetActive(true);
                ExtraCross.SetActive(false);
                GuideArrow.SetActive(false);
                TheJumpTrigger.SetActive(true);

                // TODO: add pistol pickup sound
            }
        }
    }

    private void OnMouseExit()
    {
        ActionDisplay.SetActive(false);
        ActionText.SetActive(false);
        ExtraCross.SetActive(false);
        GuideArrow.SetActive(false);
    }

}
