using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hechizo : MonoBehaviour
{
    public float velocidad = 6f; // Velocidad de desplazamiento del hechizo hacia abajo

    private Rigidbody2D rb;

    private void Start()
    {

        /* Collider2D jugadorCollider = GameObject.FindWithTag("Player").GetComponent<Collider2D>();
        Collider2D hechizoCollider = GetComponent<Collider2D>();
    
        // Ignorar las colisiones entre el hechizo y el jugador
        Physics2D.IgnoreCollision(jugadorCollider, hechizoCollider);
        
        // Asignar velocidad hacia abajo al hechizo
        GetComponent<Rigidbody2D>().velocity = Vector2.down * velocidad;*/
        // Obtener el componente Rigidbody2D del hechizo
        rb = GetComponent<Rigidbody2D>();

        // Asignar la velocidad hacia abajo
        rb.velocity = Vector2.down * velocidad;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        // Si el hechizo toca un enemigo (con tag "Enemy")
        if (collider.CompareTag("Enemy"))
        {
            // Intentamos obtener el componente del script del enemigo para llamar a PerderVida()
            EnemyController enemigo = collider.GetComponent<EnemyController>();
            enemigo.PerderVida(); // Llamar al método PerderVida del enemigo
            
            // Destruir el hechizo después de impactar al enemigo
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Si el hechizo toca el suelo (con tag "Ground")
        if (collision.gameObject.CompareTag("Ground"))
        {
            // Destruir el hechizo al tocar el suelo
            Destroy(gameObject);
        }
    }
}