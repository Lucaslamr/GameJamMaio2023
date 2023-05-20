using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collider : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the collision involves the tilemap
        if (collision.gameObject.CompareTag("Player"))
        {
            // Handle collision with tilemap here
            Debug.Log("Player collided with tilemap.");
        }
    }
}

