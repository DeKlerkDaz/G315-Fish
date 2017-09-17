using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class TimerScore : MonoBehaviour
{
    public Text timerText;
    private float startTime;

	// Use this for initialization
	void Start ()
    {
        //time starts up once the application starts up
        startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update ()
    {
        //time since the application starts up
        float t = Time.time - startTime;
        //converting the float of Time.time into an int that we can
        //output to the text UI in meters
        string meters = (t).ToString("f0");
        
        //outputting the seconds as meters
        timerText.text = meters + "m";
	}
}
