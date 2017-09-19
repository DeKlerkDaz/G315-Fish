using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndUI : MonoBehaviour
{

    public Transform canvas;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TryAgain();
        }
    }

    public void TryAgain()
    {
        //if the menu isn't active bring the menu up
        if (canvas.gameObject.activeInHierarchy == false)
        {
            canvas.gameObject.SetActive(true);
            Time.timeScale = 0; //stops everything moving in the game
        }
        else
        {
            canvas.gameObject.SetActive(false);
        }
    }
}

