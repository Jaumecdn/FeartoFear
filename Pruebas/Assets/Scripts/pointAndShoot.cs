using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pointAndShoot : MonoBehaviour
{
    private Vector3 target;
    public GameObject diana;
    public GameObject bola;

    public GameObject bulletPrefab;

    public float bulletSpeed = 60.0f;

    [SerializeField] AudioSource fire;


    void Start(){    Cursor.visible = false;}

    void Update()
    {
        target = transform.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z));
        diana.transform.position = new Vector2(target.x, target.y);

        //Por si quiero que la bola rote en direccion de donde estoy apuntando el cursor
        Vector3 difference = target - bola.transform.position;
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        bola.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);

        if (Input.GetMouseButtonDown(0))
        {
            //fire bullet
            fire.Play();
            float distance = difference.magnitude;
            Vector2 direction = difference / distance;
            direction.Normalize();
            fireBullet(direction, rotationZ);
        }
    }

    void fireBullet(Vector2 direction, float rotationZ)
    {
      
        GameObject b = Instantiate(bulletPrefab) as GameObject;
        b.transform.position = bola.transform.position;
        b.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
        b.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
    }
}
