using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour
{

    [SerializeField] private float cantidadPuntos;
    private Puntaje puntaje;
    AudioManager audioManager;


    private void Awake()
    {
        puntaje = GameObject.Find("Puntos").GetComponent<Puntaje>();

    }

    private void OnTriggerEnter2D(UnityEngine.Collider2D collision)
    {
       
        if (collision.gameObject.CompareTag("Player")){
            AudioManager.PlayGemSound();

            puntaje.SumarPuntos(cantidadPuntos);
            Destroy(gameObject);
        }

    }


}
