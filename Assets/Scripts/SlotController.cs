using JetBrains.Annotations;
using System;
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
    public GameObject slotHolder;
    //public ColumnInteraction column;




    public void clickSlot(int slotId)
    {
        print("Slock cliqueado :"+slotId);
        string itemType = inventary.slots[slotId].GetComponent<slot>().type;
        string itemDescription = inventary.slots[slotId].GetComponent<slot>().description;
        
        if ((itemType == "letter") &&(!inventary.shrineInUse))
        {

            readletter(slotId);
            
        } else if((itemType == "Collectible") && (inventary.shrineInUse)) //CLICK EN UN ITEM COLLECCIONABLE mientras se esta USANDO inventario en columna
        {
            useItem(itemDescription, slotId);

        }
    }

    private void readletter(int slotId)
    {
        //Cuando se toca una carta, se activa el canvas
        canvas.gameObject.SetActive(true);
        //Path a la carpeta de cartas
        string readFromFilePath = Application.streamingAssetsPath + "/Letters/" + inventary.slots[slotId].GetComponent<slot>().letterName + ".txt";
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
    public void useItem(string itemDescription, int slotId) 
    {
        print("click en COLLECTIBLE = " + itemDescription);

        //inventary.ActivateItem(itemDescription);
        inventary.RemoveItem(slotId);
    }
}
