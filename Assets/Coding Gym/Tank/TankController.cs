using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Transform barrel; // Barrel
    public GameObject bulletPrefab; // Bullet prefab
    public Transform firePoint; // Firing point
    public float bulletSpeed = 10f;

    void Update()
    {
        // Handle tank movement
        float move = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * move * moveSpeed * Time.deltaTime);

        // Rotate barrel towards the mouse
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;
        Vector3 direction = mousePosition - barrel.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        barrel.rotation = Quaternion.Euler(0, 0, angle);

        // Handle shooting
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.velocity = firePoint.right * bulletSpeed;
    }
}

