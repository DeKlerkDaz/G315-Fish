﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    public Rigidbody2D myRigi;

    void Update()
    {
        Fall();
    }

    void Fall()
    {
        myRigi.velocity = new Vector3(0, -9.8f, 0);
    }

    //Collision with the player will destroy the player object
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("TRIGGERED");
            Destroy(collision.gameObject);
        }
    }
}
