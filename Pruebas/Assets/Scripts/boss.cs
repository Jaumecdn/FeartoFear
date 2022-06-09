using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss : MonoBehaviour
{
    public float health;

    Rigidbody2D rb;

    [SerializeField] AudioSource marab;


    public SpriteRenderer sprite;

    void Start()
    {
        
    }

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        marab.Play();
    }


    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "PlayerProy")
        {
           
            Damage();
          
        }
    }

    public void Damage()
    {
        health--;
        if (health <= 0)
        {
            StartCoroutine(FlashRed());
            Destroy(gameObject);

        }
    }

    public IEnumerator FlashRed()
    {
        sprite.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        sprite.color = Color.white;
    }


}
