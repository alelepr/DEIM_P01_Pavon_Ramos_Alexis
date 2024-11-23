using GestionEscenas;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Gestor = GestionEscenas.SceneManager;

public class NextLevelDoor : MonoBehaviour
{



    [SerializeField] private string sceneToLoad; // Nombre de la escena a cargar
    private AudioManager audioManager;

    private void Start()
    {
        audioManager = FindObjectOfType<AudioManager>(); // Obtener la referencia al AudioManager si no está asignado
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) // Asegúrate de que el jugador tenga esta etiqueta
        {
            // Reproducir el sonido de victoria
            AudioManager.PlayWinSound();

            // Llamar a la corutina para cargar la escena después de 2 segundos
            StartCoroutine(LoadSceneAfterDelay(2f)); // Espera 2 segundos antes de cargar la nueva escena
        }
    }

    // Corutina que carga la escena después de un retraso
    private IEnumerator LoadSceneAfterDelay(float delay)
    {
        // Espera el número de segundos especificado
        yield return new WaitForSeconds(delay);

        // Cargar la escena especificada
        Gestor.LoadScene("Game");
    }













    /*[SerializeField] private string sceneToLoad; // Nombre de la escena a cargar
    AudioManager audioManager;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) // Asegúrate de que el jugador tenga esta etiqueta
        {

            AudioManager.PlayWinSound();
            // Cambia a la nueva escena
            Gestor.LoadScene("Game");


        }
    }*/
}
