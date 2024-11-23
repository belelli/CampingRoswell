using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestHandler : MonoBehaviour
{
    
    public Quest[] quests;
    public int collectiblesLayer;//Specifies in which layer the collectibles are
    public Inventary inventary;
    public GameObject letters;
    [SerializeField] GameObject[] lettersArray;

    private void Start()
    {
        //GENERA EL ARRAY DE LETTERS
        lettersArray = new GameObject[letters.transform.childCount];
        for (int i = 0; i < lettersArray.Length; i++)
        {
            lettersArray[i] = letters.transform.GetChild(i).gameObject;
        }
        /////////////////////////
        ///

    }

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
                    if (quests[i].isDone == true)
                    {
                        enableLetter(quests[i].letterToDropId);
                        
                    }
                }
                //print("el de la quest" + quests[i].prefabTag);
                //print("el del prefab" + collision.rigidbody.tag);   
                print(quests[i].prefabTag == collision.rigidbody.tag);
            }

            GameObject itempickUp = collision.rigidbody.gameObject;
            Item item = itempickUp.GetComponent<Item>();

            print("es de questHandler");
            inventary.AddItem(itempickUp, item.columnGameObject, item.ID, item.type, item.description, item.icon, item.letterName);
            Destroy(collision.gameObject);



        }
    }

    void enableLetter(int letterToDropId)
    {
        for (int i = 0; i < lettersArray.Length; i++)
        {
            var itemId = lettersArray[i].GetComponent<Item>().ID;
            if (itemId == letterToDropId)
            {
                lettersArray[i].SetActive(true);
            }
        }
    }






}
