using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShoot : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed = 3;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Shoot();
    }

    void Shoot()
    {
        rb.AddForce(Vector2.up * speed, ForceMode2D.Impulse);
    }
}
