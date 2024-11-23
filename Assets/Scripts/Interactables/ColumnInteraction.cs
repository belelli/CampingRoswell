using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnInteraction : MonoBehaviour
{
    [SerializeField] GameObject _arrowIndicator;
    //[SerializeField] GameObject[] slots;
    [SerializeField] GameObject slotHolder;
    [SerializeField] PlayerMovement player;

    public Transform spawnPoint;

    [SerializeField] bool columnIsActive = false;
    [SerializeField] Inventary inventary;
    //[SerializeField] PlayerMovement playerMovement;
    [SerializeField] int ItemId;

    private void Start()
    {
        inventary = player.GetComponent<Inventary>();
        
    }
    

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && columnIsActive)
        {
            if (!ColumnHasItem())
            {
                inventary.InventoryEnabled = !inventary.InventoryEnabled;
                inventary.shrineInUse = !inventary.shrineInUse;
            }
            else
            {
                Item itemInColumn = spawnPoint.GetComponentInChildren<Item>();
                print("Hay que guardar el item "+itemInColumn.description);


                GameObject objectReference = itemInColumn.gameObject;
                Destroy(itemInColumn.gameObject);

                //inventary.AddItem(itemInColumn.inGameObject, itemInColumn.columnGameObject, itemInColumn.ID,itemInColumn.type, itemInColumn.description, itemInColumn.icon, itemInColumn.letterName);
                inventary.AddItem(objectReference, itemInColumn.columnGameObject, itemInColumn.ID, itemInColumn.type, itemInColumn.description, itemInColumn.icon, itemInColumn.letterName);

            }

        }

    }

    

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            _arrowIndicator.SetActive(true);
            columnIsActive = true;
            inventary.currentColumn = this;
            
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            _arrowIndicator.SetActive(false);
            columnIsActive = false;
        }
        print("Columna llena? "+ColumnHasItem());
        if (ColumnHasItem())
        {
            print("la columna tiene un " + spawnPoint.GetComponentInChildren<Item>().description);
        }
    }

    public bool ColumnHasItem()
    {
        
        return (spawnPoint.GetComponentInChildren<Item>() != null);

    }



}
