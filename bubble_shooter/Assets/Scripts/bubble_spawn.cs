using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bubble_spawn : MonoBehaviour
{
    public int rows = 15;
    public int columns = 15;
    public float gridGap = 1f;
    public Vector2 gridOrigin = Vector2.zero;
    public GameObject[] bubbleColours;

    void Start()
    {
        spawnGrid();
    }

  
    void spawnGrid()
    {
        
        for (int row = 0; row < rows; row = row + 2)
        {
            for (int column = 0; column < columns; column = column + 2)
            {
                Vector2 spawnPoint = new Vector2(row * gridGap, column * -gridGap) + gridOrigin;
                int randomColour = Random.Range(0, bubbleColours.Length);
                Instantiate(bubbleColours[randomColour], spawnPoint, Quaternion.identity);
            }
        }

    }
    
}

