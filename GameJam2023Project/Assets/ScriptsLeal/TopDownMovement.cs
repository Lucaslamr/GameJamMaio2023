using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed of movement

    private Rigidbody2D rb;

    public static bool canMove = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Get the Rigidbody2D component
    }

    void Update()
    {
        if(!canMove){
            return;
        }

        // Get input from horizontal and vertical axes
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        // Calculate movement vector
        Vector2 movement = new Vector2(moveX, moveY);

        // Normalize the movement vector to maintain consistent speed in all directions
        movement.Normalize();

        // Move the rigidbody
        rb.velocity = movement * moveSpeed;
    }
}
