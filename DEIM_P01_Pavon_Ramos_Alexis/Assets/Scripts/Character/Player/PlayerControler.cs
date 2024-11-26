using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using TMPro;
using System;
using JetBrains.Annotations;



public class PlayerControler : MonoBehaviour
{
    [Tooltip("Referencia a los datos de configuración del personaje")]
    [SerializeField] private PlayerConfig playerConfig;


    //Definición de las variables para el personaje (movimiento)
    private bool isGrounded; //comprobamos que toca el suelo

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private SpriteRenderer sr;
    public bool canMove;
    GameManager gameManager;

    [SerializeField] public Animator animator;


    //Salto
    [SerializeField] private float jumpTime; //tiempo máximo que el jugador puedre mantener pulsada la tecla de salto
    public float jumpForce; // variable de fuerza de salto
    public int jumpCount; //variable para contar el número de saltos que va dando el jugador
    public int maxJumps; // Permitir 2 saltos (uno en el suelo y uno en el aire)
    private bool isJumping;
    [SerializeField] private float maxJumpTime; //Tiempo que el personaje lleva saltando
    
    //Vidas
    private LivesController livesController;

    //Hechizo
    public GameObject hechizoPrefab; // Prefab del hechizo
    public float velocidadHechizo = 5f; // Velocidad a la que se mueve el hechizo
    public Transform puntoDisparo; // El punto desde donde se dispara el hechizo (por ejemplo, debajo del jugador)
    public int spellCount;
    [SerializeField] public TextMeshProUGUI hechizosText;

    public bool isPaused;

    private float lastDamageTime = 0f;
    private float damageCooldown = 0.5f; // 0.5 segundos de espera


    void Start()
    {
        livesController = GetComponent<LivesController>();
        rb = GetComponent<Rigidbody2D>();
        jumpForce = 5f;
        maxJumps = 2;
        jumpCount = 0; // Inicializamos los saltos a 0
        spellCount = 15;
        UpdateSpellCountText();
        animator.runtimeAnimatorController = playerConfig.animatorController;
        gameManager = GetComponent<GameManager>();
    }



    void Update()
    {
        PlayerMovement();
        DispararHechizo();
        UpdateSpellCountText();

        if (livesController.isDead == true)  // Asegúrate de que el LivesController tenga una propiedad IsDead
        {
            animator.SetTrigger("Dead"); // Activamos la animación de muerte
            canMove = false;
        }
        else
        {
            canMove = true;
        }

    }



    public void PlayerMovement()
    {
        if (canMove)
        {
            // Movimiento horizontal: Actualizamos la velocidad en X, pero mantenemos la velocidad en Y (gravedad)
            rb.velocity = new Vector2(Input.GetAxis("Horizontal") * playerConfig.MovementSpeed, rb.velocity.y);

            // Salto
            if (Input.GetButtonDown("Jump") && (isGrounded || jumpCount < maxJumps))
            {
                isJumping = true;
                jumpCount++;
                Debug.Log("inicio de salto");
                jumpTime = 0f;
                AudioManager.PlayJumpSound();
            }

            if ((Input.GetButtonUp("Jump")) || (jumpTime >= maxJumpTime))
            {
                isJumping = false;
                Debug.Log("fin de salto");
                animator.SetBool("isJumping", false);
            }

            if (isJumping)
            {
                // Salto según cuánto tiempo pulse el jugador 
                rb.velocity = new Vector2(rb.velocity.x, jumpForce); // Mantén la velocidad horizontal
                jumpTime += Time.deltaTime;
                animator.SetBool("isWalking", false); // No camines mientras saltas
                animator.SetBool("isJumping", true); // Reproduce la animación de salto
            }

            // **Giro del sprite**
            // Actualiza la dirección del personaje dependiendo de la velocidad en X.
            // Esto ocurre independientemente de si está en el aire o tocando el suelo.
            if (rb.velocity.x > 0)  // Si el personaje se mueve a la derecha
            {
                transform.localScale = new Vector2(1f, 1f); // Mira a la derecha
            }
            else if (rb.velocity.x < 0)  // Si el personaje se mueve a la izquierda
            {
                transform.localScale = new Vector2(-1f, 1f); // Mira a la izquierda
            }

            // Animación de caminar solo cuando está tocando el suelo
            if (isGrounded)
            {
                if (rb.velocity.x != 0)
                {
                    animator.SetBool("isWalking", true); // Reproduce la animación de caminar
                    animator.SetBool("isJumping", false); // Reproduce la animación de caminar


                }
                else
                {
                    animator.SetBool("isWalking", false); // Detiene la animación de caminar
                }
            }
            else
            {
                animator.SetBool("isWalking", false); // No camina en el aire
            }
        }
        else
        {
            rb.velocity = Vector2.zero; // Detener el movimiento cuando no puede moverse
        }
    }



    private void UpdateSpellCountText()
    {
        
        hechizosText.text = spellCount.ToString();
        

    }
    AudioManager audioManager;
    public void PlayFootStep()
    {
        if (rb.velocity.x!=0 && isGrounded)
        {
            //Llamamos a la clase, y usando la variable instancia que es estatica reproducimos el sonido
            AudioManager.PlayFootStepSound();  
        }
    }
    public void DispararHechizo()
    {
        if(Time.timeScale > 0f) { 
            if (spellCount > 0)
            {
                if (Input.GetMouseButtonDown(0)) // 0 es el botón izquierdo del ratón
                {
                    // Instanciar el hechizo en la posición del punto de disparo
                    GameObject hechizo = Instantiate(hechizoPrefab, puntoDisparo.position, Quaternion.identity);
                    AudioManager.PlaySpellSound();
                    animator.SetBool("isAttacking", true);





                    // Hacer que el hechizo se mueva hacia abajo
                    Rigidbody2D rb = hechizo.GetComponent<Rigidbody2D>();
                    if (rb != null)
                    {
                        rb.velocity = Vector2.down * velocidadHechizo;
                    }
                    spellCount--;


                }
            }
            else
            {
                animator.SetBool("isAttacking", false);

            }
        }
    }
    public void AddSpells(int amount)
    {
        AudioManager.PlayPotionSound();
        spellCount += amount;
        


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
            // Verifica si han pasado 0.5 segundos desde el último daño
            if (Time.time - lastDamageTime >= damageCooldown)
            {
                // Cambia la animación de "Hurt"
                animator.SetBool("Hurt", true);

                // Llama a EnemyDamage
                GetComponent<LivesController>().EnemyDamage(1);

                // Reproduce el sonido de daño
                AudioManager.PlayHurtSound();

                // Actualiza el tiempo del último daño
                lastDamageTime = Time.time;
            }
        }

        


    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("BluePotion"))
        {
            // Suma 5 hechizos
            AddSpells(5);
            // Destruye el objeto o desactívalo (opcional)
            Destroy(collision.gameObject);

        }

       


    }

    public void DetenerHurt()
    {
        animator.SetBool("Hurt", false);

    }

    public void DetenerAttack()
    {
        animator.SetBool("isAttacking", false);

    }

}
