using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    public float FlightForce = 75.0f;
    public Rigidbody2D rb;
    public float maxVelocity = 5;

    void Start () {
	}
	
	void FixedUpdate ()
    {
        rb.velocity = Vector2.ClampMagnitude(rb.velocity, maxVelocity); // limits velocity
        rb.AddForce(new Vector2(Input.GetAxis("Horizontal") * FlightForce, Input.GetAxis("Vertical") * FlightForce)); // left and right
                                                                                                                      // and up movement
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
