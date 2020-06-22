using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_bubble_collision : MonoBehaviour
{
   
    Rigidbody2D rb;
    public float speed;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bubble"))
        {
            Destroy(collision.gameObject);
        }
        
    }
}
