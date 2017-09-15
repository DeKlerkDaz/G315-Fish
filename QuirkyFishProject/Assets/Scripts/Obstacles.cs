using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{

    public GameObject Obstacle;
    public Rigidbody2D myRigi;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		 
	}

    //make a fall function cause gravity is too much for these bois

    //Collision with the player will destroy the player object
    private void OnCollisionEnter2D(Collision2D aCol)
    {
        if (aCol.collider.tag == "Player")
        {
            Destroy(aCol.gameObject);
        }
    }
}
