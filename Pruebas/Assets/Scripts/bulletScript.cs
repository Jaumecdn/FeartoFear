using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour
{
    Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Enemy")
        {
            col.gameObject.GetComponent<proyectMiedo>().Damage();
            Destroy(gameObject);
        }

        if(col.gameObject.tag == "boss")
        {
            col.gameObject.GetComponent<boss>().Damage();
            Destroy(gameObject);
        }
    }
}
