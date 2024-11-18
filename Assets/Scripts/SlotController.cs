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




    public void clickSlot(int slotId)
    {
        
        
        print("Slock cliqueado :"+slotId);


        string itemType = inventary.slots[slotId].GetComponent<slot>().type;
        if ((itemType == "letter") &&(!inventary.shrineInUse))
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
        } else if((itemType == "Collectible") && (inventary.shrineInUse))
        {
            print("click en COLLECTIBLE");

        }
        

    }
}
