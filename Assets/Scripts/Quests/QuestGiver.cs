using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestGiver : MonoBehaviour
{
    public Quest quest;
    public PlayerMovement player; 
    
    public void AcceptQuest()
    {
        player.quest = quest;
    }

    private void Start()
    {
        AcceptQuest();
    }








}
