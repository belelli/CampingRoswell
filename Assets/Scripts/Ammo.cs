using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    public int damage = 5;
    public float destroyTimer = 3f;
    public GameObject ammoDeath;
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        { 
           
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            

            if (enemy != null)
            {
               
                enemy.takeDamage(damage);                
               

            }
           
            Destroy(gameObject, destroyTimer);
            Instantiate(ammoDeath, transform.position, Quaternion.identity);
            
        }
        
    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        OnDestroy();
    }

    private void OnDestroy()
    {
        if (transform.position.y < 0)
        {
            Destroy(gameObject, destroyTimer);
        }
    }
}
