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

    private void Start()
    {
        //slots = player.GetComponent<Inventary>().slots;
        
    }

    private void Update()
    {
        print(slotHolder.transform.childCount);
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            _arrowIndicator.SetActive(true);
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            _arrowIndicator.SetActive(false);
            
        }
    }

}
