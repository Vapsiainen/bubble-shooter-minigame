using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bubble_spawn : MonoBehaviour
{

    int xSize = 7;
    int ySize = 5;
    public GameObject[] bubbleColours;
    private Vector3 spawnPoint;
    public Vector3 gridOrigin = Vector3.zero;
    public GameObject[,] bubbles;
    public bool isMatched = false;
    public float gridGap = 2.5f;

    public GameObject leftBubble;
    public GameObject rightBubble;
    public GameObject upBubble;
    public GameObject downBubble;
    public GameObject middleBubble;


    private void Start()
    {
        bubbles = new GameObject[xSize, ySize];

        spawnGrid();
    }

    private void Update()
    {
        if (isMatched)
        {
        }
    }


    public void spawnGrid()
    {

        for (int x = 0; x < xSize; x++)
        {
            for (int y = 0; y < ySize; y++)
            {
                Vector3 spawnPoint = new Vector3(x * gridGap, y * -gridGap) + gridOrigin;
                int randomColour = Random.Range(0, bubbleColours.Length);
                GameObject gridBubbleClone = Instantiate(bubbleColours[randomColour], spawnPoint, Quaternion.identity) as GameObject;
                gridBubbleClone = bubbles[x, y];

                
                /*BubbleController bubblecontroller = gridBubbleClone.GetComponent<BubbleController>();
                bubblecontroller.Init(gridGap);

                m_bubbleControllers.Add(bubblecontroller);*/
            }
        }

        /*for (int i = 0; i < m_bubbleControllers.Count; i++)
        {
            m_bubbleControllers[i].UpdateNeighbours();
        }*/

    }

    public void CheckForNeighbors()
    {
        for (int x = 0; x < xSize; x++)
        {
            for (int y = 0; y < ySize; y++)
            {
                if (x > 0 && x < xSize - 1)
                {
                    GameObject leftBubble = bubbles[x - 1, y];
                    GameObject rightBubble = bubbles[x + 1, y];
                    GameObject middleBubble = bubbles[x, y];

                    if (leftBubble.tag == this.gameObject.tag && rightBubble.tag == this.gameObject.tag)
                    {
                        leftBubble.GetComponent<bubble_spawn>().isMatched = true;
                        rightBubble.GetComponent<bubble_spawn>().isMatched = true;
                        isMatched = true;
                    }
                }

                if (y > 0 && y < ySize - 1)
                {
                    GameObject upBubble = bubbles[x, y + 1];
                    GameObject downBubble = bubbles[x, y - 1];
                    GameObject middleBubble = bubbles[x, y];

                    if (upBubble.tag == this.gameObject.tag && downBubble.tag == this.gameObject.tag)
                    {
                        upBubble.GetComponent<bubble_spawn>().isMatched = true;
                        downBubble.GetComponent<bubble_spawn>().isMatched = true;
                        isMatched = true;
                    }
                }
            }
        }
    }
}