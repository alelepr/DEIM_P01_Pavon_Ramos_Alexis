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
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    public void PauseGame()
    {
        if (paused == false)
        {
            paused = true;
            panelPausa.SetActive(true);
        }
        else
        {
            paused = false;
            panelPausa.SetActive(false);
        }
    }
}
