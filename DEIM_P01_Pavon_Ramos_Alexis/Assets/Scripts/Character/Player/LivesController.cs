using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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


}
