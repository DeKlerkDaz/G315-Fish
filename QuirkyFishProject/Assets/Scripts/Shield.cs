using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public float maxDurationSec;

    private float timeElapsed = 0;
    private bool shieldOn = false;
    
    void setShield (bool on)
    {
        if (shieldOn != on)
        {
            shieldOn = on;
            if (shieldOn)
            {
                Debug.Log("shield ON");
                // enable shield
            }
            else
            {
                Debug.Log("shield OFF");
                // disable shield
            }
        }
    }
	
	void Start ()
    {
	}
		
	void Update ()
    {
        if (Input.GetKey(KeyCode.Space)) 
        {
            if (timeElapsed < maxDurationSec) 
            {                                  // if elapsed time is less than the max allowed time
                setShield(true);               // enable the shield
                timeElapsed += Time.deltaTime; // starts counting time
            }
            else
            {
                setShield(false);
            }

        } else 
        {
            setShield(false);                // if button is not pressed, the shield will always be disabled
        }
	}
}
