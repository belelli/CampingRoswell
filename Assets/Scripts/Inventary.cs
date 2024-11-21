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

            if (slots[i].GetComponent<slot>().inGameObject == null)
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

            AddItem(item.inGameObject, item.columnGameObject, item.ID,item.type,item.description,item.icon, item.letterName);


        }
    }




    public void AddItem(GameObject inGameObject, GameObject columnObject, int itemID, string itemType, string itemDescription, Sprite itemIcon, string letterName)
    {
        for (int i = 0; i < allSlots; i++)
        {
            slot thisSlot = slots[i].GetComponent<slot>();
            if (slots[i].GetComponent<slot>().empty)
            {
                //inGameObject.GetComponent<Item>().pickedUp = true;

                thisSlot.inGameObject = inGameObject;
                thisSlot.ColumnGameObject = columnObject;
                thisSlot.ID = itemID;
                thisSlot.type = itemType;
                thisSlot.description = itemDescription;
                thisSlot.icon = itemIcon;
                thisSlot.letterName = letterName;


                inGameObject.transform.parent = slots[i].transform;
                inGameObject.SetActive(false);

                thisSlot.UpdateSlots();

                thisSlot.empty = false;
                return;
            }
        }
    }

    public void activateItem(string itemToActivate) 
    {

        print("el item description es " + slots[0].GetComponent<slot>().description);
        print("itemToActivate ES " + itemToActivate);


        for (int i = 0; i < allSlots; i++)
        {
            if (slots[i].GetComponent<slot>().description == itemToActivate)
            {
                Instantiate(slots[i].GetComponent<slot>().ColumnGameObject, currentColumn.spawnPoint);
            }
        }

    }

    internal void removeItemfromInventory(int indexToRemove)
    {




        for (int i = indexToRemove; i <= allSlots; i++)//allSlots-1
        {
            
            //slots[i].GetComponent<slot>().description = slots[i + 1].GetComponent<slot>().description;
            //slots[i].GetComponent<slot>().icon = slots[i + 1].GetComponent<slot>().icon;
            //slots[i].GetComponent<slot>().ID = slots[i + 1].GetComponent<slot>().ID;
            //slots[i].GetComponent<slot>().empty = slots[i + 1].GetComponent<slot>().empty;
            //slots[i].GetComponent<slot>().inGameObject = slots[i + 1].GetComponent<slot>().inGameObject;
            //slots[i].GetComponent<slot>().UpdateSlots();
        }




    }
    

}
