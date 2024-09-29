using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestGiver : MonoBehaviour
{
    public Quest quest;
    public PlayerMovement player;
    //public GameObject QuestFinishWindow;
    //public Text titleText;
    //public TextMeshProUGUI titleText;
    
    public void AcceptQuest()
    {
        player.quest = quest;
    }

    private void Start()
    {
        AcceptQuest();
    }









}
