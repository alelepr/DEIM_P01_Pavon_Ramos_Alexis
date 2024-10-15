using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerControler : MonoBehaviour
{
    //Definición de las variables para el personaje
    [SerializeField] private float speed; //variable de velocidad
    private bool isGrounded; //comprobamos que toca el suelo
   

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private SpriteRenderer sr;
    [SerializeField] private Animator anim;

    [SerializeField] private float jumpTime; //tiempo máximo que el jugador puedre mantener pulsada la tecla de salto
    public float jumpForce; // variable de fuerza de salto
    public int jumpCount; //variable para contar el número de saltos que va dando el jugador
    public int maxJumps; // Permitir 2 saltos (uno en el suelo y uno en el aire)
    private bool isJumping;
    [SerializeField] private float maxJumpTime; //Tiempo que el personaje lleva saltando
    
    private LivesController livesController;



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        speed = 4f;
        jumpForce = 6f;
        maxJumps = 2;
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
        if (Input.GetButtonDown("Jump") && (isGrounded || jumpCount < maxJumps ))
        {
            isJumping = true;
            jumpCount++;
            Debug.Log("inicio de salto");
            jumpTime = 0f;


        }
        if ((Input.GetButtonUp("Jump")) || (jumpTime >= maxJumpTime)){
            isJumping=false;    
            Debug.Log("fin de salto");
        }
        if (isJumping)
        {  //Salto según cuánto tiempo pulse el jugador 
            rb.velocity = Vector2.up * jumpForce;// rb.velocity.x, // Mantén la velocidad horizontal
            jumpTime += Time.deltaTime;
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
            // Resetear el contador de saltos si está tocando el suelo
            jumpCount = 0;
                    
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            GetComponent<LivesController>().EnemyDamage(1);
        }
        if (collision.gameObject.CompareTag("RedPotion"))
        {
            livesController.Heal(1);
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
