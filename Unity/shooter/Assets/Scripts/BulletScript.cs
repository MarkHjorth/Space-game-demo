using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour 
{

    // Public variable 
    public int speed = 1600;
    private Rigidbody2D rb;

    // Gets called once when the bullet is created
    void Start () 
    {  
        // Set the Y velocity to make the bullet move upward
        rb = GetComponent<Rigidbody2D>();
        Vector2 dir = transform.right;     
        rb.AddForce(dir * speed);
    }

    // Gets called when the object goes out of the screen
    void OnBecameInvisible() 
    {  
        // Destroy the bullet 
        Destroy(gameObject);
    }
}