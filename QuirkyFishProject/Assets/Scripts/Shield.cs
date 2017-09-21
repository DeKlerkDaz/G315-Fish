using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public float maxDurationSec;
    public float warningDurationSec;
    public GameObject shieldPrefab;

    private float timeElapsed = 0;
    private bool shieldOn = true;
    private GameObject shieldObj;
    private SpriteRenderer shieldRenderer;

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
                gameObject.layer = LayerMask.NameToLayer("Shielded");
                shieldObj = Instantiate(shieldPrefab, transform);
                shieldRenderer = shieldObj.GetComponentInChildren<SpriteRenderer>(); // find the Bubble's renderer
            }
            else
            {
                gameObject.layer = LayerMask.NameToLayer("Default");
                shieldRenderer = null;
                Destroy(shieldObj);
                shieldObj = null;
            }
        }
    }

    IEnumerator ShieldFlashCoroutine()
    {
        while (true) // forever!
        {
            if (shieldOn) // only check if we should flash shield if shield is on!
            {
                if (timeElapsed > maxDurationSec - warningDurationSec) // flash shield if it's almost out of time
                {
                    float duration = 0.05f; // 20 times a second
                    while (duration > 0)
                    {
                        duration -= Time.deltaTime;
                        yield return null;
                    }
                    if (shieldRenderer != null)
                    {
                        shieldRenderer.enabled = !shieldRenderer.enabled; // reverse the renderer's enabled flag
                    }
                }
                yield return null;
            }
            yield return null;
        }
    }

    void Start ()
    {
        setShield(false);
        StartCoroutine("ShieldFlashCoroutine");
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
