using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class closeButton : MonoBehaviour
{
    public Canvas canvas;
    
    public void Close()
    {
    
        canvas.gameObject.SetActive(false);
    }
}
