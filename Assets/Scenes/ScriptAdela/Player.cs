using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Movimieto")]
    public float speed;
    private Rigidbody2D rb2d;

    [Header("Disparo")]
    public GameObject bullet;
    public float shooterTimer;
    public float shooterDlt;
    private Vector2 direction;

    public float life;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Timer();
        Shooter();
    }

    void Move()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        if(horizontal != 0 || vertical != 0) 
        {
            direction = new Vector2(horizontal, vertical);
        }

        rb2d.velocity = new Vector2(horizontal,vertical) * speed;
    }

    void Timer()
    {
        shooterTimer += Time.deltaTime;
    }

    void Shooter()
    {
        if(Input.GetKeyDown(KeyCode.Space) && shooterTimer >= shooterDlt) 
        {
            GameObject obj = Instantiate(bullet);
            obj.transform.position = transform.position;
            shooterTimer = 0;
            obj.GetComponent<Bullet>().distancia(direction);

        }
    }

    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("BulletEnemy"))
        {
            life -= collision.gameObject.GetComponent<Damage>().damage;
            Destroy(collision.gameObject);

            if(life <= 0)
            {
                Destroy(gameObject);
            }
        }
    }*/
}
