using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class slot : MonoBehaviour
{
    public GameObject itemPickUp;
    public GameObject ColumnGameObject;
    public int ID;
    public string type;
    public string description;
    public bool empty;
    public Sprite icon;
    public string letterName;
    public Sprite defaultIcon;
    public bool isPlaceble;
    

    public Transform slotIconGameObject;


        private void Start()
        {
        slotIconGameObject = transform.GetChild(0);
        }

 

    public void UpdateSlots() 
    {
        slotIconGameObject.GetComponent<Image>().sprite = icon;
    }

    public void UseItem() 
    {
    
    }

   
}
