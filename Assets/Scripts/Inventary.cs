using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;
using static UnityEditor.Progress;

public class Inventary : MonoBehaviour
{

    public bool InventoryEnabled;
    public GameObject inventory;
    public int allSlots;
    private int enabledSlots;
    public GameObject[] slots;
    public GameObject slotHolder;    
    public pauseGame _stopGame;
    public GameObject _pauseMove;
    public int collectiblesLayer;//Specifies in which layer the collectibles are
    public bool shrineInUse = false;
    public ColumnInteraction currentColumn;

    


    void Start()
    {
        

        allSlots = slotHolder.transform.childCount;
        slots = new GameObject[allSlots];
        for (int i = 0; i < allSlots; i++)
        {
            slots[i] = slotHolder.transform.GetChild(i).gameObject;

            if (slots[i].GetComponent<slot>().item == null)
            {
                slots[i].GetComponent<slot>().empty = true;


            }
        }
    }

   
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I)) 
        {
            InventoryEnabled = !InventoryEnabled;
           
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            print("Shrine in use? "+shrineInUse);
        }

        if (!InventoryEnabled)
        {
            shrineInUse = false;
        }


        if (InventoryEnabled) 
        {
            inventory.SetActive(true);
            // _stopGame.TogglePause();
            _pauseMove.GetComponent<PlayerMovement>().enabled = false;
            _pauseMove.GetComponentInChildren<PlayerAttack>().enabled = false;

        }
        else 
        {
            inventory.SetActive(false);
            _pauseMove.GetComponent<PlayerMovement>().enabled = true;
            _pauseMove.GetComponentInChildren<PlayerAttack>().enabled = true;
        }

        
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Item>() != null)
        {
            GameObject itempickUp = other.gameObject;
            Item item = itempickUp.GetComponent<Item>();

            AddItem(itempickUp,item.ID,item.type,item.description,item.icon, item.letterName);


        }
    }




    public void AddItem(GameObject itemObject, int itemID, string itemType, string itemDescription, Sprite itemIcon, string letterName)
    {
        for (int i = 0; i < allSlots; i++)
        {
            if (slots[i].GetComponent<slot>().empty)
            {
                itemObject.GetComponent<Item>().pickedUp = true;

                slots[i].GetComponent<slot>().item = itemObject;
                slots[i].GetComponent<slot>().ID = itemID;
                slots[i].GetComponent<slot>().type = itemType;
                slots[i].GetComponent<slot>().description = itemDescription;
                slots[i].GetComponent<slot>().icon = itemIcon;

                slots[i].GetComponent<slot>().letterName = letterName;


                itemObject.transform.parent = slots[i].transform;
                itemObject.SetActive(false);

                slots[i].GetComponent<slot>().UpdateSlots();

                slots[i].GetComponent<slot>().empty = false;
                return;
            }
        }
    }

    public void activateItem(string itemToActivate) 
    {
        switch (itemToActivate) 
        {
            case "apple" :
                currentColumn.itemsInColumn[0].SetActive(true);
                break;
            case "bee":
                currentColumn.itemsInColumn[1].SetActive(true);
                break;

            case "spider":
                currentColumn.itemsInColumn[2].SetActive(true);
                break;
        }
        InventoryEnabled = !InventoryEnabled;

    }

    internal void removeItemfromInventory(int indexToRemove)
    {


        
        //print("borrar el indice " + indexToRemove);
        //print("hay que borrar este "+slots[indexToRemove].GetComponent<slot>().description);
        //print("Se cambio?");
        //slots[indexToRemove].GetComponent<slot>().description = slots[indexToRemove + 1].GetComponent<slot>().description;
        //slots[indexToRemove].GetComponent<slot>().icon = slots[indexToRemove + 1].GetComponent<slot>().icon;
        //slots[indexToRemove].GetComponent<slot>().UpdateSlots();

        for (int i = indexToRemove; i <= allSlots; i++)//allSlots-1
        {
            slots[i].GetComponent<slot>().description = slots[i + 1].GetComponent<slot>().description;
            slots[i].GetComponent<slot>().icon = slots[i + 1].GetComponent<slot>().icon;
            slots[i].GetComponent<slot>().ID = slots[i + 1].GetComponent<slot>().ID;
            slots[i].GetComponent<slot>().empty = slots[i + 1].GetComponent<slot>().empty;
            slots[i].GetComponent<slot>().item = slots[i + 1].GetComponent<slot>().item;
            slots[i].GetComponent<slot>().UpdateSlots();

        }




    }
    

}
