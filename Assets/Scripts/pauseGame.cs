using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pauseGame : MonoBehaviour
{
    private bool isPaused = false;
    public GameObject playerScripts;



    public void Update()
    {
        // Detecta la presión de una tecla para pausar el juego (por ejemplo, la tecla 'P')
        if (Input.GetKeyDown(KeyCode.P))
        {
            TogglePause();
        }
    }

    public void TogglePause()
    {

        isPaused = !isPaused;

        if (isPaused)
        {

            Time.timeScale = 0f;
            playerScripts.GetComponent<SlingShot>().enabled = false;
            
        }
        else
        {

            Time.timeScale = 1f;
            playerScripts.GetComponent<SlingShot>().enabled = true;
            
        }
    }
}
