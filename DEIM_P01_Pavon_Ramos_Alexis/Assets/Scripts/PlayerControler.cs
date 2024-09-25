using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    //Definición de las variables para el personaje
    [SerializeField] private float speed; //variable de velocidad
    private bool isGrounded; //comprobamos que toca el suelo
    public float jumpSpeed; // variable de fuerza de salto
    public int jumpCount;
    public int maxJumps = 2; // Permitir 2 saltos (uno en el suelo y uno en el aire)

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private SpriteRenderer sr;
    [SerializeField] private Animator anim;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        speed = 4f;
        jumpSpeed = 6f;
        jumpCount = 0; // Inicializamos los saltos a 0
    }

    void Update()
    {
        PlayerMovement();
    }

    public void PlayerMovement()
    {
        // Movimiento horizontal
        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, rb.velocity.y);
        
        // Salto
        if (Input.GetButtonDown("Jump") && (isGrounded || jumpCount < maxJumps - 1))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed); // Mantén la velocidad horizontal
            jumpCount++;
        }

        // Resetear el contador de saltos si está tocando el suelo
        if (isGrounded)
        {
            jumpCount = 0;
        }

        // Cambiar la dirección del personaje dependiendo del movimiento horizontal
        if (rb.velocity.x > 0)
        {
            transform.localScale = new Vector2(1f, 1f); // Mira a la derecha
        }
        else if (rb.velocity.x < 0)
        {
            transform.localScale = new Vector2(-1f, 1f); // Mira a la izquierda
        }
    }

    // Detectar si toca el suelo con colisiones
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
