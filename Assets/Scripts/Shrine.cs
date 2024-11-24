using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shrine : MonoBehaviour
{
    //[SerializeField] GameObject shrineCanvas; //DISENIO VIEJO DE SHRINE
    [SerializeField] GameObject itemsToActivate;
    //QuestHandler questHandler; //DISENIO VIEJO DE SHRINE
    //[SerializeField] Quest[] quests; //DISENIO VIEJO DE SHRINE
    [SerializeField] public PlayerMovement player;
    public List<ColumnInteraction> columns = new List<ColumnInteraction>();

    void Start()
    {
        //questHandler = player.GetComponent<QuestHandler>(); //DISENIO VIEJO DE SHRINE
        //quests = questHandler.quests; //DISENIO VIEJO DE SHRINE
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.O)) 
        {
            print("Las columnas estan bien?: "+AllColumnsAreCorrect());
        }
        if (Input.GetKeyUp(KeyCode.U))
        {
            print("todas tienen algo?: " + AllColumsHaveItems());
        }

        if (AllColumsHaveItems()) 
        {
            if (AllColumnsAreCorrect())
            {
                print("TODO JOSHA");
                itemsToActivate.SetActive(true);
            }
        }
    }

    //DISENIO VIEJO DE SHRINE
    //private void OnTriggerEnter(Collider other)
    //{


    //    if (other.tag == "Player")
    //    {

    //        if ((!items.activeSelf) && AllQuestsAreCompleted())
    //        {
    //            shrineCanvas.SetActive(true);
    //        }

    //    }

    //}


    //DISENIO VIEJO DE SHRINE
    //public bool AllQuestsAreCompleted()
    //{
    //    var completed = true;
    //    for (int i = 0; i < quests.Length; i++)
    //    {
    //        if (!quests[i].isDone)
    //        {
    //            completed = false;
    //        }
    //    }
    //    return completed;
    //}


    //DISENIO VIEJO DE SHRINE
    //public void YesButton()
    //{
    //    items.SetActive(true);
    //    shrineCanvas.SetActive(false);
    //}

    private bool AllColumnsAreCorrect()
    {
        foreach (ColumnInteraction col in columns) 
        {
            //print("****************");
            //print("COLUMNA "+col.ItemId);
            //print("el item POSTA para esta columna seria un " + col.correctItemToPlaceInColumn);
            //print("en esta col hay un " + col.ItemInColumn());
            //print("****************");

            string itemInThisColumn = col.ItemInColumn();
            if (!col.ColumnHasCorrectItem(itemInThisColumn))
            {
                return false;
            }
        }
        return true;
    }

    private bool AllColumsHaveItems()
    {
        foreach (ColumnInteraction column in columns)
        {
            if (!column.ColumnHasItem())
            {
                return false;
            }
        }

        return true;
    }
}
