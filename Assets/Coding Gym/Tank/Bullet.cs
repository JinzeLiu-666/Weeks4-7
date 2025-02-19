using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float lifetime = 2f; // Bullet lifespan

    void Start()
    {
        Destroy(gameObject, lifetime); // Destroy bullet after some time
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Here you can add logic to detect collisions (e.g., hitting enemies)
        Destroy(gameObject);
    }
}

