using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_2 : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb2D;
    public Vector2 dir;

    public float timer;
    public float maxTimer;

    public float timerBullet; 
    public float maxTimerBullet;
    public GameObject bulletEnemy;

    void Awaka()
    {
        rb2D = GetComponent<Rigidbody2D>();
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
        rb2D.velocity = dir * speed;
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
