using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bubble_shoot : MonoBehaviour
{
    public float bubbleSpeed = 30f;
    public GameObject playerBubble;
    public Transform playerBubbleSpawnPoint;
    public Rigidbody2D rb;
    private Vector3 targetPosition;
    private bool isShooting;
   

    private void Start()
    {
        //jos tag on redbubble niin rb.isKinematic = false;
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            TargetPosition();   
        }

        if (isShooting)
        {
            Shoot();
        }
    }

    void TargetPosition()
    {
        targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        targetPosition.z = transform.position.z;
        isShooting = true;
    }

    void Shoot()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, bubbleSpeed * Time.deltaTime);
        if(transform.position == targetPosition)
        {
            isShooting = false;
        }
    }

}