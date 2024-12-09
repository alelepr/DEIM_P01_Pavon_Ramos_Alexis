using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using Gestor = GestionEscenas.SceneManager;

public class LivesController : MonoBehaviour
{
    // Start is called before the first frame update
    public int vidaActual;
    public int vidaMaxima;
    public UnityEvent<int> cambioVida;
    AudioManager audioManager;

    public bool isDead;

    Animator animator;

    private PlayerControler playerController; // Referencia al PlayerController


    void Start()
    {
        vidaActual = vidaMaxima;
        cambioVida.Invoke(vidaActual);
        playerController = GetComponent<PlayerControler>(); // Obtener la referencia al PlayerController
        if (vidaActual <= 0)
        {
            isDead = true;
            playerController.canMove = false; // Desactivar el movimiento si ya está muerto
        }
        else
        {
            isDead = false;
            playerController.canMove = true; // Asegurar que el movimiento esté habilitado si está vivo
        }

        string escenaActual = Gestor.GetActiveScene().name;

        // Para el tutorial el jugador empieza con uan vida menos
        switch (escenaActual)
        {
            case "Tutorial":
                EnemyDamage(1);
                break;

            
        }
    }


    public void EnemyDamage(int damageAmount)
    {
        int vidaTemporal = vidaActual - damageAmount;

        if (vidaTemporal < 0)
        {
            vidaActual  = 0;
        }
        else
        {
            vidaActual = vidaTemporal;
        }

        cambioVida.Invoke(vidaActual);

        if (vidaActual <= 0) {

            Morir();
            isDead = true;
        }
    }



    public void Heal(int healAmount)
    {
        int vidaTemporal = vidaActual + healAmount;

        if (vidaTemporal > vidaMaxima) {

            vidaActual = vidaMaxima;
        
        }
        else
        {
            vidaActual  = vidaTemporal;
        }
        
        cambioVida.Invoke(vidaActual);

    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Potion"))
        {
            // Cura 1 de vida
            Heal(1);
            AudioManager.PlayPotionSound();
            // Destruye el objeto
            Destroy(collision.gameObject);

        }

        if (collision.gameObject.CompareTag("Altar"))
        {
            // Cura 1 de vida
            Heal(1);
            AudioManager.PlayAltarSound();
           

        }
    }

    public void Morir()
    {
        
        StartCoroutine(MorirConRetraso());
       
        
    }

    private IEnumerator MorirConRetraso()
    {
        

        yield return new WaitForSeconds(2f);

        string escenaActual = Gestor.GetActiveScene().name;
        switch (escenaActual)
        {

            case "Game":
                Gestor.LoadScene("GameOver");
                Time.timeScale = 1.0f;
                break;


            case "Tutorial":
                Gestor.LoadScene("GameOverTutorial");
                Time.timeScale = 1.0f;
                break;

           
        }

        // Marca que el jugador está muerto
        isDead = false;
        

    }
}
