using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_2 : MonoBehaviour
{
    private float speed;
    private Rigidbody rb;
    public Vector2 dir;

    public float timer;
    public float maxTimer;

    public float timerBullet; 
    public float maxTimerBullet;
    public GameObject bulletEnemy;

    void Awaka()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        mov();
        ChangeDirection();
        shooterEnemy();
    }

    void mov()
    {
        rb.velocity = dir * speed;
    }

    void ChangeDirection()
    {
        timer += Time.deltaTime;
        if(timer >= maxTimerBullet) 
        {
            dir *= -1;
            timer = 0;
        }
    }

    void shooterEnemy()
    {
        timerBullet += Time.deltaTime;
        if(timerBullet >= maxTimerBullet) 
        { 
            GameObject obj = Instantiate(bulletEnemy);
            obj.transform.position = transform.position;

            timerBullet = 0;

            for(int i = 0; i < 2; i++) { }
        }
    }
}
