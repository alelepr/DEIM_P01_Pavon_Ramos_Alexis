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

  


    void Start()
    {
        livesController = GetComponent<LivesController>();
        rb = GetComponent<Rigidbody2D>();
        jumpForce = 6f;
        maxJumps = 2;
        jumpCount = 0; // Inicializamos los saltos a 0
        spellCount = 15;
        UpdateSpellCountText();
        animator.runtimeAnimatorController = playerConfig.animatorController;
    }



    void Update()
    {
        PlayerMovement();
        DispararHechizo();
        UpdateSpellCountText();

        if (livesController.isDead == true)  // Asegúrate de que el LivesController tenga una propiedad IsDead
        {
            animator.SetTrigger("Dead"); // Activamos la animación de muerte
        }

    }



    public void PlayerMovement()
    {
        // Movimiento horizontal
        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * playerConfig.MovementSpeed, rb.velocity.y);
        
        // Salto
        if (Input.GetButtonDown("Jump") && (isGrounded || jumpCount < maxJumps ))
        {
            isJumping = true;
            jumpCount++;
            Debug.Log("inicio de salto");
            jumpTime = 0f;
            AudioManager.PlayJumpSound();
           




        }
        if ((Input.GetButtonUp("Jump")) || (jumpTime >= maxJumpTime)){
            isJumping=false;    
            Debug.Log("fin de salto");
            animator.SetBool("isJumping", false);
          
        }
        if (isJumping)
        {  //Salto según cuánto tiempo pulse el jugador 
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);// rb.velocity.x, // Mantén la velocidad horizontal
            jumpTime += Time.deltaTime;
            animator.SetBool("isWalking", false);
            animator.SetBool("isJumping", true);
        }
              
        
                
        
        // Cambiar la dirección del personaje dependiendo del movimiento horizontal
        if (rb.velocity.x > 0)
        {
            transform.localScale = new Vector2(1f, 1f); // Mira a la derecha
            animator.SetBool("isWalking", true);
            //sr.flipX = true;

        }
        else if (rb.velocity.x < 0)
        {
            transform.localScale = new Vector2(-1f, 1f); // Mira a la izquierda
            animator.SetBool("isWalking", true);
            //sr.flipX = false;


        }
        else
        {
            animator.SetBool("isWalking", false);

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
    }
    public void AddSpells(int amount)
    {
        AudioManager.PlayPotion2Sound();
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
            animator.SetBool("Hurt", true);
            GetComponent<LivesController>().EnemyDamage(1);
            AudioManager.PlayHurtSound();
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
