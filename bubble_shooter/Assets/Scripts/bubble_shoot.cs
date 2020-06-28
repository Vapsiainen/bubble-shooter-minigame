using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bubble_shoot : MonoBehaviour
{ 
    private Vector3 targetPosition;
    private Vector3 targetDirection;
    private bool canShoot;
    private Rigidbody2D rb;
    private float bubbleSpeed = 30f;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        rb.velocity = rb.velocity.normalized * bubbleSpeed;

        if (Input.GetMouseButtonDown(0))
        {
            TargetPosition();
        }

        if (canShoot)
        {
            Shoot();
        }

    }

    void TargetPosition()
    {
        targetPosition = Input.mousePosition;
        targetPosition.z = 0f;
        targetPosition = Camera.main.ScreenToWorldPoint(targetPosition);

        targetDirection = targetPosition - gameObject.transform.position;
        targetDirection.z = 0f;
        targetDirection = targetDirection.normalized;

        canShoot = true;
    }

    void Shoot()
    {
        rb.AddForce(targetDirection * bubbleSpeed);

        canShoot = false;
        
    }

}