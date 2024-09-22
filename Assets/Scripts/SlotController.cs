using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TMPro;
using UnityEngine;

public class SlotController : MonoBehaviour
{
    public Inventary inventary;
    public Canvas canvas; //este es el Letter canvas
    public GameObject recallTextObject;



    // Start is called before the first frame update
    private void Awake()
    {
        
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ClickZero() {

        //print("Click " + inventary.slots[0].GetComponent<slot>().letterName);
        

        //Cuando se toca una carta, se activa el canvas
        canvas.gameObject.SetActive(true);

        //Path a la carpeta de cartas
        string readFromFilePath = Application.streamingAssetsPath + "/Letters/" + inventary.slots[0].GetComponent<slot>().letterName + ".txt";



        //Crea lista de strings con todas las lineas del txt
        List<string> fileLines = File.ReadAllLines(readFromFilePath).ToList();

        // Genera el string a partir de la lista
        string _textBuildUp = "";
        foreach (string line in fileLines)
        {
            _textBuildUp += line + "\n";
        }

        //popula el campo Texto de Recall text
        recallTextObject.GetComponent<TextMeshProUGUI>().text = _textBuildUp;


    }

    public void ClickOne()
    {

        //print("Click " + inventary.slots[0].GetComponent<slot>().letterName);


        //Cuando se toca una carta, se activa el canvas
        canvas.gameObject.SetActive(true);

        //Path a la carpeta de cartas
        string readFromFilePath = Application.streamingAssetsPath + "/Letters/" + inventary.slots[1].GetComponent<slot>().letterName + ".txt";



        //Crea lista de strings con todas las lineas del txt
        List<string> fileLines = File.ReadAllLines(readFromFilePath).ToList();

        // Genera el string a partir de la lista
        string _textBuildUp = "";
        foreach (string line in fileLines)
        {
            _textBuildUp += line + "\n";
        }

        //popula el campo Texto de Recall text
        recallTextObject.GetComponent<TextMeshProUGUI>().text = _textBuildUp;


    }
}
