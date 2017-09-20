using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public float maxDurationSec;
    public GameObject shieldPrefab;

    private float timeElapsed = 0;
    private bool shieldOn = true;
    private GameObject shieldObj;

    public bool GetShield()
    {
        return shieldOn;
    }
    
    void setShield (bool on)
    {
        if (shieldOn != on)
        {
            shieldOn = on;
            if (shieldOn)
            {
                Debug.Log("shield ON");
                shieldObj = Instantiate(shieldPrefab, transform);
            }
            else
            {
                Debug.Log("shield OFF");
                Destroy(shieldObj);
            }
        }
    }
	
	void Start ()
    {
        setShield(false);
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
