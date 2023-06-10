using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    //private Animator animator;

    // indicates if the checkpoint is sactivated or not
    public bool Activated = false;

    public static List<GameObject> CheckPointList;

    // Start is called before the first frame update
    void Start()
    {
        //animator = GetComponent<Animator>();

        CheckPointList = GameObject.FindGameObjectsWithTag("CheckPoint").ToList();
    }

    private void OnTriggerEnter(Collider other)
    {
        // if player passes through checkpoint, save that point
        if (other.CompareTag("Player"))
        {
            ActivateCheckPoint();
        }
    }

    private void ActivateCheckPoint()
    {
        // deactivate all checkpoints in the scene
        foreach (GameObject cp in CheckPointList)
        {
            cp.GetComponent<CheckPoint>().Activated = false;
            //cp.GetComponent<Animator>().SetBool("active", false);
        }
        // activate only for current checkpoint
        Activated = true;
        //animator.SetBool("Active", true);
    }

    public static Vector3 GetActiveCheckpointPosition()
    {
        // if player dies without activating the checkpoint, then starts from the beginning
        Vector3 result = new Vector3(0, 1, 0);

        if(CheckPointList != null)
        {
            foreach (GameObject cp in CheckPointList)
            {
                // search for the activated checkpoint to get its position
                if (cp.GetComponent<CheckPoint>().Activated)
                {
                    result = cp.transform.position;
                    break;
                }
            }
        }

        return result;
    }
}
