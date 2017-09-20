using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    public Rigidbody2D myRigi;

    private Shield shield = null;

    private void Start()
    {
        // get the player object, and then the shield script from that
        GameObject player = GameObject.FindWithTag("Player");
        shield = player.GetComponent<Shield>();
    }

    void Update()
    {
        Fall();
    }

    void Fall()
    {
        myRigi.velocity = new Vector3(0, -9.8f, 0);
    }

    // Collision with the player will destroy the player object unless shield is on
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !shield.GetShield()) 
        {
            Debug.Log("TRIGGERED");
            Destroy(collision.gameObject);
        }
    }
}
