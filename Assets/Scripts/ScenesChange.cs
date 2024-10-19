using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ScenesChange : MonoBehaviour
{
    public int sceneToTravelto;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") {
            print("Llego Dorian!");
            SceneManager.LoadScene("Level2");
        }
    }
}
