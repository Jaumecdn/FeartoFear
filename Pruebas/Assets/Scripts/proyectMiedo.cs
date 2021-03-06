using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class proyectMiedo : MonoBehaviour
{
    Rigidbody2D rb;

    public float xSpeed;
    public float ySpeed;

    public bool canShoot;
    public float fireRate;
    public float health;
    public SpriteRenderer sprite;



    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        

    }

    void Update()
    {
        rb.velocity = new Vector2(xSpeed, ySpeed*-1);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            col.gameObject.GetComponent<FlipChar>().Damage();
            StartCoroutine(FlashRed());
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
    
    public void Damage()
    {
        health--;
        //Para que muera el proyectil(vida)
       
        if (health == 0)
        {
            Destroy(gameObject);
        }
    }

    public IEnumerator FlashRed()
    {
        sprite.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        sprite.color = Color.white;
    }



}
