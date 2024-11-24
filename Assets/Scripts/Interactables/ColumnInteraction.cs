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
    

    public GameObject beeColumnObject;
    public GameObject spiderColumnObject;
    public GameObject appleColumnObject;
    public int ItemId;
    public string correctItemToPlaceInColumn;
    
    

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
    }

    public bool ColumnHasItem() //Te dice si la columna esta ocupada o no
    {
        return (spawnPoint.GetComponentInChildren<Item>() != null);
    }

    public string ItemInColumn() //Te devuelve un string con la description del item que esta en la columna
    {
        return (spawnPoint.GetComponentInChildren<Item>().description);
    }

    public bool ColumnHasCorrectItem(string itemInColumn) //Te dice si la columna tiene el item indicado 
    {
        return (itemInColumn == correctItemToPlaceInColumn);
    }



}
