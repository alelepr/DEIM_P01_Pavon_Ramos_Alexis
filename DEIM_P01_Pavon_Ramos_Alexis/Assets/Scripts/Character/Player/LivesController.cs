using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using System;

public class LivesController : MonoBehaviour
{
    // Start is called before the first frame update
    public int vidaActual;
    public int vidaMaxima;
    public UnityEvent<int> cambioVida;
    AudioManager audioManager;

    public bool isDead;

    Animator animator;

    void Start()
    {
        vidaActual = vidaMaxima;
        cambioVida.Invoke(vidaActual);

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
        isDead = true;
        StartCoroutine(MorirConRetraso());
        animator.SetTrigger("Dead");
       
        
    }

    private IEnumerator MorirConRetraso()
    {
        yield return new WaitForSeconds(2f);


        // Carga la escena "GameOver"
        SceneManager.LoadScene("GameOver");

        // Marca que el jugador está muerto
        isDead = true;
    }
}
