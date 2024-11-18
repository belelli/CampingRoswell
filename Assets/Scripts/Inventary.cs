using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventary : MonoBehaviour
{

    private bool InventoryEnabled;
    public GameObject inventory;
    public int allSlots;
    private int enabledSlots;
    public GameObject[] slots;
    public GameObject slotHolder;    
    public pauseGame _stopGame;
    public GameObject _pauseMove;
    public int collectiblesLayer;//Specifies in which layer the collectibles are

    


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
}
