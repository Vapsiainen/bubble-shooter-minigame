using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_bubble_collision : MonoBehaviour
{

    private GameObject bubbleClone;
    private int random;
    private Rigidbody2D rb;


    private void Start()
    {
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        rb = gameObject.GetComponent<Rigidbody2D>();

        if (collision.gameObject.CompareTag("GridBubble"))
        {
            if (gameObject.name.Contains("bubble1") && collision.gameObject.name.Contains("grid_bubble1"))
            {
                Destroy(collision.gameObject);
                Destroy(gameObject);

                SpawnNewPlayer();

            }
            else if (gameObject.name.Contains("bubble2") && collision.gameObject.name.Contains("grid_bubble2"))
            {
                Destroy(collision.gameObject);
                Destroy(gameObject);

                SpawnNewPlayer();
            }
            else if (gameObject.name.Contains("bubble3") && collision.gameObject.name.Contains("grid_bubble3"))
            {
                Destroy(collision.gameObject);
                Destroy(gameObject);

                SpawnNewPlayer();
            }
            else if (gameObject.name.Contains("bubble4") && collision.gameObject.name.Contains("grid_bubble4"))
            {
                Destroy(collision.gameObject);
                Destroy(gameObject);

                SpawnNewPlayer();
            }
            else
            {
                rb.velocity = Vector3.zero;
                rb.bodyType = RigidbodyType2D.Kinematic;

                gameObject.name = "grid_" + name;
                gameObject.tag = "GridBubble";


                SpawnNewPlayer();
            }
        }

    }


    public void SpawnNewPlayer()
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
