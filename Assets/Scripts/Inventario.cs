using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventario : MonoBehaviour
{

    private bool InventoryEnabled;
    public GameObject inventory;
    private int allSlots;
    private int enabledSlots;
    private GameObject[] slot;
    public GameObject slotHolder;    
    public pauseGame _stopGame;
    public GameObject _pauseMove;

    void Start()
    {
        

        allSlots = slotHolder.transform.childCount;
        slot = new GameObject[allSlots];
        for (int i = 0; i < allSlots; i++)
        {
            slot[i] = slotHolder.transform.GetChild(i).gameObject;

            if (slot[i].GetComponent<NewBehaviourScript>().item == null)
            {
                slot[i].GetComponent<NewBehaviourScript>().empty = true;


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
            _stopGame.TogglePause();
            _pauseMove.GetComponent<PlayerMovement>().enabled = false;

        }
        else 
        {
            inventory.SetActive(false);
            _pauseMove.GetComponent<PlayerMovement>().enabled = true;
        }

        
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "item") 
        {
            GameObject itempickUp = other.gameObject;
            Item item = itempickUp.GetComponent<Item>();

            AddItem(itempickUp,item.ID,item.type,item.description,item.icon);


        }
    }

    public void AddItem(GameObject itemObject, int itemID, string itemType, string itemDescription, Sprite itemIcon)
    {
        for (int i = 0; i < allSlots; i++)
        {
            if (slot[i].GetComponent<NewBehaviourScript>().empty)
            {
                itemObject.GetComponent<Item>().pickedUp = true;

                slot[i].GetComponent<NewBehaviourScript>().item = itemObject;
                slot[i].GetComponent<NewBehaviourScript>().ID = itemID;
                slot[i].GetComponent<NewBehaviourScript>().type = itemType;
                slot[i].GetComponent<NewBehaviourScript>().description = itemDescription;
                slot[i].GetComponent<NewBehaviourScript>().icon = itemIcon;

                itemObject.transform.parent = slot[i].transform;
                itemObject.SetActive(false);

                slot[i].GetComponent<NewBehaviourScript>().UpdateSlots();

                slot[i].GetComponent<NewBehaviourScript>().empty = false;
                
                return;

            }
            

        }
    
    }
}
