using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Item : MonoBehaviour
{
    public int ID;
    public string type;
    public string description;
    public string letterName;
    public bool isLetter;
    public Sprite icon;

    [HideInInspector]
    public bool pickedUp;

    [HideInInspector]
    public bool equipped;


    //private void OnCollisionEnter(Collision collision)
    //{
    //    if(collision.collider.tag == "Player")
    //    {
            
    //        Destroy(gameObject);


    //    }
    //}

    private void Update()
    {
        if (equipped) 
        {

        
        }

    }

    public void ItemUsage() 
    {
        if(type == "Carta") 
        {
            equipped = true;
        
        }
    
    }

    public void ReadLetter()
    {
        if (isLetter)
        {
            print("es una carta!!");
        }
    }

}
