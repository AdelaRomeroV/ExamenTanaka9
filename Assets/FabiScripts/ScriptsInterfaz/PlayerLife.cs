using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{

    public float life;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            life -= collision.gameObject.GetComponent<Damage>().damage;
            Destroy(collision.gameObject);

            if (life <= 0)
            {
                Destroy(gameObject);

            }
        }
        if (collision.gameObject.CompareTag("EnemyBullet"))
        {
            life -= collision.gameObject.GetComponent<Damage>().damage;
            Destroy(collision.gameObject);

            if (life <= 0)
            {
                Destroy(gameObject);

            }
        }
    }

        // Start is called before the first frame update
        void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
