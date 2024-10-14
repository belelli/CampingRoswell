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
                    print("2do if");
                }
                print("el de la quest" + quests[i].prefabTag);
                print("el del prefab" + collision.rigidbody.tag);   
                print(quests[i].prefabTag == collision.rigidbody.tag);
            }
            Destroy(collision.gameObject);
            
        }
    }




}