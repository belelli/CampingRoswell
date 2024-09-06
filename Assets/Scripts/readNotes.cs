using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;
using System.Linq;



public class readNotes : MonoBehaviour
{
    

    public Transform contentWindow;
    public GameObject recallTextObject;
    public string letterTitle;

    public Canvas canvas;
    

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {   //Cuando se toca una carta, se activa el canvas
        canvas.gameObject.SetActive(true);

        //Path a la carpeta de cartas
        string readFromFilePath = Application.streamingAssetsPath + "/Letters/" + letterTitle + ".txt";

     

        //Crea lista de strings con todas las lineas del txt
        List<string> fileLines = File.ReadAllLines(readFromFilePath).ToList();

        // Genera el string a partir de la lista
        string _textBuildUp = "";
        foreach (string line in fileLines) {
            _textBuildUp += line + "\n";
        }

        //popula el campo Texto de Recall text
        recallTextObject.GetComponent<TextMeshProUGUI>().text = _textBuildUp;
        
        

        Destroy(gameObject);
        
    }

    




}
