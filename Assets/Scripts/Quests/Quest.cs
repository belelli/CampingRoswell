using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

[System.Serializable]
public class Quest
{
    public bool isActive;
    public bool isDone = false;
    public string title;
    public string description;
    public int numberOfItemsToCollect = 0;
    public int itemsCollected;
    public GameObject QuestFinishWindow;
    public TextMeshProUGUI titleText;
    public GameObject itemToCollect;
    public string prefabTag;//Es el tag que tiene que tener el prefab
    public int letterToDropId;


    
    public void Complete()
    {
        isActive = false;
        isDone = true;
        Debug.Log(title + " is Completed");
        OpenQuestFinishWindow();
        titleText.text = "La mision "+title+" fue completada!!!";
  
    }


    public void OpenQuestFinishWindow()
    {
        QuestFinishWindow.SetActive(true);
        titleText.text = title;
    }

    public void itemCollected()
    {
        itemsCollected++;
        if(itemsCollected== numberOfItemsToCollect)
        {
            Complete();
        }
    }








}
