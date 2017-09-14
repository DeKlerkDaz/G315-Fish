using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    public float FlightForce = 75.0f;
    public Rigidbody2D rb;

    void Start () {
		
	}
	
	
	void FixedUpdate ()
    {
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(new Vector2(-FlightForce, 0));
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(new Vector2(FlightForce, 0));
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            /*
            Vector3 position = this.transform.position;
            position.x--;
            this.transform.position = position;
            */
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            /*
            Vector3 position = this.transform.position;
            position.x++;
            this.transform.position = position;
            */
        }

    }
}
