using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_bubble_spawn : MonoBehaviour
{
    private int random;
    private GameObject bubbleClone;
    private Rigidbody2D rb;

    void Start()
    {
        random = Random.Range(1, 5);

        bubbleClone = Resources.Load("bubble" + random) as GameObject;
        bubbleClone = Instantiate(bubbleClone, new Vector3(7, -4, 0), Quaternion.identity) as GameObject;

        bubbleClone.GetComponent<bubble_shoot>().enabled = true;
        bubbleClone.GetComponent<player_bubble_collision>().enabled = true;

        rb = bubbleClone.GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Dynamic;
        rb.gravityScale = 0;
        
    }
}
