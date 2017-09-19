using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    public float FlightForce = 75.0f;
    public Rigidbody2D rb;

    void Start () {
	}

     public float maxVelocity = 10;
	
	void FixedUpdate ()
    {
        rb.velocity = Vector2.ClampMagnitude(rb.velocity, maxVelocity);
        rb.AddForce(new Vector2(Input.GetAxis("Horizontal") * FlightForce, Input.GetAxis("Vertical") * FlightForce));
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
