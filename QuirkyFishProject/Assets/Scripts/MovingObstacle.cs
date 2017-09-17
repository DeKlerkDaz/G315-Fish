using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObstacle : MonoBehaviour
{

    public GameObject Obstacle;
    public Rigidbody2D myRigi;
    //point A
    private Vector3 pos1 = new Vector3(-4, 0, 0);
    //point B
    private Vector3 pos2 = new Vector3(4, 0, 0);
    //How Fast
    public float speed = 1.0f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Moves the object to and from two set points at a certain speed
        transform.position = Vector3.Lerp(pos1, pos2, Mathf.PingPong(Time.time * speed, 1.0f));
    }


    //make a fall function cause gravity is too much for these bois

    //Collision with the player will destroy the player object
    private void OnCollisionEnter2D(Collision2D aCol)
    {
        if (aCol.collider.tag == "Player")
        {
            Destroy(aCol.gameObject);
        }
    }
}
