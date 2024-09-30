using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class quitGame : MonoBehaviour
{    

    // Update is called once per frame
    void Update()
    {      
       if (Input.GetKeyDown(KeyCode.F4))
       {
          Application.Quit();
       }
        
    }
}
