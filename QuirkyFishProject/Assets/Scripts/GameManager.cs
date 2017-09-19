using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public Transform startMenu;
    public Transform endMenu;
    public Transform timerScore;
    public Transform player;
    public Text endScore;
    public float startTime;

    public static GameManager instance = null;
    BoardManager boardScript;
    private int difficulty = 1;   // As time passes, the level gets harder to navigate (to bo implemented another time :3)                              

    //Prevents the game from starting until the start button is pressed
    private void Start()
    {
        Time.timeScale = 0;
        timerScore.gameObject.SetActive(false);
    }

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        boardScript = GetComponent<BoardManager>();

        boardScript.SetupScene(difficulty/*this part doesnt matter yet :P*/);
    }

    // Function to a set of prefabs when the old one is almost done.

    //Update is called every frame.
    void Update()
    {
        if (player == null)
        {
            Time.timeScale = 0;
            endMenu.gameObject.SetActive(true);
            //time since the application starts up
            float t = Time.time - startTime;
            //converting the float of Time.time into an int that we can
            //output to the text UI in meters
            string meters = (t).ToString("f0");

            //outputting the seconds as meters
            endScore.text = "Score: " + meters + "m";
        }
    }

    // Once the start button is pressed then the game starts and closes the start menu
    public void gameStart()
    { 
        Time.timeScale = 1;
        startMenu.gameObject.SetActive(false);
        timerScore.gameObject.SetActive(true);
        startTime = Time.time;
    }

    public void gameEnd()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}