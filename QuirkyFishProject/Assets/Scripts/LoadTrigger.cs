using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadTrigger : MonoBehaviour
{
    BoardManager boardScript;
    public Rigidbody2D myRigi;

    void Update()
    {
        Fall();
    }

    void Fall()
    {
        myRigi.velocity = new Vector3(0, -4f, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        boardScript = GetComponentInParent<BoardManager>();
        if (collision.CompareTag("Player"))
        {
            Debug.Log("TRIGGERED");
            boardScript.SetupScene(1);
        }
    }
}
