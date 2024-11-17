using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public GameObject panelInicio;
    public GameObject panelPausa;
    AudioManager audioManager;


    public bool paused;


    // Start is called before the first frame update
    void Start()
    {
        string escenaActual = SceneManager.GetActiveScene().name;

        // Activar el AudioSource dependiendo de la escena activa
        switch (escenaActual)
        {
            case "MainMenu":
                AudioManager.PlayMainMenuMusic();
                break;

            case "Game":
                AudioManager.PlayBGMMusic();
                break;
            case "GameOver":
                AudioManager.PlayGameOverMusic();
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        PauseGame();
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Game");
        Time.timeScale = 1.0f;

    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Continue()
    {
        paused = false;
        panelPausa.SetActive(false);
        Time.timeScale = 1.0f;
    }
    
    public void ReloadScene()
    {
        SceneManager.LoadScene("Game");
        Time.timeScale = 1.0f;

    }
    public void PauseGame()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            paused = !paused; // Cambia el estado de pausa

            if (paused)
            {
                panelPausa.SetActive(true);
                Time.timeScale = 0f; // Pausa el juego
            }
            else
            {
                panelPausa.SetActive(false);
                Time.timeScale = 1.0f; // Reanuda el juego
            }
        }
        
    }
}
