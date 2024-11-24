using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shrine : MonoBehaviour
{
    [SerializeField] GameObject shrineCanvas;
    [SerializeField] GameObject items;
    QuestHandler questHandler;
    [SerializeField] Quest[] quests;
    [SerializeField] public PlayerMovement player;
    public List<ColumnInteraction> columns = new List<ColumnInteraction>();

    void Start()
    {
        questHandler = player.GetComponent<QuestHandler>();
        quests = questHandler.quests;
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.O)) 
        {
            print("Las columnas estan bien?: "+AllColumnsAreCorrect());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        
        
        if (other.tag == "Player")
        {
           
            if ((!items.activeSelf) && AllQuestsAreCompleted())
            {
                shrineCanvas.SetActive(true);
            }
            
        }

    }

    public bool AllQuestsAreCompleted()
    {
        var completed = true;
        for (int i = 0; i < quests.Length; i++)
        {
            if (!quests[i].isDone)
            {
                completed = false;
            }
        }
        return completed;
    }
    
    
    public void YesButton()
    {
        items.SetActive(true);
        shrineCanvas.SetActive(false);
    }

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
}
