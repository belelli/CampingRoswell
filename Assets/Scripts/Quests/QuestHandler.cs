using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestHandler : MonoBehaviour
{
    
    public Quest[] quests;
    public int collectiblesLayer;//Specify in which layer the collectibles are

    //Collect item
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == collectiblesLayer)
        {
            for (int i = 0; i < quests.Length; i++)
            {
                if (quests[i].prefabTag == collision.rigidbody.tag)
                {
                    quests[i].itemCollected();
                }
            }
            Destroy(collision.gameObject);
        }
    }




}
