using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    // Declarar la variable Animator

    public int enemyLives;

    void Start()
    {
        enemyLives = 5;
       
    }


    private void OnTriggerEnter2D(UnityEngine.Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PerderVida();
        }
    }

    public void PerderVida()
    {
        
        enemyLives --; // Reducir la vida en 1

        if (enemyLives <= 0)
        {
            Morir();
        }
    }

    public void Morir()
    {
        // Aquí puedes agregar efectos como animaciones o sonidos de muerte
        Destroy(gameObject);
    }

}
