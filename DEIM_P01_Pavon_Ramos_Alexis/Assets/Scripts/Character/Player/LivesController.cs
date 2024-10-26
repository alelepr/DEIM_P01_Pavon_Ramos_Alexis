using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class LivesController : MonoBehaviour
{
    // Start is called before the first frame update
    public int vidaActual;
    public int vidaMaxima;
    public UnityEvent<int> cambioVida;


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
        
            Destroy(gameObject);
            SceneManager.LoadScene("GameOver");
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
            // Destruye el objeto o desactívalo (opcional)
            Destroy(collision.gameObject);

        }
    }

}
