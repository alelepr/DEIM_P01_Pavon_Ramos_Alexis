using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour
{

    [SerializeField] private float cantidadPuntos;
    [SerializeField] private Puntaje puntaje;

    
    private void OnTriggerEnter2D(UnityEngine.Collider2D collision)
    {
       
        if (collision.gameObject.CompareTag("Player")){
            puntaje.SumarPuntos(cantidadPuntos);
            Destroy(gameObject);
        }

    }


}
