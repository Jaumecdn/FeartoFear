using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Movimiento : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 3.0f;

    private Vector2 movement;




    void Start()
    {

    }

    void Update()
    {
        movement = new Vector2(Input.GetAxis("Horizontal"), 0).normalized;

    }
 
    
    private void FixedUpdate()
    {
        if (movement != Vector2.zero)
        {
            var xMovement = movement.x * movementSpeed * Time.deltaTime;
            this.transform.Translate(new Vector3(xMovement, 0), Space.World);
        }
    }

 
}