using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnInteraction : MonoBehaviour
{
    [SerializeField] GameObject _arrowIndicator;
    //[SerializeField] GameObject[] slots;
    [SerializeField] GameObject slotHolder;
    [SerializeField] PlayerMovement player;
    [SerializeField] GameObject ApplePrefab;
    [SerializeField] GameObject SpiderPrefab;
    [SerializeField] GameObject BeePrefab;
    [SerializeField] Transform SpawnPoint;
    [SerializeField] GameObject[] objects;
    [SerializeField] bool columnIsActive = false;
    [SerializeField] Inventary inventary;

    private void Start()
    {
        inventary = player.GetComponent<Inventary>();
        
    }
    

    private void Update()
    {
        // if ((columnIsActive) && PlayerHitsE())
        //{
        //     ApplePrefab.SetActive(true);
        // }
        if (Input.GetKeyDown ( KeyCode.E) && columnIsActive)
        {
            print("EEEEH");
            inventary.InventoryEnabled = !inventary.InventoryEnabled;
            inventary.shrineInUse = !inventary.shrineInUse;

        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            _arrowIndicator.SetActive(true);
            columnIsActive = true;
            
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


    //bool PlayerHitsE() 
    //{
    //    return(Input.GetKeyDown(KeyCode.E));
    //}

}
