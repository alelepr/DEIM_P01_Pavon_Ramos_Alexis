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

        // Activar el AudioSource dependiendo de la escena activa
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
            // Destruye el objeto o desactívalo (opcional)
            Destroy(collision.gameObject);

        }
    }

    public void Morir()
    {
        
        StartCoroutine(MorirConRetraso());
       
        
    }

    private IEnumerator MorirConRetraso()
    {
        

        yield return new WaitForSeconds(2f);

        // Carga la escena "GameOver"
        SceneManager.LoadScene("GameOver");

        // Marca que el jugador está muerto
        isDead = false;
        

    }
}
