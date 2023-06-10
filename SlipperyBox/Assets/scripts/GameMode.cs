using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMode : MonoBehaviour
{
    public int SelectedGameModeValue;

    public void HandleInput(int val)
    {
        if(val == 0)
        {
            SelectedGameModeValue = 0;
        }
        else if(val == 1)
        {
            SelectedGameModeValue = 1;
        }
    }
}