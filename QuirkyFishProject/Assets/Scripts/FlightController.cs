using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlightController : MonoBehaviour {

    public float FlightForce = 75.0f;
    public Rigidbody2D rb;
    bool flightActive;


    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (flightActive)
            rb.AddForce(new Vector2(0, FlightForce));

        if(Input.GetButtonDown("Jump"))
            flightActive = true;
        else if(Input.GetButtonUp("Jump"))
            flightActive = false;
		
	}
}
