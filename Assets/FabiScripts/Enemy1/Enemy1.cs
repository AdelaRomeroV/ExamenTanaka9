using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    public int life;
    public float speed;
    private float originalSpeed;
    public Vector2 direction;
    public Rigidbody2D rb2d;
    public float timer;
    public float Maxtimer;

    public float MaxStopTimer;

    private void Awake()
    {
        originalSpeed = speed;   //valor velocidad original

        rb2d= GetComponent<Rigidbody2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            life--;
            if(life < 0)
            {
                Destroy(gameObject);
            }
        }
        if (collision.gameObject.CompareTag("Bullet"))
        {
            life--;
            if (life < 0)
            {
                Destroy(gameObject);
            }
        }
    }
    void Update()
    {
        Move();
        ChangeDirection();
    }
    void Move()
    {
        rb2d.velocity = direction*speed;
    }
    void ChangeDirection()
    {
        timer+= Time.deltaTime;
        if(timer >= Maxtimer) 
        {
            speed = 0;   //La velocidad se vuelve 0
            if (timer >= MaxStopTimer)
            {
                direction *= -1;
                timer = 0;
                speed = originalSpeed;   //regresar a la velocidad original
            }

        }
    }
    
}
