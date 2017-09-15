using UnityEngine;
using System;
using System.Collections.Generic;
using Random = UnityEngine.Random;


public class BoardManager : MonoBehaviour
{
    [Serializable]
    public class Count
    {
        public int minimum;
        public int maximum;

        public Count (int min, int max)
        {
            minimum = min;
            maximum = max;
        }
    }
    public int columns = 4;                                         
    public int rows = 50;
    public float gridWidth = 3.5f;
    public float gridHeight = 5f;
    public Count staticCount = new Count(150, 200);
    public Count movingCount = new Count(15, 20);   //not really needed RN
    public Count powerUpCount = new Count(1, 5);    //not really needed RN
    public GameObject[] staticObjects;                              
    public GameObject[] movingObjects;              //not really needed RN                    
    public GameObject[] powerUps;                   //not really needed RN               

    private Transform boardHolder;                                   //A variable to store a reference to the transform of our Board object.
    private List<Vector3> gridPositions = new List<Vector3>();       //A list of possible locations to place tiles.


    // Clears our list gridPositions and prepares it to generate a new board.
    void InitialiseList()
    {
        Debug.Log("initiating list");
        gridPositions.Clear();
        for (float x = -7f; x < columns * (gridWidth - 1); x += gridWidth)
            for (float y = 7.5f; y < rows * (gridHeight - 1); y += gridHeight)
                gridPositions.Add(new Vector3(x, y, 0));
    }

    //RandomPosition returns a random position from our list gridPositions.
    Vector3 RandomPosition()
    {
        int randomIndex = Random.Range(0, gridPositions.Count);
        Vector3 randomPosition = gridPositions[randomIndex];
        gridPositions.RemoveAt(randomIndex);
        
        return randomPosition;
    }


    //LayoutObjectAtRandom accepts an array of game objects to choose from along with a minimum and maximum range for the number of objects to create.
    void LayoutObjectAtRandom(GameObject[] tileArray, int minimum, int maximum)
    {
        int objectCount = Random.Range(minimum, maximum + 1);
        
        for (int i = 0; i < objectCount; i++)
        {
            Debug.Log("initiating Item");
            Vector3 randomPosition = RandomPosition();
            GameObject tileChoice = tileArray[Random.Range(0, tileArray.Length)];
            Instantiate(tileChoice, randomPosition, Quaternion.identity,boardHolder);
        }
    }


    //SetupScene initializes our level and calls the previous functions to lay out the game board
    public void SetupScene(int level)
    {
        boardHolder = transform;
        InitialiseList();

        LayoutObjectAtRandom(staticObjects, staticCount.minimum, staticCount.maximum);
        //LayoutObjectAtRandom(movingObjects, movingCount.minimum, movingCount.maximum);    //to be added once we have moving objects
        //LayoutObjectAtRandom(powerUps, powerUpCount.minimum, powerUpCount.maximum);       //to be added once we have powerups
    }
}
