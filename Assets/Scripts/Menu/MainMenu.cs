using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Jugar()
    {
        SceneManager.LoadScene(1);
    }


    public void Salir()
    {
        SceneManager.LoadScene(0);
        Debug.Log("Salir...");
        Application.Quit();

    }

    public void Opciones()
    {
        SceneManager.LoadScene("MenuOpciones");


    }

    public void Prototipo()
    {
        SceneManager.LoadScene(2);
    }
}
