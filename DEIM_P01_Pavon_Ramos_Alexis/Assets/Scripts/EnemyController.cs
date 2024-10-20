using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    private LivesController livesController;

    public int enemyLives;

    void Start()
    {
        enemyLives = 5;
        livesController = GetComponent<LivesController>();

    }


    private void OnTriggerEnter2D(UnityEngine.Collider2D collision)
    {
       
        if (collision.gameObject.CompareTag("Player"))
        {
            if (enemyLives >= 1)
            {
                PerderVida();
            }
            else
            {
                Morir();
            }


        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision2) {

        
        if (collision2.gameObject.CompareTag("Player"))
        {
        livesController.EnemyDamage(1); //Metodo que daña al jugador
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

    private void Morir()
    {
        // Aquí puedes agregar efectos como animaciones o sonidos de muerte
        Destroy(gameObject);
    }

}
