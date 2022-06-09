using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FlipChar : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 3.0f;

    Rigidbody2D rb;

    private Vector2 movement;
    private Animator animator;

    public GameObject bola;

    int health = 3;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
      movement = new Vector2(Input.GetAxis("Horizontal"), 0).normalized;
        animator.SetFloat("Speed", Mathf.Abs(movement.magnitude * movementSpeed));
        
        bool flipped = movement.x < 0;
        this.transform.rotation = Quaternion.Euler(new Vector3(0f, flipped ? 180f : 0f));


        if (Input.GetKeyDown(KeyCode.W))
        {
            animator.SetTrigger("jump");
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            animator.SetTrigger("Hide");

        }
    }




    public void Damage()
    {
        health--;
        if (health == 0)
        {
            Destroy(bola);
            Destroy(gameObject);
            SceneManager.LoadScene("Menu");

        }
    }

}
