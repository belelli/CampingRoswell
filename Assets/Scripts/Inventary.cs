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
        

        allSlots = slotHolder.transform.childCount; //Cuenta cuantos Slots hay
        slots = new GameObject[allSlots]; //Se declara un Array de GameObjects
        for (int i = 0; i < allSlots; i++) //se itera sobre el array
        {
            slots[i] = slotHolder.transform.GetChild(i).gameObject; //a cada GameObject del array se le asigna un Slot (otro game object)

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
            print("HAsta aca "+itempickUp.name);
            Item item = itempickUp.GetComponent<Item>();
            
            print("inGameObject is "+item.inGameObject.name);
            print("columnObject is " + item.columnGameObject.name);

            AddItem(item.inGameObject, item.columnGameObject, item.ID,item.type,item.description,item.icon, item.letterName);

            print("es de inventory");
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

                //GameObject tempGO = Instantiate(inGameObject);
                //thisSlot.inGameObject = tempGO;

                
                thisSlot.inGameObject = inGameObject;
                thisSlot.ColumnGameObject = columnObject;
                thisSlot.ID = itemID;
                thisSlot.type = itemType;
                thisSlot.description = itemDescription;
                thisSlot.icon = itemIcon;
                thisSlot.letterName = letterName;
                

               

                


                //inGameObject.transform.parent = slots[i].transform; 
                inGameObject.SetActive(false);

                thisSlot.UpdateSlots();

                thisSlot.empty = false;
                return;
            }
        }
    }



    public void ActivateItem(int itemPosition, string description)
    {
        //Instantiate(slots[itemPosition].GetComponent<slot>().ColumnGameObject, currentColumn.spawnPoint);


        switch (description)
        {
            case "bee":
                Instantiate(currentColumn.beeColumnObject, currentColumn.spawnPoint);
                break;
            case "spider":
                Instantiate(currentColumn.spiderColumnObject, currentColumn.spawnPoint);
                break;
            case "apple":
                Instantiate(currentColumn.appleColumnObject, currentColumn.spawnPoint);
                break;
        }


        
        InventoryEnabled = false;
    }

    public void RemoveItem(int itemPosition)
    {
        
        
        print("aca se borra el item " + itemPosition);
        //slot thisSlot = slots[itemPosition].GetComponent<slot>();
        //slot nextSlot = slots[itemPosition+1].GetComponent<slot>();

        
        for (int i = itemPosition; i < allSlots; i++)
        {
            slot thisSlot = slots[i].GetComponent<slot>();
            slot nextSlot = slots[i + 1].GetComponent<slot>();

            //thisSlot.inGameObject = nextSlot.inGameObject;
            thisSlot.ColumnGameObject = nextSlot.ColumnGameObject;
            thisSlot.ID = nextSlot.ID;
            thisSlot.type = nextSlot.type;
            thisSlot.description = nextSlot.description;
            thisSlot.icon = nextSlot.icon;
            thisSlot.letterName = nextSlot.letterName;
            thisSlot.empty = nextSlot.empty;
            //print("PERO ahora tiene: " + thisSlot.description);
            thisSlot.UpdateSlots();
        }
   




    }




    

}
