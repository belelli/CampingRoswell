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
}
