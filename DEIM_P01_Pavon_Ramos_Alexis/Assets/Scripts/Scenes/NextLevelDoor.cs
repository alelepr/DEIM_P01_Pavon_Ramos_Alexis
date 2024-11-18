using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Gestor = GestionEscenas.SceneManager;

public class NextLevelDoor : MonoBehaviour
{
    [SerializeField] private string sceneToLoad; // Nombre de la escena a cargar

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) // Asegúrate de que el jugador tenga esta etiqueta
        {
            // Cambia a la nueva escena
            Gestor.LoadScene("Game");
        }
    }
}
