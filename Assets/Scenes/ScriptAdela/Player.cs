using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    public LifeUi lifeUI;
    public int LifeCounter;

    public int coins;
    public CoinsUi coinsUi;
    public int CoinCounter;

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
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            life--;

            lifeUI.UpdateText(LifeCounter);

            if (life <= 0)
            {
                Destroy(gameObject);
                GetComponent<ChangeScene>();
                SceneManager.LoadScene("GameOver");
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if(collision.gameObject.CompareTag("BulletEnemy"))
        {
            life -= collision.gameObject.GetComponent<Damage>().damage;
            lifeUI.UpdateText(LifeCounter);
            Destroy(collision.gameObject);

            if(life <= 0)
            {
                Destroy(gameObject);

                GetComponent<ChangeScene>();
                SceneManager.LoadScene("GameOver");
            }
        }

        if (collision.gameObject.CompareTag("Coins"))
        {
            coins++;
            Destroy(collision.gameObject);

            CoinCounter++;
            coinsUi.UpdateText(CoinCounter);
            if (coins >= 10)
            {
                GetComponent<ChangeScene>();
                SceneManager.LoadScene("Victory");
            }
        }
    }
    
    private void Start()
    {
        coinsUi=GameObject.Find("Moneda(TMP)").GetComponent<CoinsUi>();
        coinsUi.UpdateText(CoinCounter);

        lifeUI = GameObject.Find("Life (TMP)").GetComponent<LifeUi>();
        lifeUI.UpdateText(LifeCounter);
    }

}
