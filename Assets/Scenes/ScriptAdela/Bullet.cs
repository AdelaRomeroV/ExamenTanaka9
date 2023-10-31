using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("Bala")]
    public float speed;
    private Rigidbody2D rb;

    public float life;

    private Vector2 direccion;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 2f);
    }

        // Update is called once per frame
        void Update()
    {
        rb.velocity = (direccion * speed);
    }

    public void distancia(Vector2 vale)
    {
        direccion = vale;
    }
}
