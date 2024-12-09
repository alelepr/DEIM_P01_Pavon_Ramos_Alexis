using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    // Declarar la variable Animator

    public int enemyLives;
    [SerializeField] private float cantidadPuntos;
    private Puntaje puntaje;

    void Start()
    {
        enemyLives = 2;
        puntaje = GameObject.Find("Puntos").GetComponent<Puntaje>();


    }


    private void OnTriggerEnter2D(UnityEngine.Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            //PerderVida();
        }
    }

    public void PerderVida()
    {
        
        enemyLives --; // Reducir la vida en 1

        if (enemyLives <= 0)
        {
            Morir();
            puntaje.SumarPuntos(cantidadPuntos);

        }
    }

    public void Morir()
    {
        
        Destroy(gameObject);
    }

}
