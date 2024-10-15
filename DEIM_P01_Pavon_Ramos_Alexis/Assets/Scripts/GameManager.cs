using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public GameObject panelInicio;
    public GameObject panelPausa;

    public bool paused;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PauseGame();
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Game");
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
            if (paused == false)
            {
                paused = true;
                panelPausa.SetActive(true);
                Time.timeScale = 0f;
            }
            else
            {
                paused = false;
                panelPausa.SetActive(false);
                Time.timeScale = 1.0f;

            }
        }
    }
}
