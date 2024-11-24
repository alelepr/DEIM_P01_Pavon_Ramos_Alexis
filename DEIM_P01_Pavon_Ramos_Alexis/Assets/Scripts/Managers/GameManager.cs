using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using Gestor = GestionEscenas.SceneManager;
public class GameManager : MonoBehaviour
{

    public GameObject panelInicio;
    public GameObject panelPausa;
    public GameObject panelControl;
    public GameObject panelCredit;
    AudioManager audioManager;

    public bool controlPanelMenuIsActive;
    public bool isCreditPanelActive;


    public bool paused;


    // Start is called before the first frame update
    void Start()
    {
        string escenaActual = Gestor.GetActiveScene().name;

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
                        
           
            case "GameOverTutorial":
                AudioManager.PlayGameOverMusic();
                break;

            case "Tutorial":
                AudioManager.PlayBGMMusic();
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
        Gestor.LoadScene("Game");
        Time.timeScale = 1.0f;
        panelCredit.SetActive(false);
        panelControl.SetActive(false);

    }

    public void Tutorial()
    {
        Gestor.LoadScene("Tutorial");
        Time.timeScale = 1.0f;

    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void BackToMenu()
    {
        Time.timeScale = 1.0f;
        Gestor.LoadScene("MainMenu");
    }

    public void Continue()
    {
        paused = false;
        panelPausa.SetActive(false);
        Time.timeScale = 1.0f;
        panelCredit.SetActive(false);
        panelControl.SetActive(false);

    }
    
    public void ReloadScene()
    {
        Gestor.LoadScene("Game");
        Time.timeScale = 1.0f;

    }

    public void Retry()
    {
        string escenaActual = Gestor.GetActiveScene().name;
        switch (escenaActual)
        {
            
            case "Game":
                Gestor.LoadScene("Game");
                Time.timeScale = 1.0f;
                break;

           
            case "Tutorial":
                Gestor.LoadScene("Tutorial");
                Time.timeScale = 1.0f; 
                break;

            case "GameOverTutorial":
                Gestor.LoadScene("Tutorial");
                Time.timeScale = 1.0f;
                break;

            case "GameOver":
                Gestor.LoadScene("Game");
                Time.timeScale = 1.0f;
                break;
        }

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

    public void ControlMenu()
    {
        if (controlPanelMenuIsActive == false)
        {
            controlPanelMenuIsActive = true;
            panelControl.SetActive(true);
        }else
        {
            controlPanelMenuIsActive = false;

        }

    }

    public void CreditMenu()
    {
        if (isCreditPanelActive == false)
        {
            isCreditPanelActive = true;
            panelCredit.SetActive(true);
        }
        else
        {
            isCreditPanelActive = false;

        }

    }

    public void CreditMenuOut()
    {        
            panelCredit.SetActive(false);
            isCreditPanelActive = false;
                
    }


    public void ControlMenuOut()
    {
         controlPanelMenuIsActive = false;
         panelControl.SetActive(false);
        
    }
}
