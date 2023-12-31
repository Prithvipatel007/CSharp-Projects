﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;

    public Vector3 offset;

    // Update is called once per frame
    void Update()
    {
        // transform.position belongs to the main camera
        // and player.position belongs to the player
        transform.position = player.position + offset;
    }
}
