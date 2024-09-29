using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[System.Serializable]
public class Quest
{
    public bool isActive;
    public string title;
    public string description;
    public QuestGoal goal;
    public GameObject QuestFinishWindow;
    //public Text titleText;
    public TextMeshProUGUI titleText;

    public void Complete()
    {
        isActive = false;
        Debug.Log(title + " is Completed");
        OpenQuestFinishWindow();
        titleText.text = "La mision "+title+" fue completada!!!";

    }


    public void OpenQuestFinishWindow()
    {
        QuestFinishWindow.SetActive(true);
        titleText.text = title;
    }




}
