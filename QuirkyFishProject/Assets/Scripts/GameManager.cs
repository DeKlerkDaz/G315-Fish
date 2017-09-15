using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{

    public static GameManager instance = null;
    private BoardManager boardScript;
    private int difficulty = 3;   // As time passes, the level gets harder to navigate (to bo implemented another time :3)                              

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
        boardScript = GetComponent<BoardManager>();

        boardScript.SetupScene(difficulty/*this part doesnt matter yet :P*/);
    }

    // Function to a set of prefabs when the old one is almost done.

    //Update is called every frame.
    void Update()
    {

    }
}