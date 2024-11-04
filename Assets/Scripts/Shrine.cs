using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shrine : MonoBehaviour
{
    
    [SerializeField] GameObject shrineCanvas;
    [SerializeField] GameObject items;
    // Start is called before the first frame update
    void Start()
    {
        //items = this.gameObject.transform.GetChild(0).gameObject;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //print("Entro el Player!!!");

            shrineCanvas.SetActive(true);
            //items.SetActive(true);
        }
    }

    public void YesButton()
    {
        items.SetActive(true);
        shrineCanvas.SetActive(false);
    }
}
