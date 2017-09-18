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
                // enables shield
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
        if (Input.GetKey(KeyCode.S)) 
        {
            if (timeElapsed < maxDurationSec)
            {
                setShield(true);
                timeElapsed += Time.deltaTime;
            }
            else
            {
                setShield(false);
            }

        } else 
        {
            setShield(false);
        }
	}
}
