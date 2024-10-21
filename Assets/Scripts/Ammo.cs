using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    public int damage = 5;
    public float destroyTimer = 2f;
    public GameObject ammoDeath;
    public Rigidbody _rb;
    public float force;
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.layer == 6)
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
        _rb.velocity = transform.forward * force;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
}
