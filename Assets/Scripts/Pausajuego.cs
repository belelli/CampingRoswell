using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameController : MonoBehaviour
{
    // Variable para saber si el juego está pausado o no
    private bool isPaused = false;
    public GameObject playerScripts;
    

    
    void Update()
    {
        // Detecta la presión de una tecla para pausar el juego (por ejemplo, la tecla 'P')
        if (Input.GetKeyDown(KeyCode.P))
        {
            TogglePause();
        }
    }

    void TogglePause()
    {
        
        isPaused = !isPaused;

        if (isPaused)
        {
           
            Time.timeScale = 0f;
            //playerScripts.GetComponent<slingShot>().enabled = false;
        }
        else
        {
           
            Time.timeScale = 1f;
            //playerScripts.GetComponent<slingShot>().enabled = true;
        }
    }
}

