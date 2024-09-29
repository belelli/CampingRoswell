using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

[System.Serializable]
public class QuestGoal
{
    public GoalType goalType;
    public int requiredAmount;
    public int currentAmount;


    public bool isReached()
    {
        return(currentAmount>=requiredAmount);
    }
    
    public void ItemCollected()
    {
        //print("entro al collision enter");
        currentAmount++;
        Debug.Log("entro a itemCollected la cantidad es "+currentAmount );
    }


}

public enum GoalType
{
    Kill,
    Gathering,
    ReachPlace
}