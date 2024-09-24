using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    //Definition of the variables for the character
    [SerializeField] private float speed;
    public bool isGrounded;
    float velocidadX;
    float velocidadY;
    public int jumpsLeft;
    public int maxJumps;
    public int jumpSpeed;


    [SerializeField]Rigidbody2D rb;
    [SerializeField] SpriteRenderer sr;
    [SerializeField] Animator animator;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        speed = 8f;
        jumpsLeft =  maxJumps;
        jumpSpeed = 10;
}

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate() {
        PlayerMovement();
    }

    public void PlayerMovement()
    {
        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, Input.GetAxis("Vertical") * speed); //Tomando como referencia el rigid body creamos un vector en el que al pulsar las teclas de las flechas en el eje horizontal se mover�

        velocidadX = Input.GetAxis("Horizontal"); //igualamos la variable al valor del eje horizontal
        velocidadY = Input.GetAxis("Vertical");    //igualamos la variable al valor del eje vertical
        
        if (isGrounded==true)
        {
            jumpsLeft = maxJumps;
        }

        if (Input.GetKey(KeyCode.Space) && jumpsLeft > 0)
        {
            jumpsLeft--;
            rb.velocity = new Vector2(rb.velocity.x, 0f);
            rb.AddForce(Vector2.up * jumpSpeed, ForceMode2D.Impulse);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground"){
            isGrounded = true;
        }else {
            isGrounded = false;
        }
    }
}
