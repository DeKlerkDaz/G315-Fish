using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObstacle : MonoBehaviour
{

    public GameObject Obstacle;
    public Rigidbody2D myRigi;
    //point A
    private Vector2 pos1;
    //point B
    private Vector2 pos2;
    //How Fast
    public float speed = 1.0f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        pos1 = new Vector2(transform.position.x -.5f, transform.position.y);
        pos2 = new Vector2(transform.position.x + .5f, transform.position.y);

        //Moves the object to and from two set points at a certain speed
        transform.position = Vector3.Lerp(pos1, pos2, Mathf.PingPong(Time.time, 1.0f));

        Fall();
    }


    //make a fall function cause gravity is too much for these bois

    void Fall()
    {
        myRigi.velocity = new Vector3(0, -9.8f, 0);
    }

    //Collision with the player will destroy the player object
    private void OnCollisionEnter2D(Collision2D aCol)
    {
        if (aCol.collider.tag == "Player")
        {
            Destroy(aCol.gameObject);
        }
    }
}
